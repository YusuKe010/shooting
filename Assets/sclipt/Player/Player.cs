using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))] // Rigidbody コンポーネントのアタッチを強制する
public class Player : MonoBehaviour
{
    public static Player _instance;

    [SerializeField] SceneChanger _sceneChanger;


    //プレイヤー
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed = 5f;
    float[] _bulletTimer = { 0, 0 };

    //プレイヤーの強さ
    float[] _bulletLimit = { 0.15f, 1f };
    float _maxPlayerPower = 5.0f;
    float _playerPower = 1.0f;
    [SerializeField] Text _powerText;

    //プレイヤーの弾
    [SerializeField] GameObject _bulletPrefab = null;
    [SerializeField] Transform _muzzle = null;
    [SerializeField] GameObject _bulletPrefab2 = null;
    [SerializeField] Transform[] _muzzle2 = null;

    //弾の威力
    [SerializeField] int _bulletPower = 100;
    public int BulletDamage => _bulletPower;


    //ボム
    [SerializeField] GameObject _bombPrefab;
    [SerializeField] Text _bombText;
    int _bombValue = 3;

    //残機表示
    [SerializeField] Text _lifeText;
    [SerializeField] int _life = 3;
    public int Life => _life;

    //無敵モード
    [SerializeField] bool _invincibility = true;

    //エフェクト
    [SerializeField] GameObject _effct;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager._instance.Wave < 5 && GameManager._instance.Wave >= 1)
        {
            // 自機を移動させる
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector2 dir = new Vector2(h, v).normalized;
            _rb.velocity = dir * _moveSpeed;

            if (Input.GetButton("Fire1"))
            {
                if (_bulletTimer[0] > _bulletLimit[0])
                {
                    Fire1(_bulletPrefab, _muzzle);
                    _bulletTimer[0] = 0f;
                }
                else
                {
                    _bulletTimer[0] += Time.deltaTime;
                }

                if (_bulletTimer[1] > _bulletLimit[1] && _playerPower >= 3f)
                {
                    Fire2(_bulletPrefab2, _muzzle2);
                    _bulletTimer[1] = 0f;
                }
                else
                {
                    _bulletTimer[1] += Time.deltaTime;
                }
            }

            if (Input.GetMouseButtonDown(1) && _bombValue != 0)
            {
                Bomb(_bombPrefab, _muzzle,  _bombText, _bombValue);
            }
        }
        else
        {
            _rb.velocity = new Vector2(0, 0);
        }

        
        if (_playerPower >= 5)
        {
            _bulletLimit[1] = 0.5f;
        }
        else if (_playerPower >= 4)
        {
            _bulletLimit[1] = 0.75f;
        }
        else if (_playerPower >= 2f)
        {
            _bulletLimit[0] = 0.15f;
        }
    }


    void Fire1(GameObject bulletPrefab, Transform muzzle)
    {
        GameObject go = Instantiate(bulletPrefab, muzzle.position, bulletPrefab.transform.rotation);  // インスペクターから設定した m_bulletPrefab をインスタンス化する
    }

    void Fire2(GameObject bulletPrefab, Transform[] muzzles)
    {
        foreach (Transform muzzle in muzzles)
        {
            GameObject bullet2 = Instantiate(bulletPrefab, muzzle.position, bulletPrefab.transform.rotation);
        }
    }

    void Bomb(GameObject bombPrefab, Transform muzzle, Text bombText, int bombValue)
    {
        GameObject bomb = Instantiate(bombPrefab, muzzle.position, bombPrefab.transform.rotation);
        Destroy(bomb, 3f);
        bombValue -= 1;
        bombText.text = "Spell:" + bombValue.ToString("d2");
    }

    /// <summary>/// プレーヤーのパワーアップ /// </summary>
    public void PowerUp(float powerUp)
    {
        if (_playerPower >= _maxPlayerPower)
        {
            _playerPower = _maxPlayerPower;
            _powerText.text = "Power:" + _maxPlayerPower.ToString("f2");
        }
        else
        {
            _playerPower += powerUp;
            _powerText.text = "Power:" + _playerPower.ToString("f2");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !_invincibility)
        {
            _life -= 1;
            _playerPower -= 0.5f;
            _lifeText.text = "Player:" + _life.ToString("d2");
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject bullet in bullets)
            {
                GameObject effect = Instantiate(_effct, bullet.transform.position, bullet.transform.rotation);
                Destroy(effect, 1f);
                Destroy(bullet);
            }
        }
    }
}

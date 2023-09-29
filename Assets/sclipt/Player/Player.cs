using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))] // Rigidbody �R���|�[�l���g�̃A�^�b�`����������
public class Player : MonoBehaviour
{
    public static Player _instance;

    [SerializeField] SceneChanger _sceneChanger;


    //�v���C���[
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed = 5f;
    float[] _bulletTimer = { 0, 0 };

    //�v���C���[�̋���
    float[] _bulletLimit = { 0.15f, 1f };
    float _maxPlayerPower = 5.0f;
    float _playerPower = 1.0f;
    [SerializeField] Text _powerText;

    //�v���C���[�̒e
    [SerializeField] GameObject _bulletPrefab = null;
    [SerializeField] Transform _muzzle = null;
    [SerializeField] GameObject _bulletPrefab2 = null;
    [SerializeField] Transform[] _muzzle2 = null;

    //�e�̈З�
    [SerializeField] int _bulletPower = 100;
    public int BulletDamage => _bulletPower;


    //�{��
    [SerializeField] GameObject _bombPrefab;
    [SerializeField] Text _bombText;
    int _bomb = 3;

    //�c�@�\��
    [SerializeField] Text _lifeText;
    [SerializeField] int _life = 3;
    public int Life => _life;

    //���G���[�h
    [SerializeField] bool _invincibility = true;

    //�G�t�F�N�g
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
            // ���@���ړ�������
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector2 dir = new Vector2(h, v).normalized;
            _rb.velocity = dir * _moveSpeed;

            if (Input.GetButton("Fire1"))
            {
                if (_bulletTimer[0] > _bulletLimit[0])
                {
                    Fire1();
                    _bulletTimer[0] = 0f;
                }
                else
                {
                    _bulletTimer[0] += Time.deltaTime;
                }

                if (_bulletTimer[1] > _bulletLimit[1] && _playerPower >= 3f)
                {
                    Fire2();
                    _bulletTimer[1] = 0f;
                }
                else
                {
                    _bulletTimer[1] += Time.deltaTime;
                }
            }

            if (Input.GetMouseButtonDown(1) && _bomb != 0)
            {
                GameObject bomb = Instantiate(_bombPrefab, _muzzle.position, _bombPrefab.transform.rotation);
                Destroy(bomb, 3f);
                _bomb -= 1;
                _bombText.text = "Spell:" + _bomb.ToString("d2");
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
    void Fire1()
    {
        if (_bulletPrefab && _muzzle) // m_bulletPrefab �Ƀv���n�u���ݒ肳��Ă��鎞 ���� m_muzzle �ɒe�̔��ˈʒu���ݒ肳��Ă��鎞
        {
            GameObject go = Instantiate(_bulletPrefab, _muzzle.position, _bulletPrefab.transform.rotation);  // �C���X�y�N�^�[����ݒ肵�� m_bulletPrefab ���C���X�^���X������
        }
    }

    void Fire2()
    {
        foreach (Transform muzzle in _muzzle2)
        {
            GameObject bullet2 = Instantiate(_bulletPrefab2, muzzle.position, _bulletPrefab2.transform.rotation);
        }
    }

    /// <summary>/// �v���[���[�̃p���[�A�b�v /// </summary>
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Rigidbody2D))] // Rigidbody コンポーネントのアタッチを強制する
public class Player : MonoBehaviour
{
    [SerializeField] SceneChanger _sceneChanger;

    [SerializeField] float m_moveSpeed = 5f;
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField] GameObject _bombPrefab;
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] Transform _Player;
    [SerializeField, Range(0, 1f)] float m_bulletLimit = 0;
    Rigidbody2D m_rb;
    [SerializeField] Text _powerText;

    //プレイヤーの強さ


    //弾の威力
    [SerializeField] float _bulletPower = 1f;
    public float BulletDamage => _bulletPower;


    //ボム表示
    [SerializeField] Text _bombText;
    int _bomb = 3;

    //残機表示
    [SerializeField] Text _lifeText;
    [SerializeField] int _life = 3;

    //無敵モード
    [SerializeField] bool _isCollision = true;

     float _Timer;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        _bulletPower = 1f;
    }

    void Update()
    {
        if (GameManager._instance.Wave < 5 && GameManager._instance.Wave >= 1)
        {
            // 自機を移動させる
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector2 dir = new Vector2(h, v).normalized;
            m_rb.velocity = dir * m_moveSpeed;


            if (Input.GetButton("Fire1"))
            {
                if (_Timer > m_bulletLimit)
                {
                    Fire1();
                    _Timer = 0;
                }
                else
                {
                    _Timer += Time.deltaTime;
                }
            }

            if(Input.GetMouseButtonDown(1) && _bomb != 0)
            {
                Instantiate(_bombPrefab, m_muzzle.position, _bombPrefab.transform.rotation);
                _bomb -= 1;
                _bombText.text = "Spell:" + _bomb.ToString("d2");
            }
        }
        else
        {
            m_rb.velocity = new Vector2 (0, 0);
        }

        if(_life <=0)
        {
            _sceneChanger.SceneChange("Title");
        }
    }
    void Fire1()
    {
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab にプレハブが設定されている時 かつ m_muzzle に弾の発射位置が設定されている時
        {
            GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);  // インスペクターから設定した m_bulletPrefab をインスタンス化する
            go.transform.SetParent(this.transform);
        }
    }

    /// <summary>/// プレーヤーのパワーアップ /// </summary>
    public void PowerUp(float powerUp)
    {
        if (_bulletPower >= 5f)
        {
            _bulletPower = 5f;
            _powerText.text = "Power:" + _bulletPower.ToString("f2");
        }
        else
        {
            _bulletPower += powerUp;
            _powerText.text = "Power:" + _bulletPower.ToString("f2");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !_isCollision)
        {
            _life -= 1;
            _lifeText.text = "Player:" + _life.ToString("d2");
        }
    }
}

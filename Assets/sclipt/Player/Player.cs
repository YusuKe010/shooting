using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))] // Rigidbody �R���|�[�l���g�̃A�^�b�`����������
public class Player : MonoBehaviour
{
    [SerializeField] SceneChanger _sceneChanger;

    [SerializeField] float m_moveSpeed = 5f;
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField] GameObject _bombGO;
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] Transform _Player;
    [SerializeField, Range(0, 1f)] float m_bulletLimit = 0;
    Rigidbody2D m_rb;

    //�v���C���[�̋���
    [SerializeField] float _bulletPower = 0.01f;
    public float BulletDamage => _bulletPower;


    //�{���\��
    [SerializeField] Text _bombText;
    int _bomb = 3;

    //�c�@�\��
    [SerializeField] Text _lifeText;
    [SerializeField] int _life = 3;

    //���G���[�h
    [SerializeField] bool _isCollision = true;

     float _Timer;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        _bulletPower = 0.01f;
    }

    void Update()
    {
        if (GameManager._instance.Wave < 5)
        {
            // ���@���ړ�������
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
                Instantiate(_bombGO, m_muzzle.position, _bombGO.transform.rotation);
                _bomb -= 1;
                _bombText.text = "Bomb:" + _bomb.ToString("d2");
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
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab �Ƀv���n�u���ݒ肳��Ă��鎞 ���� m_muzzle �ɒe�̔��ˈʒu���ݒ肳��Ă��鎞
        {
            GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);  // �C���X�y�N�^�[����ݒ肵�� m_bulletPrefab ���C���X�^���X������
            go.transform.SetParent(this.transform);
            
        }
    }
    public void PowerUp(float powerUp)
    {
        if (_bulletPower >= 5f)
        {
            _bulletPower = 5f;
        }
        else
        {
            _bulletPower += powerUp;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !_isCollision)
        {
            _life -= 1;
            _lifeText.text = "Player:" + _life.ToString("00");
        }
    }
}

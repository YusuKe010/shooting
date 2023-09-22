using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot1 : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] EnemyBullet m_bullet;

     float[] _timer = { 0, 0 };
    [SerializeField, Header("���ɏo��e�̊p�x")] float _Angle;
    [SerializeField, Header("���ɏo��e�̊Ԋu")] int[] _angle;

    [SerializeField] float[] _bulletLimit = {2.1f, 0.5f, 4f};
    [SerializeField] float _speed = 7f;
    public float BulletSpeed => _speed;
    void Start()
    {
        m_bullet.angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //--------�S���ʒe--------------------------------
        _timer[1] += Time.deltaTime;
        if (_timer[1] < _bulletLimit[0])
        {
            if (_timer[0] > _bulletLimit[1])
            {
                for (int i = 0; i < _angle[0]; i++)
                {
                    Fire1();
                    m_bullet.angle += _angle[1];
                }
                m_bullet.angle += _Angle;
                _timer[0] = 0;
            }
            else
            {
                _timer[0] += Time.deltaTime;
            }
        }
        else if (_timer[1] > _bulletLimit[2])
        {
            _timer[1] = 0;
        }
        //---------------------------------------------
    }
    void Fire1()
    {
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab �Ƀv���n�u���ݒ肳��Ă��鎞 ���� m_muzzle �ɒe�̔��ˈʒu���ݒ肳��Ă��鎞
        {
            GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);  // �C���X�y�N�^�[����ݒ肵�� m_bulletPrefab ���C���X�^���X������
            go.transform.position = this.transform.position;

        }
    }
}

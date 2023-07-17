using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] EnemyBullet m_bullet;

    float _Timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_Timer  > 1f)
        {
            for (int i = 0; i < 45; i++)
            {
                Fire1();
                m_bullet.angle += 8;
            }
            m_bullet.angle += 4f;
            _Timer = 0;
        }
        else
        {
            _Timer += Time.deltaTime;
        }
    }
    void Fire1()
    {
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab �Ƀv���n�u���ݒ肳��Ă��鎞 ���� m_muzzle �ɒe�̔��ˈʒu���ݒ肳��Ă��鎞
        {
            GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);  // �C���X�y�N�^�[����ݒ肵�� m_bulletPrefab ���C���X�^���X������
            go.transform.position =this.transform.position;

        }
    }
}

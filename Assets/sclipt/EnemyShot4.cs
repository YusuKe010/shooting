using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot4 : MonoBehaviour
{
    [SerializeField] GameObject[] m_bulletPrefab = null;
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] EnemyBullet4 m_bullet;
    [SerializeField] EnemyBullet4_2 m_bullet4_2;
    [SerializeField] float[] _timer;
    [SerializeField] int _angle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timer[1] += Time.deltaTime;
        if (_timer[1] < 2.1f)
        {
            if (_timer[0] > 0.5f)
            {

                
                for (int i = 0; i < 3; i++)
                {
                    Fir4();
                }
                _timer[0] = 0;
            }
            else
            {
                _timer[0] += Time.deltaTime;
            }
        }
        else if (_timer[1] > 4.0f)
        {
            _timer[1] = 0;
        }
    }
    void Fir4()
    {
        if (m_bulletPrefab[0] && m_muzzle)
        {
            GameObject go = Instantiate(m_bulletPrefab[0], m_muzzle.position, m_bulletPrefab[0].transform.rotation);
            GameObject go2 = Instantiate(m_bulletPrefab[1], m_muzzle.position, m_bulletPrefab[1].transform.rotation);
            go.transform.position = this.transform.position;

        }
    }
}

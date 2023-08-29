using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot4 : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] EnemyBullet4 m_bullet;
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
                Fir4();
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
        m_bullet._plusDegree = 0;
        GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);
        m_bullet._plusDegree = 6;
        GameObject go2 = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);
        m_bullet._plusDegree = -6;
        GameObject go3 = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);
        go.transform.position = this.transform.position;
        go2.transform.position = this.transform.position;
        go3.transform.position = this.transform.position;
    }
}

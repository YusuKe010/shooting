using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyShot3 : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] EnemyBullet3 m_bullet3;
    [SerializeField] float[] _bulletLimit = {4.0f, 0.5f, 4.1f};
    [SerializeField] float[] _Timer;


    void Update()
    {
        //---------‘S•ûˆÊ‰ñ“]’e-----------------------------------
        _Timer[0] += Time.deltaTime;
        if (_Timer[0] < _bulletLimit[0])
        {
            if (_Timer[1] > _bulletLimit[1])
            {
                Fire3();
                _Timer[1] = 0;
            }
            else
                _Timer[1] += Time.deltaTime;
        }
        else if (_Timer[0] > _bulletLimit[2])
        {
            m_bullet3._center = this.gameObject.transform.position;
            m_bullet3._axis *= -1.0f;
            _Timer[0] = 0;
        }
        //--------------------------------------
    }


    void Fire3()
    {
        GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);
    }

}

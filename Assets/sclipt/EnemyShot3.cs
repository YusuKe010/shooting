using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot3 : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] EnemyBullet3 m_bullet3;
    [SerializeField] float[] _Timer;
    [SerializeField] float[] _Random;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //---------‘S•ûˆÊ‰ñ“]’e-----------------------------------
        _Timer[0] += Time.deltaTime;
        if (_Timer[0] < 4.0f)
        {
            if (_Timer[1] > 0.5f)
            {
                Fire3();
                _Timer[1] = 0;
            }
            else
            {
                _Timer[1] += Time.deltaTime;
            }
        }
        else if (_Timer[0] > 4.1f)
        {
            _Random[0] = Random.Range(-3.0f, 3.0f);
            _Random[1] = Random.Range(-5.0f, 5.0f);
            m_bullet3._center = Vector3.right * _Random[0];
            m_bullet3._center = Vector3.up * _Random[1];
            //m_bullet3._center = this.gameObject.transform.position;   //Ž©•ª‚ÌŽü‚è‚ð‰ñ‚é‚Í‚¸
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

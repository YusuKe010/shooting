using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] GameObject[] m_bulletPrefab = null;
    [SerializeField] Transform[] m_muzzle = null;
    [SerializeField] EnemyBullet m_bullet;
    [SerializeField] EnemyBullet3 m_bullet3;
    [SerializeField] float[] _Timer;
    [SerializeField] float _Hp;
    [SerializeField] float[] _Random;

    // Start is called before the first frame update
    void Start()
    {
        m_bullet.angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //--------全方位弾--------------------------------
        _Timer[1] += Time.deltaTime;
        if (_Timer[1] < 2.1f)
        {
            if (_Timer[0] > 0.5f)
            {
                for (int i = 0; i < 45; i++)
                {
                    Fire1();
                    m_bullet.angle += 8;
                }
                m_bullet.angle += 2f;
                _Timer[0] = 0;
            }
            else
            {
                _Timer[0] += Time.deltaTime;
            }
        }
        else if (_Timer[1] > 4.0f)
        {
            _Timer[1] = 0;
        }
        //---------------------------------------------

        //------------ホーミング弾---------------------------
        if (_Timer[2] > 3f)
        {
            Fire2();
            _Timer[2] = 0;
        }
        else
        {
            _Timer[2] += Time.deltaTime;
        }
        //----------------------------------------

        ////---------全方位回転弾-----------------------------------
        //_Timer[4] += Time.deltaTime;
        //if (_Timer[4] < 4.0f)
        //{
        //    if (_Timer[3] > 0.5f)
        //    {
        //        Fire3();
        //        _Timer[3] = 0;
        //    }
        //    else
        //    {
        //        _Timer[3] += Time.deltaTime;
        //    }
        //}
        //else if (_Timer[4] > 4.1f)
        //{
        //    _Random[0] = Random.Range(-3.0f, 3.0f);
        //    _Random[1] = Random.Range(-5.0f, 5.0f);
        //    m_bullet3._center = Vector3.right * _Random[0];
        //    m_bullet3._center = Vector3.up * _Random[1];
        //    //m_bullet3._center = this.gameObject.transform.position;   //自分の周りを回るはず
        //    m_bullet3._axis *= -1.0f;
        //    _Timer[4] = 0;
        //}
        ////--------------------------------------
    }
    void Fire1()
    {
        if (m_bulletPrefab[0] && m_muzzle[0]) // m_bulletPrefab にプレハブが設定されている時 かつ m_muzzle に弾の発射位置が設定されている時
        {
            GameObject go = Instantiate(m_bulletPrefab[0], m_muzzle[0].position, m_bulletPrefab[0].transform.rotation);  // インスペクターから設定した m_bulletPrefab をインスタンス化する
            go.transform.position = this.transform.position;

        }
    }
    void Fire2()
    {
        for (int i = 1; i < m_muzzle.Length; i++)
        {
            GameObject go2 = Instantiate(m_bulletPrefab[1], m_muzzle[i].position, m_bulletPrefab[1].transform.rotation);
        }

    }
    void Fire3()
    {
        GameObject go = Instantiate(m_bulletPrefab[2], m_muzzle[0].position, m_bulletPrefab[2].transform.rotation);
    }

}

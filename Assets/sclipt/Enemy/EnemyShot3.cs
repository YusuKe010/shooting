using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyShot3 : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] EnemyBullet3 m_bullet3;
    [SerializeField] float[] _Timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //---------全方位回転弾-----------------------------------
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
            //一定の範囲を中心として回る
            m_bullet3._center = Vector3.right * Random.Range(gameObject.transform.position.x -3f, gameObject.transform.position.x + 3f);
            m_bullet3._center = Vector3.up * Random.Range(gameObject.transform.position.y -5f, gameObject.transform.position.y -10f);
            //m_bullet3._center = this.gameObject.transform.position;   //自分の周りを回るはず
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

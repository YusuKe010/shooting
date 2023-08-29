using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot1 : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] EnemyBullet m_bullet;

    [SerializeField, Header("一塊の弾の出る間隔、次の塊が出る間隔")] float[] _timer;
    [SerializeField, Header("次に出る弾の角度")] float _Angle;
    [SerializeField, Header("一回に出る弾の間隔")] int[] _angle;
    // Start is called before the first frame update
    void Start()
    {
        m_bullet.angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //--------全方位弾--------------------------------
        _timer[1] += Time.deltaTime;
        if (_timer[1] < 2.1f)
        {
            if (_timer[0] > 0.5f)
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
        else if (_timer[1] > 4.0f)
        {
            _timer[1] = 0;
        }
        //---------------------------------------------
    }
    void Fire1()
    {
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab にプレハブが設定されている時 かつ m_muzzle に弾の発射位置が設定されている時
        {
            GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);  // インスペクターから設定した m_bulletPrefab をインスタンス化する
            go.transform.position = this.transform.position;

        }
    }
}

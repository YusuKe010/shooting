using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShot2 : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField] Transform[] m_muzzle = null;
    [SerializeField] float[] _bulletLimit = { 2.2f, 0.7f, 4f};
    [SerializeField] float[] _Timer;
    [SerializeField] float _speed = 5f;
    public float BulletSpeed => _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //------------ホーミング弾---------------------------------------------------------------------------------------
        _Timer[0] += Time.deltaTime;
        if (_Timer[0] < _bulletLimit[0])
        {
            if (_Timer[1] > _bulletLimit[1])
            {
                Fire2();
                _Timer[1] = 0;
            }
            else
            {
                _Timer[1] += Time.deltaTime;
            }
        }
        else if (_Timer[0] > _bulletLimit[2])
        {
            _Timer[0] = 0;
        }
    }
    void Fire2()
    {
        foreach (Transform t in m_muzzle)
        {
            GameObject go2 = Instantiate(m_bulletPrefab, t.position, t.rotation);
        }
    }
    //--------------------------------------------------------------------------------------------------

}

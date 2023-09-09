using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot4 : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab = null;
    [SerializeField] Transform _muzzle = null;
    [SerializeField] EnemyBullet4 _bullet;
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
        _bullet._plusDegree = 0;
        GameObject go = Instantiate(_bulletPrefab, _muzzle.position, _bulletPrefab.transform.rotation);
        _bullet._plusDegree = 7;
        GameObject go2 = Instantiate(_bulletPrefab, _muzzle.position, _bulletPrefab.transform.rotation);
        _bullet._plusDegree = -7;
        GameObject go3 = Instantiate(_bulletPrefab, _muzzle.position, _bulletPrefab.transform.rotation);
        go.transform.position = this.transform.position;
        go2.transform.position = this.transform.position;
        go3.transform.position = this.transform.position;
    }
}

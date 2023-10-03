using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] GameObject _bullet = null;
    [SerializeField] Transform _muzzle = null;
    [SerializeField] GameObject _pool = null;

    public GameObject CreatObject()
    {
        return Instantiate(_bullet, _muzzle.position, _bullet.transform.rotation, _pool.transform);
    }
}

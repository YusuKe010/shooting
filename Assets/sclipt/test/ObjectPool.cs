using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] TestPlayer _testPlayer;
    public ObjectPool _pool;


    private void Awake()
    {
        //_pool = new ObjectPool<GameObject>(_testPlayer.CreatObject, GetFromPool, ReleasePool, DestroyPoolObj);

    }

    void GetFromPool(GameObject _bullet)
    {
        _bullet.SetActive(true);
    }

    void ReleasePool(GameObject _bullet)
    {
        _bullet.SetActive(false);
    }

    void DestroyPoolObj(GameObject _bullet)
    {
        Destroy(_bullet);
    }
}

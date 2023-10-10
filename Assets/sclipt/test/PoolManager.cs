using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    ObjectPool<GameObject> pool;
    [SerializeField] Transform _poolTra;

    private void Awake()
    {

    }


}

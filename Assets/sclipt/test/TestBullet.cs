using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    [SerializeField] ObjectPool _pool;

    public void GetFromPool()
    {
        gameObject.SetActive(true);
    }
}
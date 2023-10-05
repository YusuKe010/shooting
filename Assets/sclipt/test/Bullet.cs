using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float _bulletSpeed = 5;

    void Start()
    {
    }


    void Update()
    {
        transform.position += transform.up * _bulletSpeed * Time.deltaTime;
    }
}

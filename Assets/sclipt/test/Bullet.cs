using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D _rb;
    float _bulletSpeed = 5;
    Vector3 v;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        v = Vector3.up.normalized * _bulletSpeed;
        _rb.velocity = v;
    }

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = v;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector3 _direction = Vector2.up;

    float _bulletSpeed = 5;

    PoolManager _poolManager;
    public float _speed;

    void Start()
    {
        _poolManager = transform.GetComponent<PoolManager>();
        gameObject.SetActive(false);

        _rb = GetComponent<Rigidbody2D>();
        Vector3 v = _direction.normalized * _bulletSpeed; // �e����ԑ��x�x�N�g�����v�Z����
        _rb.velocity = v;      // ���x�x�N�g����e�ɃZ�b�g����
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * _bulletSpeed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        HideFromStage();
    }

    public void ShowInStage(Vector3 _pos)
    {
        transform.position = _pos;
    }

    public void HideFromStage()
    {
        _poolManager.Collect(this);
    }
}

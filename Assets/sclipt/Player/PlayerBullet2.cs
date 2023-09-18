using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet2 : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 5f;

    void Start()
    {
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        Vector2 v = (boss.transform.position - transform.position).normalized * _bulletSpeed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = v;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            Boss._instance.WeponHit(100);
            ScoreManager._instance.ScoreUp(100);
            Destroy(this.gameObject);
        }
    }
}

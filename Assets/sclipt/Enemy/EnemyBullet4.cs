using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet4 : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;
    Vector3 velocity;
    float Degree;
    public float _plusDegree;
    void Start()
    {
        // �p�x�����߂�
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 v = player.transform.position - this.transform.position;
        Degree = Mathf.Atan2(v.normalized.y, v.normalized.x);
        // ���x�x�N�g�����Z�b�g����
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        velocity.x = m_speed * Mathf.Cos(Degree + _plusDegree);
        velocity.y = m_speed * Mathf.Sin(Degree + _plusDegree);
        rb.velocity = new Vector2(velocity.x,velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Out"))
        {
            Destroy(this.gameObject);
        }
    }
}

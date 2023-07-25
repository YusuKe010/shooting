using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{
    //-------�z�[�~���O�e-----------------
    [SerializeField] float m_speed = 1f;

    void Start()
    {
        // ���x�x�N�g�������߂�
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 v = player.transform.position - this.transform.position;
        v = v.normalized * m_speed;
        // ���x�x�N�g�����Z�b�g����
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = v;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Out"))
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{
    //-------ホーミング弾-----------------
    [SerializeField] float m_speed = 1f;

    void Start()
    {
        // 速度ベクトルを求める
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 v = player.transform.position - this.transform.position;
        v = v.normalized * m_speed;

        // 速度ベクトルをセットする
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{
    //-------ホーミング弾-----------------
    [SerializeField] EnemyShot2 _enemyshot2;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 v = (player.transform.position - this.transform.position).normalized * _enemyshot2.BulletSpeed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = v;
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

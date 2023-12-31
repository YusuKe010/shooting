using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet2 : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] float _bulletSpeed = 5f;
    [SerializeField] GameObject _effct;

    void Start()
    {
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        Vector2 v = (boss.transform.position - transform.position).normalized * _bulletSpeed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = v;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            Boss._instance.WeponHit(_player.BulletDamage);
            ScoreManager._instance.ScoreUp(_player.BulletDamage);
            GameObject effect = Instantiate(_effct, transform.position, transform.rotation);
            Destroy(effect, 0.5f);
            Destroy(this.gameObject);
        }
    }
}

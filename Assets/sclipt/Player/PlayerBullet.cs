using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シューティングゲームで自機から発射される弾を制御するコンポーネント
/// 弾はインスタンス化されたら自ら飛んでいく
/// </summary>
[RequireComponent(typeof(Rigidbody2D))] // Rigidbody コンポーネントのアタッチを強制する
public class PlayerBullet : MonoBehaviour
{
    /// <summary>弾の発射方向</summary>
    [SerializeField] Vector2 _direction = Vector2.up;
    /// <summary>弾の飛ぶ速度</summary>
    [SerializeField] float m_bulletSpeed = 10f;
    Rigidbody2D m_rb;

    [SerializeField] Player _player;

    void Start()
    {
        
        m_rb = GetComponent<Rigidbody2D>();
        Vector3 v = _direction.normalized * m_bulletSpeed; // 弾が飛ぶ速度ベクトルを計算する
        m_rb.velocity = v;      // 速度ベクトルを弾にセットする
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Boss._instance.WeponHit(_player.BulletDamage);
            ScoreManager._instance.ScoreUp(_player.BulletDamage);
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Out")
        {
            Destroy(gameObject);
        }
    }
}

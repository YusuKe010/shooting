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
    [SerializeField] Vector2 _reftMove = Vector2.right;
    /// <summary>弾の飛ぶ速度</summary>
    [SerializeField] float m_bulletSpeed = 10f;
    Rigidbody2D m_rb;

    int _count;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Vector3 v = (_direction.normalized + _reftMove.normalized) * m_bulletSpeed; // 弾が飛ぶ速度ベクトルを計算する
        m_rb.velocity = v;                                  // 速度ベクトルを弾にセットする
    }
    private void Update()
    {
        
    }
}

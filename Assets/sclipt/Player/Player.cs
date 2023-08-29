using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))] // Rigidbody コンポーネントのアタッチを強制する
public class Player : MonoBehaviour
{
    /// <summary>プレイヤーの移動速度</summary>
    [SerializeField] float m_moveSpeed = 5f;
    /// <summary>弾のプレハブ</summary>
    [SerializeField] GameObject m_bulletPrefab = null;
    /// <summary>弾の発射位置</summary>
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] Transform _Player;
    /// <summary>一画面の最大段数 (0 = 無制限)</summary>
    [SerializeField, Range(0, 1f)] float m_bulletLimit = 0;
    Rigidbody2D m_rb;

    [SerializeField] int _life = 3;
     float _Timer;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 自機を移動させる
        float h = Input.GetAxisRaw("Horizontal");   
        float v = Input.GetAxisRaw("Vertical");     
        Vector2 dir = new Vector2(h, v).normalized;  
        m_rb.velocity = dir * m_moveSpeed;        

        if (Input.GetButton("Fire1") )
        {
            if (_Timer > m_bulletLimit)  
            {
                Fire1();
                _Timer = 0;
            }
            else
            {
                _Timer += Time.deltaTime;
            }
            
        }

        if(_life <=0)
        {
            SceneManager.LoadScene("Title");
        }
        
    }
    void Fire1()
    {
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab にプレハブが設定されている時 かつ m_muzzle に弾の発射位置が設定されている時
        {
            GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);  // インスペクターから設定した m_bulletPrefab をインスタンス化する
            go.transform.SetParent(this.transform);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _life -= 1;
        }
    }
}

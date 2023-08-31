using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �V���[�e�B���O�Q�[���Ŏ��@���甭�˂����e�𐧌䂷��R���|�[�l���g
/// �e�̓C���X�^���X�����ꂽ�玩����ł���
/// </summary>
[RequireComponent(typeof(Rigidbody2D))] // Rigidbody �R���|�[�l���g�̃A�^�b�`����������
public class PlayerBullet : MonoBehaviour
{

    [SerializeField] ScoreManager _scoreManager;
    /// <summary>�e�̔��˕���</summary>
    [SerializeField] Vector2 _direction = Vector2.up;
    /// <summary>�e�̔�ԑ��x</summary>
    [SerializeField] float m_bulletSpeed = 10f;
    Rigidbody2D m_rb;

    [SerializeField] float _bulletDamage = 10;
    public float BulletDamage => _bulletDamage;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Vector3 v = _direction.normalized * m_bulletSpeed; // �e����ԑ��x�x�N�g�����v�Z����
        m_rb.velocity = v;      // ���x�x�N�g����e�ɃZ�b�g����
    }

    public void PowerUp(float powerUp)
    {
        _bulletDamage += powerUp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Boss boss = collision.gameObject.GetComponent<Boss>();
            boss.WeponHit(_bulletDamage);
            _scoreManager.ScoreUp(100);
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
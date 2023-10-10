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
    /// <summary>�e�̔��˕���</summary>
    [SerializeField] Vector2 _direction = Vector2.up;
    /// <summary>�e�̔�ԑ��x</summary>
    [SerializeField] float m_bulletSpeed = 10f;
    Rigidbody2D m_rb;

    [SerializeField] Player _player;

    [SerializeField] GameObject _effect;

    Vector3 v;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        v = _direction.normalized * m_bulletSpeed; // �e����ԑ��x�x�N�g�����v�Z����
        m_rb.velocity = v;      // ���x�x�N�g����e�ɃZ�b�g����
    }

    private void OnEnable()
    {
        m_rb.velocity = v;
    }

    private void OnDisable()
    {
        v = m_rb.velocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Boss._instance.WeponHit(_player.BulletDamage);
            ScoreManager._instance.ScoreUp(_player.BulletDamage);
            GameObject effect = Instantiate(_effect, transform.position, transform.rotation);
            Destroy(effect, 0.5f);
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

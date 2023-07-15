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
    [SerializeField] Vector2 _reftMove = Vector2.right;
    /// <summary>�e�̔�ԑ��x</summary>
    [SerializeField] float m_bulletSpeed = 10f;
    Rigidbody2D m_rb;

    int _count;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Vector3 v = (_direction.normalized + _reftMove.normalized) * m_bulletSpeed; // �e����ԑ��x�x�N�g�����v�Z����
        m_rb.velocity = v;                                  // ���x�x�N�g����e�ɃZ�b�g����
    }
    private void Update()
    {
        
    }
}

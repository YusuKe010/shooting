using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �V���[�e�B���O�Q�[���Ŏ��@���甭�˂����e�𐧌䂷��R���|�[�l���g
/// �e�̓C���X�^���X�����ꂽ�玩����ł���
/// </summary>
[RequireComponent(typeof(Rigidbody2D))] // Rigidbody �R���|�[�l���g�̃A�^�b�`����������
public class Bullet : MonoBehaviour
{
    /// <summary>�e�̔��˕���</summary>
    [SerializeField] Vector2 m_direction = Vector2.up;
    /// <summary>�e�̔�ԑ��x</summary>
    [SerializeField] float m_bulletSpeed = 10f;
    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Vector3 v = m_direction.normalized * m_bulletSpeed; // �e����ԑ��x�x�N�g�����v�Z����
        m_rb.velocity = v;                                  // ���x�x�N�g����e�ɃZ�b�g����
    }
}

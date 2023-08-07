using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �V���[�e�B���O�Q�[���̎��@�𑀍삷�邽�߂̃R���|�[�l���g
/// </summary>
[RequireComponent(typeof(Rigidbody2D))] // Rigidbody �R���|�[�l���g�̃A�^�b�`����������
public class Player : MonoBehaviour
{
    /// <summary>�v���C���[�̈ړ����x</summary>
    [SerializeField] float m_moveSpeed = 5f;
    /// <summary>�e�̃v���n�u</summary>
    [SerializeField] GameObject m_bulletPrefab = null;
    /// <summary>�e�̔��ˈʒu</summary>
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] Transform _Player;
    /// <summary>���ʂ̍ő�i�� (0 = ������)</summary>
    [SerializeField, Range(0, 10)] int m_bulletLimit = 0;
    Rigidbody2D m_rb;

    float _Timer;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���@���ړ�������
        float h = Input.GetAxisRaw("Horizontal");   // ���������̓��͂��擾����
        float v = Input.GetAxisRaw("Vertical");     // ���������̓��͂��擾����
        Vector2 dir = new Vector2(h, v).normalized; // �i�s�����̒P�ʃx�N�g������� (dir = direction) 
        m_rb.velocity = dir * m_moveSpeed;        // �P�ʃx�N�g���ɃX�s�[�h�������đ��x�x�N�g���ɂ��āA����� Rigidbody �̑��x�x�N�g���Ƃ��ăZ�b�g����

        // ���N���b�N�܂��͍� Ctrl �Œe��
        // �˂���i�P���j
        if (Input.GetButton("Fire1") )
        {
            if (_Timer > 0.15f)    // ��ʓ��̒e���𐧌�����
            {
                Fire1();
                _Timer = 0;
            }
            else
            {
                _Timer += Time.deltaTime;
            }
            
        }
        
    }

    /// <summary>
    /// �e�𔭎˂���
    /// </summary>
    void Fire1()
    {
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab �Ƀv���n�u���ݒ肳��Ă��鎞 ���� m_muzzle �ɒe�̔��ˈʒu���ݒ肳��Ă��鎞
        {
            GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);  // �C���X�y�N�^�[����ݒ肵�� m_bulletPrefab ���C���X�^���X������
            go.transform.SetParent(this.transform);
            
        }
    }
}

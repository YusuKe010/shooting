using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // ���@���ړ�������
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
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab �Ƀv���n�u���ݒ肳��Ă��鎞 ���� m_muzzle �ɒe�̔��ˈʒu���ݒ肳��Ă��鎞
        {
            GameObject go = Instantiate(m_bulletPrefab, m_muzzle.position, m_bulletPrefab.transform.rotation);  // �C���X�y�N�^�[����ݒ肵�� m_bulletPrefab ���C���X�^���X������
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

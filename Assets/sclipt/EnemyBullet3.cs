using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet3 : MonoBehaviour
{
    //-------------�S���ʉ�]�e--------------------------------------
    // ���S�_
    [SerializeField] public Vector3 _center = Vector3.zero;
    // ��]��
    [SerializeField] public Vector3 _axis = Vector3.up;
    // �~�^������
    [SerializeField] private float _period = 2;
    [SerializeField] float _DownSpeed = -1.0f;
    private void Update()
    {
        // ���S�_center�̎�����A��axis�ŁAperiod�����ŉ~�^��
        transform.RotateAround(_center,_axis,360 / _period * Time.deltaTime);
        transform.Translate(0f,_DownSpeed,0f);
        Destroy(gameObject,12.0f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Out")
        {
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //-------�S���ʒe---------------------
    public float angle = 90;
    [SerializeField] float _speed = -5f;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        //�x�N�g���v�Z
        velocity.x = _speed * Mathf.Cos(angle * Mathf.Deg2Rad);
        velocity.y = _speed * Mathf.Sin(angle * Mathf.Deg2Rad);
        //�p�x�v�Z
        float zAngle = Mathf.Atan2(velocity.y,velocity.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(0,0,zAngle);
    }

    void Update()
    {
        //velocity��ς���ƒe���x�������̂ŁA�^�C�}�[�������Ă���
        this.transform.position += velocity * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Out")
        {
            Destroy(gameObject);
        }
    }
}

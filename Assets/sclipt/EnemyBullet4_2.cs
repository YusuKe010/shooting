using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet4_2 : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;
    [SerializeField] public float _plusDegree = 6;
    Vector3 velocity;

    float Degree;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 v = player.transform.position - this.transform.position;
        Degree = Mathf.Atan2(v.normalized.y, v.normalized.x);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        velocity.x = m_speed * Mathf.Cos(Degree + _plusDegree);
        velocity.y = m_speed * Mathf.Sin(Degree + _plusDegree);
        rb.velocity = new Vector2(velocity.x, velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Out"))
        {
            Destroy(this.gameObject);
        }
    }
}

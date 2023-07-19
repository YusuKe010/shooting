using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet3 : MonoBehaviour
{
    //-------------‘S•ûˆÊ‰ñ“]’e--------------------------------------
    // ’†S“_
    [SerializeField] public Vector3 _center = Vector3.zero;
    // ‰ñ“]²
    [SerializeField] public Vector3 _axis = Vector3.up;
    // ‰~‰^“®üŠú
    [SerializeField] private float _period = 2;
    [SerializeField] float _DownSpeed = -1.0f;
    private void Update()
    {
        // ’†S“_center‚Ìü‚è‚ğA²axis‚ÅAperiodüŠú‚Å‰~‰^“®
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

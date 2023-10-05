using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    [SerializeField] TestPlayer _player;

    private void Start()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Out"))
        {
            _player.pool.Release(this.gameObject);
        }
    }
}
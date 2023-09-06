using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [SerializeField] PlayerBullet _playerBullet;
    [SerializeField] ScoreManager _scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerBullet.PowerUp(0.2f);
            _scoreManager.ScoreUp(1000);
            Destroy(gameObject);
        }
    }
}

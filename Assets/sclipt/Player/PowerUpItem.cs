using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
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
            Player player = FindAnyObjectByType<Player>();
            player.PowerUp(0.2f);
            ScoreManager._instance.ScoreUp(1000);
            Destroy(gameObject);
        }
    }
}

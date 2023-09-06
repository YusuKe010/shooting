using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public static Boss _instance;

    EnemyShot1 enemyShot1;
    EnemyShot2 enemyShot2;
    EnemyShot3 enemyShot3;
    EnemyShot4 enemyShot4;

    [SerializeField] Scrollbar _hpBer;
    [SerializeField] GameObject _powerUpItem;
    [SerializeField] Transform[] _muzle;

    float _maxBossHp = 0;
    [SerializeField] public float _bossHp = 5000;
    public float BossHp => _bossHp;
    int _saveWave;

    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        _maxBossHp = _bossHp;
        enemyShot1 = GetComponent<EnemyShot1>();
        enemyShot2 = GetComponent<EnemyShot2>();
        enemyShot3 = GetComponent<EnemyShot3>();
        enemyShot4 = GetComponent<EnemyShot4>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._instance.Wave != _saveWave)
        {
            for(int i = 0; i < _muzle.Length; i++) 
            {
                Instantiate(_powerUpItem, _muzle[i].position, _powerUpItem.transform.rotation);
            }
            _bossHp = 10000;
            _saveWave++;
        }

        if (GameManager._instance.Wave == 1)
        {
            enemyShot1.enabled = true;
            enemyShot2.enabled = false;
            enemyShot3.enabled = false;
            enemyShot4.enabled = true;
        }
        if (GameManager._instance.Wave == 2)
        {
            enemyShot1.enabled = false;
            enemyShot2.enabled = false;
            enemyShot3.enabled = true;
            enemyShot4.enabled = true;
        }
        if (GameManager._instance.Wave == 3)
        {
            enemyShot1.enabled = false;
            enemyShot2.enabled = false;
            enemyShot3.enabled = true;
            enemyShot4.enabled = true;
        }
        if (GameManager._instance.Wave == 4)
        {
            enemyShot1.enabled = true;
            enemyShot2.enabled = true;
            enemyShot3.enabled = false;
            enemyShot4.enabled = false;
        }
        if(GameManager._instance.Wave == 5)
        {
            enemyShot1.enabled = false;
            enemyShot2.enabled = false;
            enemyShot3.enabled = false;
            enemyShot4.enabled = false;
        }



    }
    public void WeponHit(float Damage)
    {
        Scrollbar scrollbar = _hpBer;
        _bossHp -= Damage;
        scrollbar.size = _bossHp / _maxBossHp;
    }
}

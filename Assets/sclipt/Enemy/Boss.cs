using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public static Boss _instance;

    Animator animator;
    EnemyShot1 enemyShot1;
    EnemyShot2 enemyShot2;
    EnemyShot3 enemyShot3;
    EnemyShot4 enemyShot4;

    [SerializeField] Scrollbar _hpBer;
    [SerializeField] GameObject _powerUpItem;
    [SerializeField] Transform _muzle;

    float _maxBossHp = 0;
    [SerializeField] public float _bossHp = 5000;
    public float BossHp => _bossHp;
    int _saveWave;

    [SerializeField] int _waveCount;

    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        _maxBossHp = _bossHp;
        animator = GetComponent<Animator>();
        enemyShot1 = GetComponent<EnemyShot1>();
        enemyShot2 = GetComponent<EnemyShot2>();
        enemyShot3 = GetComponent<EnemyShot3>();
        enemyShot4 = GetComponent<EnemyShot4>();

        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._instance.Wave != _saveWave && GameManager._instance.Wave < 5 )
        {
            if(GameManager._instance.Wave > 1 )
            {
                for(int i = 0; i < 15; i++)
                {
                    Vector2 v = new Vector2(gameObject.transform.position.x + Random.Range(-6f, 6f), gameObject.transform.position.y + Random.Range(-6f, 6f));
                    Instantiate(_powerUpItem, v, _powerUpItem.transform.rotation);
                }
            }
            animator.enabled = true;
            _bossHp = _maxBossHp;
            _saveWave++;
            _waveCount = Random.Range(1, 5);
        }

        if (_waveCount ==1)
        {
            enemyShot1.enabled = true;
            enemyShot2.enabled = false;
            enemyShot3.enabled = false;
            enemyShot4.enabled = true;
        }
        else if ( _waveCount == 2)
        {
            enemyShot1.enabled = false;
            enemyShot2.enabled = true;
            enemyShot3.enabled = true;
            enemyShot4.enabled = false;
        }
        else if (_waveCount == 3)
        {
            enemyShot1.enabled = false;
            enemyShot2.enabled = false;
            enemyShot3.enabled = true;
            enemyShot4.enabled = true;
        }
        else if (_waveCount == 4)
        {
            enemyShot1.enabled = true;
            enemyShot2.enabled = true;
            enemyShot3.enabled = false;
            enemyShot4.enabled = false;
        }
        if(GameManager._instance.Wave >= 5)
        {
            gameObject.SetActive(false);
        }
        if(Player._instance.Life <= 0)
        {
            enemyShot1.enabled = false;
            enemyShot2.enabled = false;
            enemyShot3.enabled = false;
            enemyShot4.enabled = false;
            animator.enabled = false;
        }
    }

    /// <summary>///ボスが受けるダメージ /// </summary>
    public void WeponHit(int Damage)
    {
        Scrollbar scrollbar = _hpBer;
        _bossHp -= Damage;
        scrollbar.size = _bossHp / _maxBossHp;
    }
}

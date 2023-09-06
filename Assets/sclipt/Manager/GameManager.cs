using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;

    [SerializeField] PlayerBullet _playerBullet;
    [SerializeField] SceneChanger _changer;
    [SerializeField,Header("0:プレイヤー弾の威力")] Text _text;
    [SerializeField] ScoreManager _scoreManager;


    //ウェーブ
    [SerializeField] int _wave;
    public int Wave => _wave;

    float _saveBulletDamage;

    private void Awake()
    {
        _instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Boss._instance.BossHp <= 0)
        {
            _scoreManager.ScoreUp(10000);
            _wave++;
            GameObject[] gameObject = GameObject.FindGameObjectsWithTag("Bullet");
            foreach(GameObject a in gameObject)
            {
                Destroy(a);
            }
        }

        if (_wave >= 5)
        {
            
            //_changer.SceneChange("GameClear");
        }
        
        if(_playerBullet.BulletDamage != _saveBulletDamage)
        {
            _saveBulletDamage = _playerBullet.BulletDamage;
            _text.text = "Power:" + _saveBulletDamage.ToString("F2");
        }
        
    }

}

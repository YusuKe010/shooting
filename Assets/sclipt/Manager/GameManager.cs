using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //他のスクリプトでメソッドを使うため
    public static GameManager _instance = null;

    [SerializeField] PlayerBullet _playerBullet;
    [SerializeField] SceneChanger _changer; 
    [SerializeField,Header("0:プレイヤー弾の威力")] Text _text; //自機の強さを表示する

    //ウェーブの管理
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
        //ボスのHPがゼロになった時の処理
        if (Boss._instance.BossHp <= 0)
        {
            //スコアアップして、ウェーブを進める
            //ScoreManager._instance.ScoreUp(100000);
            _wave++;

            //ウェーブが進んだらボスの弾を消す
            GameObject[] gameObject = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject a in gameObject)
            {
                Destroy(a);
            }
        }

        

        //自機の強さが変わった時の処理
        if(_playerBullet.BulletDamage != _saveBulletDamage)
        {
            //自機の強さを保存してテキスト表示
            _saveBulletDamage = _playerBullet.BulletDamage;
            _text.text = "Power:" + _saveBulletDamage.ToString("F2");
        }
        
    }

}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //他のスクリプトでメソッドを使うため
    public static GameManager _instance = null;

    [SerializeField] Player _player;
    [SerializeField] SceneChanger _changer; 
    [SerializeField,Header("0:プレイヤー弾の威力")] Text _text; //自機の強さを表示する
    [SerializeField] GameObject _startPanel;
    [SerializeField] GameObject _fadePanel;
    [SerializeField] CanvasGroup _fadePanelGroup;

    public bool _isStart;

    //ウェーブの管理
    [SerializeField] int _wave;
    public int Wave => _wave;

    //[SerializeField] float _saveBulletDamage;

    private void Awake()
    {
        _instance = this;
        _startPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -500, 0);
    }
    void Start()
    {
        _wave = 0;
        _startPanel.SetActive(true);
        _fadePanel.SetActive(true);
        _fadePanelGroup.DOFade(0f,1.5f).SetEase(Ease.InQuad) .OnComplete(() => 
        {
            _fadePanel.SetActive(false);
            _startPanel.GetComponent<RectTransform>().DOAnchorPosY(0f, 2f).SetEase(Ease.OutQuart);
        });
    }

    void Update()
    {
        //ボスのHPがゼロになった時の処理
        if (Boss._instance.BossHp <= 0 && _wave < 5 && _wave >= 1)
        {
            //スコアアップして、ウェーブを進める
            ScoreManager._instance.ScoreUp(100000);
            _wave++;

            //ウェーブが進んだらボスの弾を消す
            GameObject[] gameObject = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject a in gameObject)
            {
                Destroy(a);
            }
        }


        if(_isStart)
        {
            _wave++;
            _isStart = false;
        }

        if(_wave >= 5)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("PlayerBullet");
            foreach (GameObject a in gameObjects)
            {
                Destroy(a);
            }
        }
    }

    public void GameStart(GameObject panel)
    {
        panel.SetActive(false);
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager._isStart = true;
    }

}

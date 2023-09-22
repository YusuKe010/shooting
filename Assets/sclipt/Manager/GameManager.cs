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

    [SerializeField] GameObject _startPanel; //操作説明パネル
    [SerializeField] GameObject _gameOverPanel; //ゲームオーバー画面

    //フェードパネル
    [SerializeField] GameObject _fadePanel;
    [SerializeField] CanvasGroup _fadeCanvasGroup;

    public bool _isStart;

    //ウェーブの管理
    [SerializeField] int _wave;
    public int Wave => _wave;


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
        _gameOverPanel.SetActive(false);
        _gameOverPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -500);
        _fadeCanvasGroup.alpha = 1.0f;
        //フェードアウトのあと、操作パネルを出す
        _fadeCanvasGroup.DOFade(0f,1.5f).SetEase(Ease.InQuad) .OnComplete(() => 
        {
            _fadePanel.SetActive(false);
            _startPanel.GetComponent<RectTransform>().DOAnchorPosY(0f, 2f).SetEase(Ease.OutQuart);
        }).SetLink(gameObject);
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

        if(Player._instance.Life <= 0)
        {
            _gameOverPanel.SetActive(true);
            _gameOverPanel.GetComponent<RectTransform>().DOAnchorPosY(0, 2f).SetLink(gameObject);
            _wave = 0;
        }
    }

    public void GameStart(GameObject panel)
    {
        panel.SetActive(false);
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager._isStart = true;
    }
}

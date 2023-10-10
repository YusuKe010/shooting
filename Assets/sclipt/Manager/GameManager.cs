using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

enum WaveCounter
{
    gameStart,
    wave1,
    wave2,
    wave3,
    wave4,
    gameEnd
}

public class GameManager : MonoBehaviour
{
    

    //���̃X�N���v�g�Ń��\�b�h���g������
    public static GameManager _instance = null;

    [SerializeField] Player _player;
    [SerializeField] SceneChanger _changer; 
    [SerializeField,Header("0:�v���C���[�e�̈З�")] Text _text; //���@�̋�����\������

    [SerializeField] GameObject _startPanel; //��������p�l��
    [SerializeField] GameObject _gameOverPanel; //�Q�[���I�[�o�[���

    //�t�F�[�h�p�l��
    [SerializeField] GameObject _fadePanel;
    [SerializeField] CanvasGroup _fadeCanvasGroup;

    public bool _isStart;

    //�E�F�[�u�̊Ǘ�
    [SerializeField] int _wave;
    public int Wave => _wave;

    //�G�t�F�N�g
    [SerializeField] GameObject _effect;
    [SerializeField] GameObject _effect2;
    bool _isEffect = true;
    bool _isEffect2 = true;

    WaveCounter nowWave = 0;


    private void Awake()
    {
        _instance = this;
        _startPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -500, 0);
    }
    void Start()
    {
        nowWave = WaveCounter.gameStart;
        _wave = 0;
        _startPanel.SetActive(true);
        _fadePanel.SetActive(true);
        _gameOverPanel.SetActive(false);
        _gameOverPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -500);
        _fadeCanvasGroup.alpha = 1.0f;
        //�t�F�[�h�A�E�g�̂��ƁA����p�l�����o��
        _fadeCanvasGroup.DOFade(0f,1.5f).SetEase(Ease.InQuad) .OnComplete(() => 
        {
            _fadePanel.SetActive(false);
            _startPanel.GetComponent<RectTransform>().DOAnchorPosY(0f, 2f).SetEase(Ease.OutQuart);
        }).SetLink(gameObject);
    }

    void Update()
    {
        //�{�X��HP���[���ɂȂ������̏���
        if (Boss._instance.BossHp <= 0 && _wave < 5 && _wave >= 1)
        {
            //�X�R�A�A�b�v���āA�E�F�[�u��i�߂�
            ScoreManager._instance.ScoreUp(100000);
            _wave++;

            //�E�F�[�u���i�񂾂�{�X�̒e������
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
            if (_isEffect)
            {
                GameObject effect = Instantiate(_effect);
                _isEffect = false;
            }
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("PlayerBullet");
            foreach (GameObject a in gameObjects)
            {
                Destroy(a);
            }
        }

        if(Player._instance.Life <= 0 && _isEffect2)
        {
            _gameOverPanel.SetActive(true);
            _gameOverPanel.GetComponent<RectTransform>().DOAnchorPosY(0, 2f).SetLink(gameObject);
            Instantiate(_effect2);
            _wave = 0;
            _isEffect2 = false;
        }
    }

    public void GameStart(GameObject panel)
    {
        panel.SetActive(false);
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager._isStart = true;
    }

    void GameOver()
    {

    }

    void GameClear()
    {

    }
}

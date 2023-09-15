using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //���̃X�N���v�g�Ń��\�b�h���g������
    public static GameManager _instance = null;

    [SerializeField] Player _player;
    [SerializeField] SceneChanger _changer; 
    [SerializeField,Header("0:�v���C���[�e�̈З�")] Text _text; //���@�̋�����\������
    [SerializeField] GameObject _startPanel;
    [SerializeField] GameObject _fadePanel;
    [SerializeField] CanvasGroup _fadePanelGroup;

    public bool _isStart;

    //�E�F�[�u�̊Ǘ�
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

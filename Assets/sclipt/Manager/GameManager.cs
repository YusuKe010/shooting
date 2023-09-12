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

    public bool _isStart;

    //�E�F�[�u�̊Ǘ�
    [SerializeField] int _wave;
    public int Wave => _wave;

    //[SerializeField] float _saveBulletDamage;

    private void Awake()
    {
        _instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        _wave = 0;
        _startPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //�{�X��HP���[���ɂȂ������̏���
        if (Boss._instance.BossHp <= 0 && _wave < 5)
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

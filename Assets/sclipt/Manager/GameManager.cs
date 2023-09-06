using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //���̃X�N���v�g�Ń��\�b�h���g������
    public static GameManager _instance = null;

    [SerializeField] PlayerBullet _playerBullet;
    [SerializeField] SceneChanger _changer; 
    [SerializeField,Header("0:�v���C���[�e�̈З�")] Text _text; //���@�̋�����\������

    //�E�F�[�u�̊Ǘ�
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
        //�{�X��HP���[���ɂȂ������̏���
        if (Boss._instance.BossHp <= 0)
        {
            //�X�R�A�A�b�v���āA�E�F�[�u��i�߂�
            //ScoreManager._instance.ScoreUp(100000);
            _wave++;

            //�E�F�[�u���i�񂾂�{�X�̒e������
            GameObject[] gameObject = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject a in gameObject)
            {
                Destroy(a);
            }
        }

        

        //���@�̋������ς�������̏���
        if(_playerBullet.BulletDamage != _saveBulletDamage)
        {
            //���@�̋�����ۑ����ăe�L�X�g�\��
            _saveBulletDamage = _playerBullet.BulletDamage;
            _text.text = "Power:" + _saveBulletDamage.ToString("F2");
        }
        
    }

}

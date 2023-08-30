using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;

    [SerializeField] SceneChanger _changer;
    ScoreManager _scoreManager;

    [SerializeField] int _wave;
    public int Wave => _wave;
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
        }

        if (_wave >= 5)
        {
            _changer.SceneChange("GameClear");
        }
        
    }

}

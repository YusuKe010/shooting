using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] Text _scoreText;
    [SerializeField] float _score = 0;
    float _saveScore;

    [SerializeField] float _timer;

    //ゲームクリアパネル
    [SerializeField] GameObject _gameClearPnanel;
    [SerializeField] Text _clearScoreText;
    [SerializeField] Text _timerText;

    // Start is called before the first frame update
    void Start()
    {
        _gameClearPnanel.SetActive(false);
        _score = 0;
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager._instance.Wave < 5)
        {
            _timer += Time.deltaTime;

        }
        if (GameManager._instance.Wave >= 5)
        {
            _gameClearPnanel.SetActive(true);
            _clearScoreText.text = "スコア：" + _score.ToString("F0");
            _timerText.text = "撃破時間：" + _timer.ToString("F2");
        }
    }
    public void ScoreUp(float upScore)
    {
        Text scoreText = _scoreText;
        _score += upScore;
        scoreText.text = "Score:" + _score.ToString("0000000000");
    }
}

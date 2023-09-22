using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager _instance;

    [SerializeField] Text _scoreText;
    [SerializeField] int _score = 0;
    [SerializeField] float _scoreChangeInterval = 0.5f;
    float _saveScore;

    [SerializeField] float _timer;

    //ゲームクリアパネル
    [SerializeField] GameObject _gameClearPnanel;
    [SerializeField] Text _clearScoreText;
    [SerializeField] Text _timerText;
    [SerializeField] 

    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _gameClearPnanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -200);
        _gameClearPnanel.SetActive(false);
        _score = 0;
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager._instance.Wave < 5 && GameManager._instance.Wave >= 1)
        {
            _timer += Time.deltaTime;

        }
        if (GameManager._instance.Wave >= 5)
        {
            _gameClearPnanel.SetActive(true);
            _clearScoreText.text = "スコア：" + _score.ToString("F0");
            _timerText.text = "撃破時間：" + _timer.ToString("F2");
            _gameClearPnanel.GetComponent<RectTransform>().DOAnchorPosY(0f, 2f).SetEase(Ease.OutQuart).SetLink(gameObject);
        }
    }

    /// <summary>
    /// スコアアップ時
    /// </summary>
    /// <param name="upScore"></param>
    public void ScoreUp(int upScore)
    {
        int tempScore = _score;
        Text scoreText = _scoreText;
        _score += upScore;
        //scoreText.text = "Score:" + _score.ToString("0000000000");
        DOTween.To(() => tempScore, x =>
        {
            tempScore = x;
            _scoreText.text = "Score:" + _score.ToString("d10");
        }, _score, _scoreChangeInterval).OnComplete(() => _scoreText.text = "Score:" + _score.ToString("d10")).SetLink(gameObject) ;
    }
}

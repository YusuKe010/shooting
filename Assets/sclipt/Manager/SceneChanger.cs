using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    //フェード
    [SerializeField] GameObject _fadepanel;
    [SerializeField] CanvasGroup _fadeCanvasGroup;

    public void SceneChange(string sceneName)
    {
        StartCoroutine(Fade(sceneName));
    }

    //パネル消す(左矢印用)
    public void LeftPanelDelete(GameObject nowPanel)
    {
        nowPanel.GetComponent<RectTransform>().DOAnchorPosX(-800, 1.7f).OnComplete(() => nowPanel.SetActive(false)).SetLink(gameObject);
    }

    //パネル出す(左矢印用)
    public void LeftPanel(GameObject panel)
    {
        panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(800, 0);
        panel.SetActive(true);
        panel.GetComponent<RectTransform>().DOAnchorPosX(0, 1.7f).SetLink(gameObject);
    }

    //パネル消す(右矢印用)
    public void RightPanelDelete(GameObject nowPanel)
    {
        nowPanel.GetComponent<RectTransform>().DOAnchorPosX(800, 1.7f).OnComplete(() => nowPanel.SetActive(false)).SetLink(gameObject);
    }

    //パネル出す(右矢印用)
    public void RightPanel(GameObject panel)
    {
        panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-800, 0);
        panel.SetActive(true);
        panel.GetComponent<RectTransform>().DOAnchorPosX(0, 1.7f).SetLink(gameObject);
    }

    //フェードアウト
    IEnumerator Fade(string sceneName)
    {
        _fadepanel.SetActive(true);
        _fadeCanvasGroup.alpha = 0f;
        _fadeCanvasGroup.DOFade(1f, 1.5f).SetEase(Ease.InQuart).SetLink(gameObject);
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene(sceneName);
    }

}

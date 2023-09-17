using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    //�t�F�[�h
    [SerializeField] GameObject _fadepanel;
    [SerializeField] CanvasGroup _fadeCanvasGroup;

    //�X���C�h�p�l��
    [SerializeField] GameObject _tutorialPanel;
    [SerializeField] GameObject _hardPanel;

    public void SceneChange(string sceneName)
    {
        StartCoroutine(Fade(sceneName));
    }

    //�p�l������(�����p)
    public void LeftPanelDelete(GameObject nowPanel)
    {
        nowPanel.GetComponent<RectTransform>().DOAnchorPosX(-800, 3f).OnComplete(() => nowPanel.SetActive(false));
    }

    //�p�l���o��(�����p)
    public void LeftPanel(GameObject panel)
    {
        panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(800, 0);
        panel.SetActive(true);
        panel.GetComponent<RectTransform>().DOAnchorPosX(0, 3f);
    }

    //�p�l������(�E���p)
    public void RightPanelDelete(GameObject nowPanel)
    {
        nowPanel.GetComponent<RectTransform>().DOAnchorPosX(800, 3f).OnComplete(() => nowPanel.SetActive(false));
    }

    //�p�l���o��(�E���p)
    public void RightPanel(GameObject panel)
    {
        panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-800, 0);
        panel.SetActive(true);
        panel.GetComponent<RectTransform>().DOAnchorPosX(0, 3f);
    }

    //�t�F�[�h�A�E�g
    IEnumerator Fade(string sceneName)
    {
        _fadepanel.SetActive(true);
        _fadeCanvasGroup.alpha = 0f;
        _fadeCanvasGroup.DOFade(1f, 1.5f).SetEase(Ease.InQuart);
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene(sceneName);
    }

}

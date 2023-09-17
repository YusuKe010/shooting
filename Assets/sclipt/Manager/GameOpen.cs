using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOpen : MonoBehaviour
{
    [SerializeField] GameObject _fadePanel;
    [SerializeField] CanvasGroup _fadeGroup;

    void Start()
    {
        _fadePanel.SetActive(true);
        _fadeGroup.alpha = 1.0f;
        _fadeGroup.DOFade(0f, 1.5f).OnComplete(() => { _fadePanel.SetActive(false); });
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;
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
            _wave++;
        }

        if (_wave >= 5)
        {
            SceneManager.LoadScene("GameClear");
        }
        
    }
}

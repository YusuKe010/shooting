using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField, Header("ボールのスピード")] float _ballSpead;
    [SerializeField] cannon _cannon;

    Vector3 _startPos;
    float _nowPos;
    int _random;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = this.transform.position;
        _random = Random.Range(0, _cannon.BallPoint.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(_startPos, _cannon.BallPoint[_random].position, _nowPos);
        Debug.Log(_cannon.BallPoint[_random].position);
        _nowPos += Time.deltaTime;
        _nowPos = Mathf.Clamp01(_nowPos);
    }
}

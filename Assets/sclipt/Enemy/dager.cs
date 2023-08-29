using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dager : MonoBehaviour
{
    [SerializeField] Transform[] _DagerPosition;
    [SerializeField] GameObject _Dager;

    [SerializeField] float[] _Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Timer[0] += Time.deltaTime;
        if (_Timer[0] < 1.2f)
        {
            if (_Timer[1]  > 0.3f)
            {
                for (int i = 0; i < _DagerPosition.Length; i++)
                {
                    Instantiate(_Dager, _DagerPosition[i].position, _Dager.transform.rotation);
                }
                _Timer[1] = 0f;
            }
            else
            {
                _Timer[1] += Time.deltaTime;
            }
            
        }
        else if (_Timer[0] > 3f)
        {
            _Timer[0] = 0f;
        }

    }
}

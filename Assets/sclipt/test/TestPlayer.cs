using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] GameObject _bullet = null;
    [SerializeField] Transform _muzzle = null;
    public ObjectPool<GameObject> pool;

    [SerializeField] float _timer;
    [SerializeField] float _interval = 0.1f;
    [SerializeField] int _maxBulletCount = 10;
    [SerializeField] Transform _poolPosition;

    private void Awake()
    {
         pool = new ObjectPool<GameObject>(
         () => Instantiate(_bullet, _muzzle.position, _bullet.transform.rotation, transform),
         target => 
         {
             target.transform.position = _muzzle.position;
             target.SetActive(true); 
         },
         target => 
         {
             target.transform.position = _poolPosition.position;
             target.SetActive(false); 
         },
         target => Destroy(target),
         true,
         10,
         100);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(_timer > _interval)
        {
            var obj1 = pool.Get();
            _timer = 0;
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }
}

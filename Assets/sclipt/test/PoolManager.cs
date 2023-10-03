using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Bullet _bullet;

    [SerializeField] int _maxCount;

    Queue<Bullet> _bulletQueue;

    Vector3 setPos = new Vector3(100, 100, 0);

    private void Awake()
    {
        _bulletQueue = new Queue<Bullet>();

        for (int i = 0; i < _maxCount; i++)
        {
            Bullet tmpBullet = Instantiate(_bullet, setPos, Quaternion.identity, transform);

            _bulletQueue.Enqueue(tmpBullet);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Bullet Launch(Vector3 _pos)
    {
        if (_bulletQueue.Count <= 0) return null;

        Bullet tmpBullet = _bulletQueue.Dequeue();

        tmpBullet.gameObject.SetActive(true);

        tmpBullet.ShowInStage(_pos);

        return tmpBullet;
    }

    public void Collect(Bullet _bullet)
    {
        _bullet.gameObject.SetActive(false);

        _bulletQueue.Enqueue(_bullet);
    }
}

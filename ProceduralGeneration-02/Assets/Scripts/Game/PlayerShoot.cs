using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPref;
    [Range(0, 20)]
    [SerializeField] private int _ammoNumber;
    [SerializeField] ObjectPooling _pool;

    private const float _BULLET_SPEED = 10.0f;

    private void Start()
    {
        _pool.InitAmmo(_bulletPref, _ammoNumber);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _pool.OnShoot(_BULLET_SPEED);
    }
}

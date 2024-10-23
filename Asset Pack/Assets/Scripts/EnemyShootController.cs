using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootDelay;
    [SerializeField] private Transform firePoint;
    private float _currTimer;
    void Start()
    {
        _currTimer = shootDelay;
    }
    void Update()
    {
        DelayShoot();
    }

    private void DelayShoot()
    {
        if (_currTimer > 0)
        {
            _currTimer -= Time.deltaTime;
        }
        else
        {
            Shoot();
            _currTimer = shootDelay;
        }
    }

    private void Shoot()
    {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
}

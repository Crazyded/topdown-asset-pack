using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootController : MonoBehaviour
{
    [SerializeField] private bool isAiming;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootDelay;
    [SerializeField] private Transform firePoint;
    private float _currTimer;
    private Transform _player;
    void Start()
    {
        _currTimer = shootDelay;
        _player = FindObjectOfType<TopDownController>().gameObject.transform;
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
        
        Quaternion bulletRotation = transform.rotation;
        if (isAiming)
        {
            Vector2 direction = _player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bulletRotation = Quaternion.Euler(new Vector3(0,0, angle - 90)); 
            //firePoint.LookAt(_player);
        }

        Instantiate(bulletPrefab, firePoint.position, bulletRotation);
    }
}

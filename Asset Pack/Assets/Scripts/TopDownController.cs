using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    private Rigidbody2D _rb;
    void Awake()
    {
       _rb = GetComponent<Rigidbody2D>(); 
    }
    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        _rb.velocity = moveDirection * speed;
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
}

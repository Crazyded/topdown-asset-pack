using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    private Rigidbody2D _rb;
    private float _currentLifetime;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    /*private void CheckLifetime()
    {
        if (_currentLifetime <= 0)
            Destroy(gameObject);
        else
            _currentLifetime -= Time.deltaTime;
    }*/
    private void Move()
    {
        _rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out TopDownController _) && gameObject)
        Destroy(gameObject);
    }
}

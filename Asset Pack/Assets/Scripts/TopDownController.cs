using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask damageLayerMask;
    [SerializeField] private LayerMask KeyLayerMask;
    private Rigidbody2D _rb;
    private Camera _mainCamera;
    public int Counter { get; private set; }
    void Awake()
    {
       _rb = GetComponent<Rigidbody2D>(); 
        _mainCamera = Camera.main;
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
        {
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector2 direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
            Instantiate(bulletPrefab, firePoint.position, bulletRotation);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(damageLayerMask, collision.gameObject))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (LayerMaskUtil.ContainsLayer(KeyLayerMask, collision.gameObject))
        {
            Counter = Counter+1;
            Debug.Log(Counter);
        }
    }
}

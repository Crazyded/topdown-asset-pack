using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyFollowController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask damageLayerMask;
    //[SerializeField] private float minFollowDistance;
    private Rigidbody2D _rb;
    private Transform _followTarget;
    private bool _isCollided;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (_followTarget && !_isCollided)
        {
            transform.position =
            Vector2.MoveTowards(transform.position, _followTarget.position, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TopDownController _))
        {
            _isCollided = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (LayerMaskUtil.ContainsLayer(damageLayerMask, collision.gameObject))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            if (collision.gameObject.TryGetComponent(out TopDownController _))
            {
                _isCollided = false;
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TopDownController _))
        {
            _followTarget = collision.transform;
            Debug.Log(collision.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TopDownController _))
        {
            _followTarget = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box_Destruction : MonoBehaviour
{
    [SerializeField] private int _boxhp;
    [SerializeField] private GameObject _splinters;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet _))
        {
            _boxhp = _boxhp - 25;
            if (_boxhp <= 0)
            {
                Destroy(gameObject);
                
            }
            
        }
    }
}

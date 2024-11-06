using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box_Destruction : MonoBehaviour
{
    [SerializeField] private int _boxhp;
    [SerializeField] private GameObject[] _splinters;
    [SerializeField] private PointEffector2D _pointeffect;
    [SerializeField] private GameObject _box;
    [SerializeField] private int _magnitude;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(_boxhp);
        if (collision.gameObject.TryGetComponent(out Bullet _))
        {
            _boxhp = _boxhp - 25;

            if (_boxhp <= 0)
            {
                _box.SetActive(false);
                for (int i=0; i<_splinters.Length; i++)
                {
                    _splinters[i].SetActive(true);
                }
                _pointeffect.forceMagnitude = _magnitude;
                
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(playerLayerMask, collision.gameObject))
        {
            Destroy(gameObject);
        }
    }
}

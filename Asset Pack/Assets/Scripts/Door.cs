using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.Android.Types;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int _keyamount;
    [SerializeField] private LayerMask playerLayerMask;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(playerLayerMask, collision.gameObject))
        {
            var player = collision.gameObject.GetComponent<TopDownController>();
            if (player.Counter >= _keyamount)
            {
                Destroy (gameObject);
            }
        }

    }
}

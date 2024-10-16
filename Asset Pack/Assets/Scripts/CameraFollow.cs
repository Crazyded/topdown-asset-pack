using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followTarget;

    void Update()
    {
        transform.position = new Vector3(
            followTarget.position.x,
            followTarget.position.y,
            transform.position.z );
    }
}

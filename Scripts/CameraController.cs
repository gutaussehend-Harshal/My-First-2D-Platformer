using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    // [SerializeField]
    // private float offSetX;
    // [SerializeField]
    // private float offSetY;
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        // Vector3 cameraPos = transform.position;
        // cameraPos.x = playerTransform.position.x + offSetX;
        // cameraPos.y = playerTransform.position.y + offSetY;
        // transform.position = cameraPos;

        transform.LookAt(target);
    }
}
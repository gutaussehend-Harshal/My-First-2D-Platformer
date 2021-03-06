using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera follows player
/// </summary>
namespace Outscal.BasicUnity2DProject
{
    public class CameraController : MonoBehaviour
    {
        [Header("Camera Settings")]
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [Range(1, 10)]
        [SerializeField] private float smoothFactor;

        private void LateUpdate()
        {
            Follow();
        }

        private void Follow()
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothPos = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
            transform.position = smoothPos;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// To move platform in horizontal and verticle direction.
/// </summary>
namespace Outscal.BasicUnity2DProject
{
    public class PlatformAttach : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == player)
            {
                player.transform.parent = transform;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == player)
            {
                player.transform.parent = null;
            }
        }
    }
}

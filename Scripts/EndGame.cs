using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Whenever player fall down from platform it will die.
/// </summary>
namespace Outscal.BasicUnity2DProject
{
    public class EndGame : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Player is died...");
                PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
                playerController.KillPlayer();
            }
        }
    }
}
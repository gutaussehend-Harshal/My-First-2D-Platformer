using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BasicUnity2DProject
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float speed;
        private bool moveRight;
        void Update()
        {
            if (moveRight)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(2, 2);
            }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(-2, 2);
            }
        }

        private void OnTriggerEnter2D(Collider2D trig)
        {
            if (trig.gameObject.CompareTag("turn"))
            {
                if (moveRight)
                {
                    moveRight = false;

                }
                else
                {
                    moveRight = true;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Player killed by Enemy");
                PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
                playerController.KillPlayer();
            }
        }
    }
}
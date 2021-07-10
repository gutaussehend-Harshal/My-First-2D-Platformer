﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BasicUnity2DProject
{
    public class KeyController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
                playerController.PickUpKey();
                gameObject.SetActive(false);
            }
        }
    }
}
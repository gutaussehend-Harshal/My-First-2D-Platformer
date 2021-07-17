using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Implemented basics player movement like run, jump and crouch.
/// </summary>
namespace Outscal.BasicUnity2DProject
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D rb2d;
        BoxCollider2D boxCollider2D;
        [Header("PlayerHurt Settings")]
        [SerializeField] private float timer = 0.2f;
        [Header("Score Settings")]
        [SerializeField] private ScoreController scoreController;
        private int scoreIncrement = 10;
        [Header("GameOver Settings")]
        [SerializeField] private GameOverController gameOverController;
        [Header("Animator Settings")]
        [SerializeField] private Animator animator;
        [Header("Health Settings")]
        [SerializeField] private int livesRemain = 3;
        [SerializeField] private Image[] heart;
        [Header("Audio Settings")]
        [SerializeField] private AudioSource audioSource;
        [Header("Player Movement Settings")]
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        bool canDoubleJump;
        bool isGrounded;
        bool gameOver;
        [SerializeField] private Vector2 crouchoffset;
        [SerializeField] private Vector2 crouchsize;
        [SerializeField] private Vector2 offset;
        [SerializeField] private Vector2 size;

        private void Awake()
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        }

        // Score will be increased by picking keys.
        public void PickUpKey()
        {
            Debug.Log("Player picked up the key");
            SoundManager.Instance.PlayMusic(Sounds.CollectItem);
            scoreController.IncreaseScore(scoreIncrement);
        }

        // Player will be died if it falls down from platform or hits an enemy
        public void KillPlayer()
        {
            livesRemain--;
            animator.Play("Player_Hurt");
            StartCoroutine(playHurtAnimation());
            SoundManager.Instance.PlayMusic(Sounds.PlayerHurt);
            updateLifeUI();
            if (gameOver == true)
            {
                gameOverController.PlayerDied();
            }
        }

        // Update health bar of a player
        private void updateLifeUI()
        {
            heart[livesRemain].gameObject.SetActive(false);
            if (livesRemain == 0)
            {
                heart[livesRemain].gameObject.SetActive(false);
                gameOver = true;
            }
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            PlayMovementAnimation(horizontal);
            PlayCrouchAnimation(horizontal);
            MoveCharacter(horizontal);
            float verticle = Input.GetAxisRaw("Jump");
            PlayJumpAnimation(verticle);
        }

        private void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
        // Move player horizontally
        private void MoveCharacter(float horizontal)
        {
            Vector3 position = transform.position;
            position.x += horizontal * speed * Time.deltaTime;
            transform.position = position;
        }

        // Player will be changed direction.
        private void PlayMovementAnimation(float horizontal)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            Vector3 scale = transform.localScale;
            if (horizontal < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (horizontal > 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }

        // Player will be jumped.
        private void PlayJumpAnimation(float veticle)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SoundManager.Instance.PlayMusic(Sounds.PlayerJump);
                // rb2d.velocity = new Vector2(0.0f, 10.0f);
                if (isGrounded)
                {
                    animator.SetBool("Jump", true);
                    jump();
                    canDoubleJump = true;
                }
                else if (canDoubleJump)
                {
                    jumpForce = jumpForce / 1.5f;
                    animator.SetBool("Jump", true);
                    jump();
                    canDoubleJump = false;
                    jumpForce = jumpForce * 1.5f;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                SoundManager.Instance.PlayMusic(Sounds.PlayerLand);
                if (!isGrounded)
                {
                    animator.SetBool("Jump", false);
                }
                // rb2d.velocity = new Vector2(0.0f, -15.0f);
            }
        }

        // player will be crouched.
        private void PlayCrouchAnimation(float horizontal)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                animator.SetBool("Crouch", true);
                boxCollider2D.offset = new Vector2(offset.x, offset.y);
                boxCollider2D.size = new Vector2(size.x, size.y);
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                animator.SetBool("Crouch", false);
                boxCollider2D.offset = new Vector2(crouchoffset.x, crouchoffset.y);
                boxCollider2D.size = new Vector2(crouchsize.x, crouchsize.y);
            }
        }

        // Player hurt animation will be played.
        IEnumerator playHurtAnimation()
        {
            yield return new WaitForSeconds(timer);
            transform.position = Vector2.zero;
            // transform.localScale = new Vector2(3f, 3f);
            animator.Play("Player_Idle");
        }

        void jump()
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }
    }
}
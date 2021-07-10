using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Outscal.BasicUnity2DProject
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float timer = 0.2f;
        [SerializeField] private ScoreController scoreController;
        [SerializeField] private GameOverController gameOverController;
        [SerializeField] private Animator animator;
        [SerializeField] private float speed;
        BoxCollider2D boxCollider2D;
        Rigidbody2D rb2d;
        [SerializeField] private Vector2 crouchoffset;
        [SerializeField] private Vector2 crouchsize;
        [SerializeField] private Vector2 offset;
        [SerializeField] private Vector2 size;
        [SerializeField] private int livesRemain = 3;
        private bool gameOver;
        [SerializeField] private Image[] heart;
        [SerializeField] private AudioSource audioSource;
        private int scoreIncrement = 10;
        private void Awake()
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        }
        public void PickUpKey()
        {
            Debug.Log("Player picked up the key");
            SoundManager.Instance.PlayMusic(Sounds.CollectItem);
            scoreController.IncreaseScore(scoreIncrement);
        }
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
            float verticle = Input.GetAxisRaw("Jump");
            PlayMovementAnimation(horizontal);
            PlayCrouchAnimation(horizontal);
            PlayJumpAnimation(verticle);
            MoveCharacter(horizontal);
        }
        // Move character horizontally
        private void MoveCharacter(float horizontal)
        {
            Vector3 position = transform.position;
            position.x += horizontal * speed * Time.deltaTime;
            transform.position = position;
        }
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
        private void PlayJumpAnimation(float veticle)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SoundManager.Instance.PlayMusic(Sounds.PlayerJump);
                animator.SetBool("Jump", true);
                rb2d.velocity = new Vector2(0.0f, 10.0f);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                SoundManager.Instance.PlayMusic(Sounds.PlayerLand);
                animator.SetBool("Jump", false);
                rb2d.velocity = new Vector2(0.0f, -15.0f);
            }
        }
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
        IEnumerator playHurtAnimation()
        {
            yield return new WaitForSeconds(timer);
            transform.position = Vector2.zero;
            // transform.localScale = new Vector2(3f, 3f);
            animator.Play("Player_Idle");
        }
    }
}
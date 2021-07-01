using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public Animator animator;
    public float speed;

    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rb2d;

    public float crouchoffsetX;
    public float crouchoffsetY;
    public float crouchsizeX;
    public float crouchsizeY;
    public float offsetX;
    public float offsetY;
    public float sizeX;
    public float sizeY;


    private int livesRemain = 3;
    private bool gameOver;
    public Image life01;
    public Image life02;
    public Image life03;

    private int scoreIncrement = 10;
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(scoreIncrement);
    }

    public void KillPlayer()
    {
        // Debug.Log("Player killed by Enemy");
        // Destroy(gameObject);
        // Play the death animation
        // Reset Entire level

        // Debug.Log("before" + livesRemain.ToString());
        livesRemain--;
        // Debug.Log("After" + livesRemain.ToString());
        // animator.SetBool("Hurt", true);

        transform.position = new Vector2(0, 0);
        // animator.SetBool("Hurt", false);
        updateLifeUI();
        if (gameOver == true)
        {
            // gameOverController.ReloadLevel();
            // SceneManager.LoadScene("GameOver");
            gameOverController.PlayerDied();    
        }
        // ReloadLevel();
        // this.enabled = false;
    }
    private void updateLifeUI()
    {
        if (livesRemain == 3)
        {
            life01.gameObject.SetActive(true);
            life02.gameObject.SetActive(true);
            life03.gameObject.SetActive(true);
            // animator.SetBool("Hurt", true);
        }
        if (livesRemain == 2)
        {
            life01.gameObject.SetActive(true);
            life02.gameObject.SetActive(true);
            life03.gameObject.SetActive(false);
            // animator.SetBool("Hurt", true);
        }
        if (livesRemain == 1)
        {

            life01.gameObject.SetActive(true);
            life02.gameObject.SetActive(false);
            life03.gameObject.SetActive(false);
            // animator.SetBool("Hurt", true);
        }
        if (livesRemain == 0)
        {

            life01.gameObject.SetActive(false);
            life02.gameObject.SetActive(false);
            life03.gameObject.SetActive(false);
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
        MoveCharacter(horizontal, verticle);

        // crouch = Input.GetKey("down");
        // animator.SetBool("Crouch", crouch);

        // jump = Input.GetKey("up");   
        // animator.SetBool("Jump", jump);
    }

    private void MoveCharacter(float horizontal, float verticle)
    {
        // Move character horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        // Move character vertically
        // if (verticle > 0)
        // {
        //     rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        // }
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
            animator.SetBool("Jump", true);
            rb2d.velocity = new Vector2(0.0f, 10.0f);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Jump", false);
            rb2d.velocity = new Vector2(0.0f, -15.0f);
        }
    }
    private void PlayCrouchAnimation(float horizontal)
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            boxCollider2D.offset = new Vector2(offsetX, offsetY);
            boxCollider2D.size = new Vector2(sizeX, sizeY);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
            boxCollider2D.offset = new Vector2(crouchoffsetX, crouchoffsetY);
            boxCollider2D.size = new Vector2(crouchsizeX, crouchsizeY);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // Ads
    private int tryCount;
    public InterAd interAd;

    // CHARACTER
    private CharacterController controller;
    private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    
    // GROUND
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    // UI
    [SerializeField] private int coins;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private Score scoreScript;
    [SerializeField] private GameObject losePanel;
    
    // PARTICLE
    [SerializeField] private ParticleSystem snowParticle;
    [SerializeField] private GameObject coinCollectParticle;

    // AUDIO
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip jumpSound;

    // ANIMANOR
    [SerializeField] private Animator animator;

    // LINES
    private int lineToMove = 1;
    private const int maxSpeed = 120;
    [SerializeField] private float lineDistance = 4;

    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
    }
    
    private void Start()
    {
        StartCoroutine(SpeedIncrease());
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();
        tryCount = PlayerPrefs.GetInt("tryCount");
    }

    private void Update() => PlayerMove();

    private void FixedUpdate() 
    {
        if(!PlayerManager.isGameStarted)
            return;

        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }

    public void PlayerMove()
    {
        if(!PlayerManager.isGameStarted)
            return;
            
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.9f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if(SwipeController.swipeRight)
        {
            if(lineToMove < 2)
            {
                snowParticle.Play();
                lineToMove++;
            }
        }
        if(SwipeController.swipeLeft)
        {
            if(lineToMove > 0)
            {
                lineToMove--;;
                snowParticle.Play();
            }
        }
        if(controller.isGrounded)
        {
            if(SwipeController.swipeUp)
                Jump();
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if(lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;

        if(transform.position == targetPosition)
            return;
        
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
        if(moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
        
    }

    private void Jump()
    {
        audioSource.PlayOneShot(jumpSound, .125f);
        snowParticle.Pause();
        dir.y = jumpForce;
    }

    // COLLIDER AND TRIGGER
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(hit.gameObject.tag == "Obstacle")
        {
            tryCount++;
            PlayerPrefs.SetInt("tryCount", tryCount);
            if(tryCount % 5 == 0)
                interAd.ShowAd();

            losePanel.SetActive(true);

            int bestScore = int.Parse(scoreScript.scoreText.text.ToString());
            PlayerPrefs.SetInt("bestScore", bestScore);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound, .5f);
            coins++;
            Instantiate(coinCollectParticle, other.transform.position, other.transform.rotation);
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);
        }
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(7);
        if(speed < maxSpeed)
        {
            speed += 0.75f;
            StartCoroutine(SpeedIncrease());
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D mybody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private bool isGrounded = true;
    [SerializeField]
    private AudioSource jumpSoundEffect;
    private bool playingInDesktop = true;
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            playingInDesktop = false;
        }
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MovementController.playerMovementButtonClicked += PlayerMovementButtonClickedListener;
    }
    private void OnDestroy()
    {
        MovementController.playerMovementButtonClicked -= PlayerMovementButtonClickedListener;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }
    private void FixedUpdate()
    {
        PlayerJumpListener();
    }

    private void PlayerMoveKeyboard()
    {
        if (playingInDesktop)
        {
            movementX = Input.GetAxisRaw("Horizontal");
        }
        MovePlayer();
    }
    void AnimatePlayer()
    {
        // we are going to the right side
        if (movementX > 0) { 
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } else if(movementX < 0) {
            //we are going to the left side
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        } else
        {
            anim.SetBool(WALK_ANIMATION, false);

        }
    }
    void PlayerJumpListener()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerJumped();
        }
    }

    private void PlayerJumped()
    {
        if (isGrounded)
        {
            isGrounded = false;
            jumpSoundEffect.Play();
            mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            DestroyAndGameOverSound();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
            DestroyAndGameOverSound();
    }

    private void DestroyAndGameOverSound()
    {
        GameManager.instance.GameOverSoundEffect.Play();
        Destroy(gameObject);
    }

    private void PlayerMovementButtonClickedListener(string buttonName)
    {
        Debug.Log(buttonName + " is pressed.");
        switch (buttonName)
        {
            case "left":
                movementX = -1;
                MovePlayer();
                break;
            case "right":
                movementX = 1;
                MovePlayer();
                break;
            case "jump":
                PlayerJumped();
                break;
            default:
                movementX = 0;
                break;
        }
    }
    private void MovePlayer()
    {
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        AnimatePlayer();
    }
}

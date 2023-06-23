using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 13f;

    private float moveX;
    
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private Animator animate;
    private SpriteRenderer sr;

    private string RUN_ANIMATION = "Run";
    private string AIR_ANIMATION = "Airborne";

    private bool isGrounded;
    public Vector3 checkpoint;

    public ItemCounter ic;

    [SerializeField]
    private AudioSource obstacleHit;
    [SerializeField]
    private AudioSource jumped;
    [SerializeField]
    private AudioSource collected;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        checkpoint = transform.position;
    }
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        
        KeyboardInput();
        MarvinJump();
        AnimateMarvin();
    }

    void KeyboardInput() {
        moveX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimateMarvin() {

        // Animate which way Marvin is facing
        // Facing the right
        if (moveX > 0) {
            sr.flipX = false;
        }
        // Facing the left
        else if (moveX < 0) {
            sr.flipX = true;
        }
        
        // Animate Marvin's actions
        // Marvin jumps and lands running
        if (body.velocity.y != 0) {
            animate.SetBool(AIR_ANIMATION, true);
        }
        // Moving to the right
        else if (body.velocity.y == 0 && moveX > 0) {
            animate.SetBool(RUN_ANIMATION, true);
            animate.SetBool(AIR_ANIMATION, false);
        }
        // Moving to the left
        else if (body.velocity.y == 0 && moveX < 0) {
            animate.SetBool(RUN_ANIMATION, true);
            animate.SetBool(AIR_ANIMATION, false);
        }
        else {
            animate.SetBool(RUN_ANIMATION, false);
            animate.SetBool(AIR_ANIMATION, false);
        }
    }

    void MarvinJump() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            jumped.Play();
            body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        } else if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Bird")) {
            obstacleHit.Play();
            transform.position = checkpoint;
        } else if(collision.gameObject.CompareTag("MCloud")) {
            this.transform.parent = collision.transform;
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("MCloud")) {
            this.transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Respawn")) {
            checkpoint = transform.position;
        }
        else if (other.gameObject.CompareTag("Drop")) {
            collected.Play();
            Destroy(other.gameObject);
            ic.dropCount++;
        }
        else if (other.gameObject.CompareTag("Sun")) {
            collected.Play();
            Destroy(other.gameObject);
            ic.sunCount++;
        }
        else if(other.gameObject.CompareTag("Snow")) {
            collected.Play();
            Destroy(other.gameObject);
            BonusManager.snowCount++;
        }
    }
}

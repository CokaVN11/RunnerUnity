using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private float moveInput;

    public float speed;
    public float jumpHeight = 10f;
    public float groundCheckRadius;
    public int health = 3;
    public float minHeight;

    public Transform groundCheck;
    public LayerMask whatIsGround;

    private bool isGrounded;
    private bool canJump;
    private bool canCrunch;
    //private bool crunchBool = false;
    public bool touching;
    private enum State { Idle, Jump, Hurt, Down };
    private State state = State.Idle;

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D colli;

    public GameObject gameOver;

    [FormerlySerializedAs("Pause")] public GameObject pause;
    private static readonly int State1 = Animator.StringToHash("State");

    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(true);
        gameOver.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colli = GetComponent<BoxCollider2D>();
        touching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0) return;
        gameOver.SetActive(true);
        gameObject.SetActive(false);
        // if (transform.position.y < minHeight)
        // {
        //     transform.position = new Vector3(transform.position.x, minHeight, 0);
        // }

    }

    // Update is called once per frame-rate frame
    private void FixedUpdate()
    {
        CheckInput();
        CheckIfCanJump();
        CheckIfCanCrunch();
        UpdateAnimation();
        ApplyMove();
        CheckSurrounding();
    }

    // Apply movement on player
    private void ApplyMove()
    {
        var velocity = rb.velocity;
        velocity = new Vector2(velocity.x, velocity.y);
        rb.velocity = velocity;
    }
    private void UpdateAnimation()
    {
        anim.SetInteger(State1, (int)state);
        touching = false;
    }
    private void CheckInput()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        switch (moveInput)
        {
            case > 0:
                Jump();
                Normal();
                break;
            case < 0:
            {
                if (canCrunch)
                {
                    Crunch();
                }

                break;
            }
            default:
            {
                Normal();
                state = touching ? State.Hurt : State.Idle;

                break;
            }
        }
    }
    private void CheckIfCanJump()
    {
        canJump = isGrounded;
    }
    private void CheckIfCanCrunch()
    {
        canCrunch = isGrounded;
    }
    private void CheckSurrounding()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    // ReSharper disable Unity.PerformanceAnalysis
    private void Jump()
    {
        if (!canJump) return;
        // Debug.Log("velocity x: " + rb.velocity.x + " velocity y: " + rb.velocity.y);

        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        state = State.Jump;
    }
    private void Crunch()
    {
        colli.size = new Vector2(colli.size.x, 0.5f);
        state = State.Down;
    }
    private void Normal()
    {
        colli.size = new Vector2(colli.size.x, 0.7f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

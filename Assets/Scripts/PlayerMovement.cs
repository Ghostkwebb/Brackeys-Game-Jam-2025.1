using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public CapsuleCollider2D col2d;
    public BoxCollider2D feet;
    Vector2 moveInput;

    Animator anim;

    public float moveSpeed = 5f;
    public float jumpAmount = 10f;
    public Button button;
    public bool onButton = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!rb2d.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        rb2d.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
       
    }

    void jumpAnimation()
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            anim.SetBool("inAir", true);
        }
        else
        {
            anim.SetBool("inAir", false);
        }
    }

    void Run()
    {   
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb2d.linearVelocity.y);
        rb2d.linearVelocity = playerVelocity;
        if (moveInput.x != 0)
        {
            anim.SetBool("isWalking_RIght", true);
            bool flipped = moveInput.x < 0;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));
        }
        
        else
        {
            anim.SetBool("isWalking_RIght", false);

        }
    }

    void OnInteract(InputValue value)
    {
        if (onButton && value.isPressed)
        {
            button.Press();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Button"))
        {
            onButton = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            onButton = false;
        }
    }
}

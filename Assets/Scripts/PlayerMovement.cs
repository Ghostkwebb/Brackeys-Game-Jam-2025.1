using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    Vector2 moveInput;

    public float moveSpeed = 5f;
    public float jumpAmount = 10f;

    void Start()
    {
        
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

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb2d.linearVelocity.y);
        rb2d.linearVelocity = playerVelocity;
    }
}

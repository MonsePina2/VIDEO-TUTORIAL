using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float       moveSpeed = 5f;
    private                  Rigidbody2D rb;
    private                  Animator    animator;
    private                  Vector2     moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() {
        rb =  GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update() {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move (InputAction.CallbackContext context) {

        animator.SetBool("IsWalking",true);
        if (context.canceled)
        {
            animator.SetBool( "IsWalking",false);
            animator.SetFloat("LastInputX",moveInput.x);
            animator.SetFloat("LastInputY",moveInput.y);
        }

        moveInput=context.ReadValue<Vector2>();

        animator.SetFloat("InputX",moveInput.x);
        animator.SetFloat("InputY",moveInput.y);


    }
}

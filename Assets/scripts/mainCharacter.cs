using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class mainCharacter : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public PlayerInputActions playerControls;
    public Animator animator;
    public int healthPoints = 10;

    public float horizontalSpeed = 0f;
    public float verticalSpeed = 0f;
    bool facingRight = true;



    Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    private InputAction dash;
    public GameObject prefabOfGun;


    void Awake()
    {
        playerControls = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        Instantiate(prefabOfGun, new Vector3(0, 0, 0), transform.rotation);
    }

    private void OnEnable(){
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable(){
        move.Disable();
    }


    void FixedUpdate()
    {
        
 

        moveDirection = move.ReadValue<Vector2>();

        horizontalSpeed = moveDirection.x * moveSpeed;
        verticalSpeed = moveDirection.y * moveSpeed;

        rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
    
        animator.SetFloat("speed", Mathf.Abs(moveDirection.x + moveDirection.y));

        if (horizontalSpeed > 0 && !facingRight)
        {
            Flip();
        }
        if (horizontalSpeed < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("We Fired");
    }

    public void takeDamage(int n)
    {
        healthPoints -= n;
        if(healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }


}



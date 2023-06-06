using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class gun : MonoBehaviour
{
    Vector2 aimDirection = Vector2.zero;
    Vector3 moveVector = Vector3.zero;
    public PlayerInputActions playerControls;
    private Vector3 difference;
    // bool facingRight = true;
    private InputAction aim;

    public GameObject player;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        difference = new Vector3(0.0f, -0.1f, 0.0f);
    }

    private void OnEnable(){
        aim = playerControls.Player.aim;
        aim.Enable();
    }

    private void OnDisable(){
        aim.Disable();
    }

    void Update(){
        var character = GameObject.Find("Player");
        transform.position = character.transform.position + difference;
        

        aimDirection = aim.ReadValue<Vector2>();

        moveVector = (Vector3.up * aimDirection.x + Vector3.left * aimDirection.y);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);

        if(player.GetComponent<mainCharacter>().healthPoints <= 0)
        {
            Destroy(gameObject);
        }

        // if ((transform.localRotation.eulerAngles.z > 90 | transform.localRotation.eulerAngles.z < -90) && !facingRight)
        // {
        //     Flip();
        // }
        // if ((transform.localRotation.eulerAngles.z < 90 | transform.localRotation.eulerAngles.z < -90) && facingRight)
        // {
        //     Flip();
        // }

    }

    

    // void Flip()
    // {
    //     Vector3 currentScale = gameObject.transform.localScale;
    //     currentScale.x *= -1;
    //     gameObject.transform.localScale = currentScale;
    //     facingRight = !facingRight;
    // }

}

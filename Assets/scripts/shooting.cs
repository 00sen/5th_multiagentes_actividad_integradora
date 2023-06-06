using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class shooting : MonoBehaviour
{

    private InputAction fire;
    public PlayerInputActions playerControls;
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable(){
        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    private void OnDisable(){
        fire.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Instantiate(bulletPrefab,shootingPoint.position,transform.rotation);
    }
}

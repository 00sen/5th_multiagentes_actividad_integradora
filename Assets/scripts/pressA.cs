using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class pressA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            Debug.Log(Gamepad.all[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.all.Count > 0)
        {
            if (Gamepad.all[0].buttonSouth.isPressed)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}

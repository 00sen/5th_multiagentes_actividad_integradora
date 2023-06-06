using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class numeroBalas : MonoBehaviour
{
    public TextMeshProUGUI bulletText;

    private int bulletNumber;

    private void Start()
    {
        
    }
    private void Update()
    {
        bulletNumber = GameObject.FindGameObjectsWithTag("Bullet").Length;
        bulletText.text = bulletNumber.ToString();
    }
}

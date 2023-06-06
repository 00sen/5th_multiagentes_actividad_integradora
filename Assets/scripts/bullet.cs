using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyFollowPlayer>().quitarVida(1);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Player")
        {
            Debug.Log("olakase");
        }
    }

}


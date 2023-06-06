using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    [SerializeField]
    private Collider2D colliderToIgnore;

    Collider2D self;
    void Start()
    {
        self = GetComponent<Collider2D>();
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Physics2D.IgnoreCollision(self, colliderToIgnore);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.tag == "Enemy")
        //{
        //    Physics.IgnoreCollision(self, colliderToIgnore);
        //}
        if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Player")
        {
            target.GetComponent<mainCharacter>().takeDamage(1);
            Destroy(gameObject);
        }
    }
}

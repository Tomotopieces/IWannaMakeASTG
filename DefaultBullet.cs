using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : MoveableObjects
{
    [SerializeField]
    private int damage = 1;
    private DefaultEnemy enemy;

    override protected void Start()
    {
        base.Start();
        upperLeft = GameObject.Find("Boundarys/playerBoundary/upperLeft").transform;
        bottomRight = GameObject.Find("Boundarys/playerBoundary/bottomRight").transform;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7f);
        gameObject.SetActive(true);
    }

    void Update()
    {
        Movement();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<DefaultEnemy>();
            enemy.Health -= damage;
            Destroy(gameObject);
        }
    }

    private void Movement()
    {
        if (!IsReasonable())
        {
            Destroy(gameObject);
        }
    }

    private bool IsReasonable()
    {
        if (transform.position.x > upperLeft.position.x && transform.position.x < bottomRight.position.x)
        {
            if (transform.position.y > bottomRight.position.y && transform.position.y < upperLeft.position.y)
            {
                return true;
            }
        }
        return false;
    }
}

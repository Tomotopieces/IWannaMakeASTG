using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAero : MoveableObjects
{
    private float startTime;
    public float shootingSpeed;

    public float horizontalSpeed;
    public float verticalSpeed;

    protected float lastShootTime;
    public GameObject bullet;

    override protected void Start()
    {
        base.Start();
        upperLeft = GameObject.Find("Boundarys/playerBoundary/upperLeft").transform;
        bottomRight = GameObject.Find("Boundarys/playerBoundary/bottomRight").transform;
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        Movement();
        CreateBullet();
    }

    private void Movement()
    {
        float horizontalDirection = Input.GetAxisRaw("Horizontal");
        float verticalDirection = Input.GetAxisRaw("Vertical");

        if (horizontalDirection != 0)
        {
            Vector2 destination = new Vector2(transform.position.x + horizontalSpeed * horizontalDirection, transform.position.y);
            if (IsReasonable(destination))
            {
                transform.position = new Vector2(destination.x, destination.y);
            }
        }

        if (verticalDirection != 0)
        {
            Vector2 destination = new Vector2(transform.position.x, transform.position.y + verticalSpeed * verticalDirection);
            if (IsReasonable(destination))
            {
                transform.position = new Vector2(destination.x, destination.y);
            }
        }
    }

    private bool IsReasonable(Vector2 destination)
    {
        if (destination.x > upperLeft.position.x && destination.x < bottomRight.position.x)
        {
            if(destination.y > bottomRight.position.y && destination.y < upperLeft.position.y)
            {
                return true;
            }
        }
        return false;
    }

    virtual protected void CreateBullet()
    {
        float currentTime = Time.fixedTime;
        if (currentTime - lastShootTime > shootingSpeed)
        {
            AudioManager.PlayShootAudio();
            lastShootTime = currentTime;
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.SetActive(true);
        }
    }
}

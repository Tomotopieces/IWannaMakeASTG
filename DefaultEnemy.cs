using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class DefaultEnemy : MoveableObjects
{
    private bool initiallize = true;

    [Header("EnemyState")]
    [SerializeField]
    private int health;
    public int Health { get { return health; } set { health = value; } }
    [SerializeField]
    private float flightSpeed;
    [SerializeField]
    private bool isDied;

    [SerializeField]
    private AnimationCurve speedCurve;
    [SerializeField]
    private AnimationCurve horizontalCurve;
    private float originalX;
    private float originalTime;

    private PlayerController player;
    private UnityEngine.UI.Text scoreCounter;

    void Start()
    {
        base.Start();
        player = GameObject.Find("MoveableObjects/player").GetComponent<PlayerController>();
        upperLeft = GameObject.Find("Boundarys/enemyBoundary/upperLeft").transform;
        scoreCounter = GameObject.Find("Canvas/ScoreCounter").GetComponent<Text>();
        bottomRight = GameObject.Find("Boundarys/enemyBoundary/bottomRight").transform;
        objectBody.velocity = new Vector2(0, -flightSpeed);
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            AudioManager.PlayPlayerDeathAudio();
            Destroy(collider.gameObject);
        }
    }

    private void Movement()
    {
        if(transform.position.y < 6.5 && initiallize)
        {
            originalTime = Time.fixedTime;
            originalX = transform.position.x;
            initiallize = false;
        }

        if (isDied)
            return;

        if (!IsReasonable())
        {
            Destroy(gameObject);
        }

        flightSpeed = speedCurve.Evaluate(Time.fixedTime);
        objectBody.velocity = new Vector2(0, -flightSpeed);
        if (!initiallize)
        {
            transform.position = new Vector3(originalX + horizontalCurve.Evaluate(Time.fixedTime - originalTime), transform.position.y);
        }

        if (0 >= health)
        {
            isDied = true;
            objectBody.velocity = new Vector2(0, 0);
            objectCollider.enabled = false;
            player.Score++;
            scoreCounter.text = "Score: " + player.Score;
            AudioManager.PlayEnemyDeathAudio();
            objectAnimator.SetBool("die", true);
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

    private void Death()
    {
        Destroy(gameObject);
    }
}

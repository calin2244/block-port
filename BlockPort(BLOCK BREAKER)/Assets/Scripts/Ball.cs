using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{   //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xForce;
    float screenWidthInUnits = 16f;
    int nrDash = 3;
    public float speed; //the same as yForce
    [SerializeField] float randomFactor;

    //State

    Vector2 paddleToBallVector;

    //bools
    private bool hasStarted = false;
    public bool teleported= true;

    //RigidBody + TrailRenderer
    Rigidbody2D rb;
    public TrailRenderer trail;


    //speed
    public float startDashTime;
    private float dashTime;
    public float extraSpeed;
    private bool isDashing;

    //TMP
    [SerializeField] TextMeshProUGUI dashLeft;
    [SerializeField] TextMeshProUGUI dashText;


    void Start()
    {   
        //Cursor.visible = false;
        dashLeft.text = nrDash.ToString();
        paddleToBallVector = transform.position - paddle1.transform.position;
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        Cursor.visible = false;


    }
    void Update()
    {
        if (!hasStarted && PauseMenu.gameIsPaused == false)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
        else
        {
            trail.enabled = true;
            trail.startWidth = 0.1f;
        }

        //mai sus functia de lipire a bilei si marimea trail-ului cand este lipita si dupa

        if (Input.GetKeyDown(KeyCode.Space) && isDashing == false && nrDash!=0 && hasStarted)
        {
                float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
                speed = speed + extraSpeed;
                isDashing = true;
                if(mousePosInUnits>=8)
                    rb.velocity = new Vector2(-extraSpeed, speed);
                else if(mousePosInUnits<=8)
                    rb.velocity = new Vector2(extraSpeed, speed);
                dashTime = startDashTime;
                nrDash--;
            if (nrDash != 0)
                dashLeft.text = nrDash.ToString();
            else
            {
                dashLeft.text = ("Out  of  Dashes");
                dashText.text = " ";
            }
        }
            if (dashTime <= 0 && isDashing == true)
            {
                isDashing = false;
                speed = speed - extraSpeed;                
        }
            else
            {
                dashTime = dashTime - Time.deltaTime;
            }
        if (teleported)        
           StartCoroutine(Countdown());         
        else teleported = false;
    }
  

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButton(0))
        {
            rb.velocity = new Vector2(xForce,speed);
            hasStarted = true;
        }
    }  

    public void LockBallToPaddle()
    {
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
            trail.startWidth = 0;
            trail.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityFix = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        string bloc = "BLOCKS"; string pad = "Paddle";
        if (hasStarted)
        {
            if (collision.gameObject.name == pad)
                collision.transform.GetComponent<AudioSource>().Play();
            else if (collision.gameObject.transform.parent.name == bloc)
                collision.transform.parent.GetComponent<AudioSource>().Play();
            else
                GetComponent<AudioSource>().Play();
            rb.velocity = rb.velocity + velocityFix;
        }
    }

    public IEnumerator TrailEffActivate()
    {
        yield return new WaitForSeconds(0.3f);
        if(gameObject.name=="BALL")
         gameObject.GetComponent<TrailRenderer>().enabled = true;
    }

    public IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0f); //Am setat waitforseconds 0 pt bugul cu teleportarea primului portal
        teleported = true;
    }

}        
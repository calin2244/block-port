using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{

    public GameObject nextPortal;
    public GameObject Player;
    Ball spd;
    Ball getTrailEffectEnabled;
    [SerializeField] Vector3 portBallVec3;
    Ball balldata;


    void Start()
    {
        spd = FindObjectOfType<Ball>();
        getTrailEffectEnabled = FindObjectOfType<Ball>();
        balldata = FindObjectOfType<Ball>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "BALL")        
            if (balldata.teleported)

            {
                StartCoroutine(balldata.Countdown());
                StartCoroutine(Teleport());
                gameObject.transform.position = nextPortal.transform.position + portBallVec3;
                DestroyNPort(); 
                other.gameObject.GetComponent<TrailRenderer>().enabled = false;

            }           
            StartCoroutine(getTrailEffectEnabled.TrailEffActivate());
            getTrailEffectEnabled.TrailEffActivate();
 
    }
    

    private IEnumerator Teleport()
    {
        if (balldata.teleported == true)
        {
            yield return new WaitForSeconds(0);
            Player.transform.position = new Vector2(nextPortal.transform.position.x, nextPortal.transform.position.y);
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(spd.extraSpeed, -spd.extraSpeed);
            balldata.teleported = false;
            Destroy(gameObject);
        }
    }

    private void DestroyNPort()
    {
        Destroy(nextPortal, 0.3f);
    }    

}
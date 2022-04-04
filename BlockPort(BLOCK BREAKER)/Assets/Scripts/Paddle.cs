using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    float screenHeightUnits = 12f;   

    [SerializeField] float minX, maxX;
    [SerializeField] float minY, maxY;

    SceneLoader sceneI;

    Vector2 paddlePos;

    void Update()
    {
        int currentSceneI = SceneManager.GetActiveScene().buildIndex;
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        float mousePosY = Input.mousePosition.y / Screen.height * screenHeightUnits;
        if (Time.timeScale != 0)
        {
            paddlePos = new Vector2(mousePosInUnits, mousePosY);
            paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
            paddlePos.y = Mathf.Clamp(mousePosY, minY, maxY);
            transform.position = paddlePos;
        }

        //FUNCTIE SPECIALA PADDLE PT NIVELUL 3

        if (FindObjectOfType<Block>().destroyedUnbrPerPortion==true && currentSceneI==3)
        {
            if (Time.timeScale != 0)
            {
                paddlePos.x = Mathf.Clamp(mousePosInUnits, 3f, 7f);
                paddlePos.y = Mathf.Clamp(mousePosY, 5.9f, 5.9f);
                transform.position = paddlePos;
            }
        }
    }   
        
    private void OnCollisionEnter2D(Collision2D collision)
    {        
            GetComponent<AudioSource>().Play();
    }
}

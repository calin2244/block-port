using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    public bool gameOver = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cursor.visible = true;
        gameOver = true;
    }
}

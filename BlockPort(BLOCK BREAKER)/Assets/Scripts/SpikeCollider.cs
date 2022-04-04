using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollider : MonoBehaviour
{
    public bool spikeGameOver = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cursor.visible = true;
        spikeGameOver = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] public int breakableBlocks;  //pentru debugs
    [SerializeField] public int breakablePerPortionBlocks;
    
    public void CountBlocks()
    {
        breakableBlocks++;
    }
    public void CountPortionBlocks()
    {
        breakablePerPortionBlocks++;
    }
    public void DestroyBlocks()
    {
        breakableBlocks--;
    }
    public void DestroyPortionBlocks()
    {
        breakablePerPortionBlocks--;
    }
}

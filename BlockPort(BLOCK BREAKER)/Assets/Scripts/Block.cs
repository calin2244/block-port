using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Block : MonoBehaviour
{
    //config params
    int totalScore;
    [SerializeField] GameObject particleEffect;

    //from other scripts
    GameStats score;
    Level level;
    public bool destroyedUnbrPerPortion = false;

    //state vars
    [SerializeField] int timesHit; //doar pentru debugs

    //arays for broken levels of each block 
    [SerializeField] Sprite[] hitSprites;

    private void Start()
    {
        CountBreakableBlocksAndAddToScore();
        score = FindObjectOfType<GameStats>();
    }

    private void Update()
    {
        if (level.breakablePerPortionBlocks == 0)
        {
            DestroyUnbreakablePerPortionBlock();
            destroyedUnbrPerPortion = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
        if(tag == "Breakable per Portion")
        {
            HandlePortionBlocks();
        }
    }

    private void DestroyBlock()
    {   
            TriggerParticleEffect();
            Destroy(gameObject);
            score.AddToScore();
            level.DestroyBlocks();       
    }

    private void DestroyPortionBlock()
    {
        TriggerParticleEffect();
        Destroy(gameObject);
        score.AddToScore();
        level.DestroyPortionBlocks();
    }

    private void DestroyUnbreakablePerPortionBlock()
    {
        if (gameObject.name=="UNBRPORT")
        {
            Destroy(gameObject);
            TriggerParticleEffect();
        }
    }

    private void TriggerParticleEffect()
    {
        GameObject sparkles = Instantiate(particleEffect,transform.position, transform.rotation);
        Destroy(sparkles, 2);
    }

    private void CountBreakableBlocksAndAddToScore()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
        if(tag == "Breakable per Portion")
        {
            level.CountPortionBlocks();
        }
        totalScore = 0;
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits && tag == "Breakable")
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void HandlePortionBlocks()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits && tag == "Breakable per Portion")
        {
            DestroyPortionBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite missing from array" + gameObject.name);
        }
    }
}

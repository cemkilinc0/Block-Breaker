using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip blockSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;


    // Cached References
    Level level;
    Rigidbody2D fallingBlock;


    // state variables
    [SerializeField] int timesHit; // Serialized for debug

    private void Start()
    {
        CountBreakableBlocks();
        fallingBlock = FindObjectOfType<Rigidbody2D>();
    }


    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
            level.CountBlocks();
        else if (tag == "Falling Block")
            level.CountBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHits();
        }
        else if (tag == "Falling Block")
        {
            HandleHits();
            fallingBlock.velocity = new Vector3(0, -3f, 0);
        }
    }

    private void HandleHits()
    {
        timesHit++;
        int maxHit = hitSprites.Length + 1;
        if (timesHit >= maxHit)
        {   
            DestroyBlock();
        }
        else // show sprite damage level
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
            Debug.LogError("Block sprite is missing from array. " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        //TriggerSparklesVFX();

        AudioSource.PlayClipAtPoint(blockSound, transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        FindObjectOfType<GameStatus>().addToScore();
      
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}

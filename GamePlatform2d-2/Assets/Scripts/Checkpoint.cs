using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite checkPointLighted;
    public GameObject lights;

    private bool isActive;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive)
        {
            return;
        }

        if(other.CompareTag("Player"))
        {
            spriteRenderer.sprite = checkPointLighted;
            lights.SetActive(true);
        }
    }
}

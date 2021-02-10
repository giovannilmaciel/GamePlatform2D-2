using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite checkPointLighted;
    public GameObject lights;

    private bool isActive;

    private SpriteRenderer spriteRenderer;
    private CheckpointController checkpointController;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        checkpointController = FindObjectOfType<CheckpointController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive)
        {
            return;
        }

        if(other.CompareTag("Player"))
        {
            checkpointController.SetPos(transform.position);
            spriteRenderer.sprite = checkPointLighted;
            lights.SetActive(true);
            isActive = true;
        }
    }
}

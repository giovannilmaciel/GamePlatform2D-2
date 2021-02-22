﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject[] lives;

    public Text dialogueText;
    public Animator dialoquePanel;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string text)
    {
        CancelInvoke();
        dialogueText.text = text;
        dialoquePanel.gameObject.SetActive(true);
    }

    public void SetTextOut()
    {
        Invoke("TextOut", 1f);
    }

    private void TextOut()
    {
        dialoquePanel.Play("Dialoque_Exit");
        Invoke("DisableDialoguePanel", 0.5f);
    }

    private void DisableDialoguePanel()
    {
        dialoquePanel.gameObject.SetActive(false);
    }

    public void SetLives(int amount)
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].SetActive(false);
        }

        for (int i = 0; i < amount; i++)
        {
            lives[i].SetActive(true);
        }
    }
}

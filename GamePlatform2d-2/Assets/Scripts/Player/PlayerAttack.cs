using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    public UnityEvent OnAttack;
    public UnityEvent ReleaseAttack;

    public float attackRate = 0.5f;

    private bool canAttack = true;

    private PlayerAnimation playerAnimation;
    private PlayerController playerController;

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerController = GetComponent<PlayerController>();
    }

    public void MelleAttack()
    {
        if(canAttack)
        {
            canAttack = false;

            OnAttack.Invoke();

            playerAnimation.SetMelleAttack();

            if(!playerController.IsOnIce())
            {
                playerController.DisableControls();
            }

            Invoke("FinishAttack", attackRate);
        }
    }

    void FinishAttack()
    {
        canAttack = true;
        ReleaseAttack.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    public UnityEvent OnAttack;
    public UnityEvent ReleaseAttack;

    public float attackRate = 0.5f;

    public Rigidbody2D bulletPrefab;
    public Transform shotSpawn;
    public float fireRate = 0.2f;
    public float shotImpulse = 10;
    private float nextFire;

    private bool canAttack = true;

    private PlayerAnimation playerAnimation;
    private PlayerController playerController;

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerController = GetComponent<PlayerController>();
    }

    public void Fire()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Rigidbody2D newBullet = Instantiate(bulletPrefab, shotSpawn.position, shotSpawn.rotation);
            newBullet.AddForce(transform.right * shotImpulse, ForceMode2D.Impulse);
        }
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

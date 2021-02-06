using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent OnDamage;
    public UnityEvent ReleaseDamage;
    public UnityEvent OnDeath;

    public int maxHealth;
    public float invincibleTime;

    private int currentHealth;
    private bool invincible;
    private bool isDead;

    public Color damageColor;
    private SpriteRenderer spriteRenderer;
    private Color startColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        startColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        if(invincible || isDead)
        {
            return;
        }

        OnDamage.Invoke();
        invincible = true;
        Invoke("SetInvincible", invincibleTime);
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            isDead = true;
            OnDeath.Invoke();
        }
    }

    void SetInvincible()
    {
        invincible = false;
    }

    public void StartDamageSprite()
    {
        StartCoroutine(DamageSprite());
    }

    IEnumerator DamageSprite()
    {
        float timer = 0;
        while (timer < invincibleTime)
        {
            spriteRenderer.color = damageColor;
            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
            spriteRenderer.color = startColor;
            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
        }

        spriteRenderer.color = startColor;
    }
}

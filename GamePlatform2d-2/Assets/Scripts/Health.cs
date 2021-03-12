using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthAmount;

    public void GainHealth()
    {
        FindObjectOfType<PlayerController>().GetComponent<Damageable>().SetHealth(healthAmount);
    }
}

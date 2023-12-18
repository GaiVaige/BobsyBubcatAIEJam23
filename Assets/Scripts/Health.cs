using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Values")]
    public int currentHealth;
    public int maxHealth;


    void Start()
    {
        currentHealth = maxHealth;   
    }

    public void ApplyDamage(int dam)
    {
        currentHealth -= dam;
    }
}

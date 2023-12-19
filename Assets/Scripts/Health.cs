using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Values")]
    public int currentHealth;
    public int maxHealth;



    [Header("Keycard Spawn Settings")]
    public bool hasKeyCard;
    public GameObject keycardPrefab;

    void Start()
    {
        currentHealth = maxHealth;   
    }

    public void ApplyDamage(int dam)
    {
        currentHealth -= dam;
    }


    public void Update()
    {
        CheckForDeath();
    }


    public void CheckForDeath()
    {

        if(currentHealth <= 0)
        {
            if (this.gameObject.transform.root.tag != "Player")
            {

                if (hasKeyCard)
                {
                    GameObject kc = Instantiate(keycardPrefab, this.transform);
                    kc.transform.rotation = this.transform.rotation;
                    kc.transform.parent = null;
                    hasKeyCard = false;
                    Destroy(this.gameObject);
                }

                
            }
        }


    }
}

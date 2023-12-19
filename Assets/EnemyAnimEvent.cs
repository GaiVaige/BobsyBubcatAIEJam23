using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimEvent : MonoBehaviour
{


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kill()
    {
        Destroy(this.gameObject.transform.root.gameObject);
    }

    public void Shoot()
    {
        Enemy em = GetComponentInParent<Enemy>();
        em.ShootGun();
    }
}

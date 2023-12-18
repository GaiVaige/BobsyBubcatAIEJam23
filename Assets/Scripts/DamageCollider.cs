using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public int damage;

    public void OnTriggerEnter(Collider other)
    {
        Health hp;
        hp = other.GetComponent<Health>();


        if(hp != null && other.gameObject.tag != this.gameObject.tag)
        {
            hp.ApplyDamage(damage);
        }
    }
}

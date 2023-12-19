using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //values
    public float moveSpeed;
    public int damage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVec = transform.forward * moveSpeed * Time.deltaTime;


        transform.position += moveVec;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("LOL GET SHOT");
            other.GetComponent<Health>().ApplyDamage(damage);
            Destroy(this.gameObject);
        }
        else if(other.tag != "Enemy" && other.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Keycard : MonoBehaviour
{
    public string boolToSet;
    public float flySpeed;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward * flySpeed, ForceMode.Impulse);
        rb.AddForce(transform.up * flySpeed, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().setKeycardBool(boolToSet);
            Destroy(this.gameObject);
        }
    }
}

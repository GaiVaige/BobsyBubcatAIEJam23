using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator _anim;
    public bool redDoor;
    public bool blueDoor;
    public bool greenDoor;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {

        if (redDoor)
        {
            if (other.GetComponent<Player>().hasRedKeycard)
            {
                _anim.SetTrigger("OpenDoor");
            }
        }

        if (blueDoor)
        {
            if (other.GetComponent<Player>().hasBlueKeycard)
            {
                _anim.SetTrigger("OpenDoor");
            }
        }

        if (greenDoor)
        {
            if (other.GetComponent<Player>().hasGreenKeycard)
            {
                _anim.SetTrigger("EndLevel");
            }
        }

    }
}

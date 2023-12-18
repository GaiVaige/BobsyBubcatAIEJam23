using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]


public class Enemy : MonoBehaviour
{


    [Header("References")]
    public Transform _pc;
    Vector3 _lastKnownPos;
    CharacterController _cc;

    [Header("PlayerFollowSettings")]
    public bool canSeePlayer;
    public float checkDistance;
    bool playerInRangeOfCheck;
    public float moveSpeed;
    Vector3 moveDir;

    [Header("Basic State Checking Debugs")]
    public bool chasing;
    public bool waiting;
    





    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
        canSeePlayer = false;
        _pc = FindObjectOfType<Player>().transform;
        _lastKnownPos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 checkDir = _lastKnownPos - transform.position;
        Debug.Log(checkDir.magnitude);

        if (playerInRangeOfCheck)
        {
            CheckForLOS();
        }

        if (canSeePlayer)
        {
            UpdateRot();
            _lastKnownPos = _pc.position;
            moveDir = _lastKnownPos - transform.position;
            chasing = true;
            waiting = false;
        }


        if (chasing)
        {
            _cc.Move(moveDir * moveSpeed * Time.deltaTime);
        }

        if (checkDir.magnitude < 1)
        {
            chasing = false;
            waiting = true;
        }


        if (Vector3.Distance(this.transform.position, _pc.position) <= checkDistance)
        {
            playerInRangeOfCheck = true;
        }
        else
        {
            playerInRangeOfCheck = false;
        }
    }



    private void OnDrawGizmos()
    {
        //if (playerInRangeOfCheck) Debug.DrawLine(this.transform.position, _pc.position); 
    }

    public void UpdateRot()
    {
        transform.forward = transform.position - _pc.position;
    }

    public void CheckForLOS()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, _pc.position - transform.position, out hit, checkDistance, LayerMask.GetMask("Level"));

        if (hit.collider != null)
        {
            canSeePlayer = false;
            Debug.DrawRay(transform.position, _pc.position - transform.position, Color.red);
        }
        else
        {
            canSeePlayer = true;
            Debug.DrawRay(transform.position, _pc.position - transform.position, Color.green);
        }
    }
}

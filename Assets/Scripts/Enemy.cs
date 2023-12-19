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

    [Header("Enemy Settings")]
    public bool canSeePlayer;
    public float checkDistance;
    bool playerInRangeOfCheck;
    public float moveSpeed;
    Vector3 moveDir;
    public float fireRange;
    public float enemyPostShootWaitTime;
    public float bulletSpeed;
    public int bulletDam;

    [Header("Basic State Checking Debugs")]
    public bool chasing;
    public bool waiting;
    public bool shooting;
    bool coolingDown;
    public GameObject bulletToSpawn;
    





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
        float pDist = Vector3.Distance(this.transform.position, _pc.position);


        if (pDist <= checkDistance)
        {
            playerInRangeOfCheck = true;
        }
        else
        {
            playerInRangeOfCheck = false;
        }

        if(pDist <= fireRange)
        {
            chasing = false;
            waiting = false;
            shooting = true;
        }
        else
        {
            chasing = true;
            waiting = false;
            shooting = false;
        }


        Vector3 checkDir = _lastKnownPos - transform.position;
        Debug.Log(checkDir.magnitude);


        if (!shooting)
        {
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
            }


            if (chasing)
            {
                waiting = false;
                shooting = false;
                _cc.Move(moveDir * moveSpeed * Time.deltaTime);
            }

            if (checkDir.magnitude < 1)
            {
                chasing = false;
                waiting = true;
            }
        }

        if (shooting && !coolingDown)
        {
            UpdateRot();
            GameObject go = Instantiate(bulletToSpawn, this.transform);
            Bullet b = go.GetComponent<Bullet>();
            b.moveSpeed = bulletSpeed;
            b.damage = bulletDam;
            go.transform.rotation = this.transform.rotation;
            go.transform.parent = null;
            coolingDown = true;
            StartCoroutine(EnemyWaitAfterShoot(enemyPostShootWaitTime));

        }



    }



    private void OnDrawGizmos()
    {
        //if (playerInRangeOfCheck) Debug.DrawLine(this.transform.position, _pc.position); 
    }

    public void UpdateRot()
    {
        transform.forward = _pc.position - transform.position;
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

    public IEnumerator EnemyWaitAfterShoot(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        coolingDown = false;
        
    }
}

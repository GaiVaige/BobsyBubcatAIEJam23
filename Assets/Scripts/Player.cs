using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//requirements
[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{

    [Header("Movement Settings")]
    float horizontalInput;
    float verticalInput;
    public float moveSpeed;
    Vector3 moveDirection;
    Vector3 mousePosition;

    [Header("Camera Speed Settings")]
    float rotationX;
    public float lookSpeed;
    public float lookXLimit;

    [Header("Gun Settings")]
    public int currentAmmo;
    public int maxAmmo;
    bool outOfAmmo;
    bool canFire;
    public float DEBUGWAITTIMEGUN;

    [Header("Keycard Inventory")]
    public bool hasBlueKeycard;
    public bool hasRedKeycard;

    [Header("Object References")]
    public GameObject _playerCam;
    public Camera _pc;
    CharacterController _cc;
    Animator _anim;
    public BoxCollider _bc;


    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _pc = GetComponentInChildren<Camera>();
        _playerCam = _pc.gameObject;
        _bc.enabled = false;
        canFire = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        DoMovement();
        DoRotation();

        if (canFire)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }

    }

    public void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }


    public void DoMovement()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        float totalMoveSpeedH = horizontalInput * moveSpeed;
        float totalMoveSpeedV = verticalInput * moveSpeed;

        moveDirection = (forward * totalMoveSpeedV) + (right * totalMoveSpeedH);
        moveDirection.y -= 9.8f;

        _cc.Move(moveDirection * Time.deltaTime);
    }

    public void DoRotation()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        _playerCam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    public void Fire()
    {
        Debug.Log("Fire");
        canFire = false;
        _bc.enabled = true;
        StartCoroutine(testHold(DEBUGWAITTIMEGUN));


    }

    public void ShotgunAnimEnd()
    {
        _bc.enabled = _bc.enabled = false;
    }



    //testing only
    IEnumerator testHold(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        _bc.enabled = false;
        canFire = true;
    }

    public void setKeycardBool(string boolName)
    {
        if(boolName == "hasRedKeycard")
        {
            hasRedKeycard = true;
        }

        if(boolName == "hasBlueKeycard")
        {
            hasBlueKeycard = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFunctionsGun : MonoBehaviour
{
    Player _pc;
    void Start()
    {
        _pc = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload()
    {
        _pc.ReloadFun();
    }

    public void ShotEnd()
    {
        _pc.DoneShoot();
    }

    public void CollAct()
    {
        _pc.TurnOnColl();
    }
}

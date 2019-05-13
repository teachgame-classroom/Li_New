﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightWeapon : Weapon
{
    protected override float FireInterval
    {
        get { return 0.5f; }
    }

    protected override string fireClipName { get { return "Sound Effect (4)"; } }

    public StraightWeapon(Transform[] shotPosTrans, bool isPlayerWeapon) : base(11, shotPosTrans, isPlayerWeapon)
    {

    }

    protected override void Shoot(Transform shotPos)
    {
        shotPos.right = Vector3.left;
        base.Shoot(shotPos);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMine : StateBase
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gammaController.Shoot();
    }
}


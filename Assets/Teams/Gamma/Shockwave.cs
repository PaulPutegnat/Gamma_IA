using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : StateBase
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gammaController.Shockwave();
    }
}

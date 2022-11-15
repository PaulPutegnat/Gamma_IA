using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePoint : StateBase
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gammaController.CalculNextPointToGo();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Think : StateBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RaiseStateChanged(nameof(Think), nameof(OnStateEnter));
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RaiseStateChanged(nameof(Think), nameof(OnStateExit));
    }
}

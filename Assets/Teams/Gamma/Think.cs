using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Think : StateBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RaiseStateChanged(nameof(Think), nameof(OnStateEnter));
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (gammaController.HasToShootEnemy())
        {
            animator.SetTrigger("Shoot Enemy");
            return;
        }

        if (gammaController.HasToShootMine())
        {
            animator.SetTrigger("Shoot Mine");
            return;
        }

        if (gammaController.HasToChoosePoint())
        {
            animator.SetTrigger("Choose Point");
            return;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RaiseStateChanged(nameof(Think), nameof(OnStateExit));
    }
}

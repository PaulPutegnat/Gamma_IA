using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Think : StateBase
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (gammaController == null)
            return;
        
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

        if (gammaController.HasToFireShockwave())
        {
            animator.SetTrigger("Shockwave");
            return;
        }
    }
}

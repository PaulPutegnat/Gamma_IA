using UnityEngine;

public class Mine : StateBase
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gammaController.DropMine();
        
        if (gammaController.CanToDropMine())
        {
            animator.SetTrigger("Mine");
        }
    }
}

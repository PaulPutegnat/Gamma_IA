using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DoNotModify;
using UnityEngine;


namespace IIM
{
    [TaskCategory("IIM")]
    public class CheckEnergie : Action
    {
        [BehaviorDesigner.Runtime.Tasks.Tooltip("Variable")]
        public SharedFloat energieMin = 0.4f;
        
        public override TaskStatus OnUpdate()
        {
            return GameManager.Instance.GetGameData().GetSpaceShipForOwner(0).Energy >= energieMin.Value ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}

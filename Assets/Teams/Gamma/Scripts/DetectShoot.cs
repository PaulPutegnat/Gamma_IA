using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DoNotModify;
using UnityEngine;

namespace IIM
{
    [TaskCategory("IIM")]
    public class DetectShoot : Action
    {
        private const int bulletLayer = 14;

        [BehaviorDesigner.Runtime.Tasks.Tooltip("Variables")] 
        public SharedFloat radius = 4f;

        public override TaskStatus OnUpdate()
        {
            Vector2 pos = GameManager.Instance.GetGameData().GetSpaceShipForOwner(0).Position;
            Collider2D[] obj = Physics2D.OverlapCircleAll(pos, radius.Value);
            
            foreach (var o in obj)
            {
                if (o.gameObject.layer == 14)
                    // Debug.Log("debug " + o.gameObject.name);
                    // if (o.GetComponent<Bullet>().)
                return TaskStatus.Success;
            }
            
            return TaskStatus.Failure;
        }
    }
}

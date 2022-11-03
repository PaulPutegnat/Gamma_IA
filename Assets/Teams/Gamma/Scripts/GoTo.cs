using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace IIM
{
	[TaskCategory("IIM")]
	public class GoTo : Action
	{
		public enum OPERATOR
		{
			SET = 0,
		}

		[Tooltip("Variable to modify")]
		public SharedBool IsOurPoint;

		[Tooltip("Modification operator")]
		OPERATOR op;

		[Tooltip("Value used with operator")]
		public SharedBool IsOurPointBool;

		public override TaskStatus OnUpdate()
		{
			switch (op)
			{
				case OPERATOR.SET: IsOurPointBool.Value = IsOurPoint.Value; break;
			}

			if (!IsOurPointBool.Value)
			{
				return TaskStatus.Success;
			}
			else 
			{

				return TaskStatus.Failure;
			}
			
		}
	}
}
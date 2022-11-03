using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace IIM
{
	[TaskCategory("IIM")]
	public class GoTo : Action
	{
		public enum OPERATOR
		{
			SETX = 0,
			SETY = 1,
		}

		[Tooltip("Variable to modify")]
		public SharedInt AposX;
		public SharedInt AposY;

		public SharedInt BposX;
		public SharedInt BposY;

		[Tooltip("Modification operator")]
		public OPERATOR opa;
		public OPERATOR opb;


		[Tooltip("Value used with operator")]
		public SharedInt AposX_Value;
		public SharedInt AposY_Value;

		public SharedInt BposX_Value;
		public SharedInt BposY_Value;

		public override TaskStatus OnUpdate()
		{
			switch (opa)
			{
				case OPERATOR.SETX: AposX_Value.Value = AposX.Value; break;
				case OPERATOR.SETY: AposY_Value.Value = AposY.Value; break;
			}

			switch (opb)
			{
				case OPERATOR.SETX: BposX_Value.Value = BposX.Value; break;
				case OPERATOR.SETY: BposY_Value.Value = BposY.Value; break;
			}
			return TaskStatus.Success;
		}
	}
}
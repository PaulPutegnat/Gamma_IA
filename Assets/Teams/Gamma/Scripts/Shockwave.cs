using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DoNotModify;

namespace GammaTeam
{
	[TaskCategory("IIM")]
	public class Shockwave : Action
	{
		public TaskStatus CastShockwave()
		{
			return TaskStatus.Success;
		}
	}
}
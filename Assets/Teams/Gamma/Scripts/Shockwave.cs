using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DoNotModify;

namespace GammaTeam
{
	[TaskCategory("IIM")]
	public class Shockwave : Action
	{
		GameData gData = GameManager.Instance.GetGameData();
		SpaceShipView spaceship;
		SpaceShip ship;

		public TaskStatus CastShockwave()
		{
			spaceship = gData.GetSpaceShipForOwner(spaceship.Owner);
			if (gData.GetSpaceShipForOwner(1 - spaceship.Owner).Orientation != spaceship.Orientation)
            {
				if(gData.GetSpaceShipForOwner(1 - spaceship.Owner).Position.x == spaceship.Position.x - 100 || gData.GetSpaceShipForOwner(1 - spaceship.Owner).Position.y == spaceship.Position.y)
                {
					ship.FireShockwave();
                }
            }
			return TaskStatus.Success;
		}
	}
}
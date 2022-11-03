using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using DoNotModify;

namespace GammaTeam
{

	public class GammaController : BaseSpaceShipController
	{
		private BehaviorManager.BehaviorTree tree;
		
		private WayPointView wayPointA;
		private float nextAngleToTurn;
		private bool hasToMove = false;
		
		public override void Initialize(SpaceShipView spaceship, GameData data)
		{
			nextAngleToTurn = spaceship.Orientation;
		}

		public override InputData UpdateInput(SpaceShipView spaceship, GameData data)
		{
			SpaceShipView otherSpaceship = data.GetSpaceShipForOwner(1 - spaceship.Owner);
			float thrust = 1.0f;
			float targetOrient = nextAngleToTurn;
			bool needShoot = AimingHelpers.CanHit(spaceship, otherSpaceship.Position, otherSpaceship.Velocity, 0.15f);
			return new InputData(thrust, targetOrient, needShoot, false, false);
		}

		public void CalculNextPointToGo()
		{
			wayPointA = null;

			List<WayPointView> wayPointViews = GameManager.Instance.GetGameData().WayPoints;

			for (int i = 0; i < wayPointViews.Count; i++)
			{
				if (wayPointViews[i].Owner == 0) // Change to our ship id
				{
					continue;
				}

				if (wayPointA == null)
				{
					wayPointA = wayPointViews[i];
				}
				else if (Vector2.Distance(wayPointA.Position, transform.position) >
				         Vector2.Distance(wayPointViews[i].Position, transform.position)) // Get position of our ship
				{
					wayPointA = wayPointViews[i];
				}

				hasToMove = true;
				nextAngleToTurn = Quaternion.LookRotation(wayPointA.Position).eulerAngles.y + transform.rotation.y;
			}
		}
	}
}

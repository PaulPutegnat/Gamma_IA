using System;
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
			
			CalculNextPointToGo(spaceship); // Debug
		}

		public override InputData UpdateInput(SpaceShipView spaceship, GameData data)
		{
			SpaceShipView otherSpaceship = data.GetSpaceShipForOwner(1 - spaceship.Owner);
			
			if (wayPointA == null || wayPointA.Owner == spaceship.Owner)
			{
				CalculNextPointToGo(spaceship);
			}
			
			Vector3 vec = wayPointA.Position - (Vector2)transform.position;
			float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
			float speed = Mathf.Lerp(0.25f, 1f, angle <= 30f ? 1f : angle >= 90f ? 0f : 0.5f);
			
			float thrust = Math.Abs(spaceship.Orientation - nextAngleToTurn) > 5f ? 0f : 1f;
			float targetOrient = nextAngleToTurn;
			bool needShoot = AimingHelpers.CanHit(spaceship, otherSpaceship.Position, otherSpaceship.Velocity, 0.15f);
			return new InputData(thrust, targetOrient, needShoot, false, false);
		}

		public void CalculNextPointToGo(SpaceShipView _spaceShip)
		{
			wayPointA = null;

			List<WayPointView> wayPointViews = GameManager.Instance.GetGameData().WayPoints;

			for (int i = 0; i < wayPointViews.Count; i++)
			{
				if (wayPointViews[i].Owner == _spaceShip.Owner) // Change to our ship id
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
			}
			
			hasToMove = true;

			Vector3 vec = wayPointA.Position - (Vector2)transform.position;
			float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
			nextAngleToTurn = angle + 180f;
			Debug.Log(nextAngleToTurn);
		}
	}
}

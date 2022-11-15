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

		private SpaceShipView ourSpaceship;
		private GameData gameData;

		[SerializeField] private LayerMask minesLayerMask;

		float speed;
		bool needShoot;

        public override void Initialize(SpaceShipView spaceship, GameData data)
		{
			ourSpaceship = spaceship;
			gameData = data;
			speed = 0f;
        }

		public override InputData UpdateInput(SpaceShipView spaceship, GameData data)
		{
			SpaceShipView otherSpaceship = data.GetSpaceShipForOwner(1 - spaceship.Owner);
			
			/*if (wayPointA == null || wayPointA.Owner == spaceship.Owner)
			{
				CalculNextPointToGo(spaceship);
			}*/

			float thrust = 0.5f;
			float targetOrient = wayPointA != null ? Quaternion.LookRotation(Vector3.forward, wayPointA.Position - spaceship.Position)
				.eulerAngles.z + 90f : spaceship.Orientation;
			
			//
			
			speed = Mathf.Lerp(0f, 1f, targetOrient - spaceship.Orientation <= 20f ? 1f : spaceship.Orientation >= 50f ? 0f : 0.5f);
			
			Debug.Log(speed);

			return new InputData(speed, targetOrient, needShoot, false, false);
		}

		public void CalculNextPointToGo()
		{
			wayPointA = null;

			List<WayPointView> wayPointViews = GameManager.Instance.GetGameData().WayPoints;

			for (int i = 0; i < wayPointViews.Count; i++)
			{
				if (wayPointViews[i].Owner == ourSpaceship.Owner)
				{
					continue;
				}

				if (wayPointA == null)
				{
					wayPointA = wayPointViews[i];
				}
				else if (Vector2.Distance(ourSpaceship.Position, wayPointA.Position) >
				         Vector2.Distance(ourSpaceship.Position, wayPointViews[i].Position))
				{
					wayPointA = wayPointViews[i];
				}
			}
		}

		public void Shoot() 
		{
            needShoot = true;
        }
    }
}

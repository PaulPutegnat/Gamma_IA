using System;
using System.Collections.Generic;
using UnityEngine;
using DoNotModify;

namespace GammaTeam
{
	public class GammaController : BaseSpaceShipController
	{
		private WayPointView wayPointA;

		private SpaceShipView ourSpaceship;
		private GameData gameData;

		private bool _fireShockwave;

		[SerializeField] private LayerMask minesLayerMask;
		
		private bool needShoot;
		private bool needMine;

        public override void Initialize(SpaceShipView spaceship, GameData data)
		{
			ourSpaceship = spaceship;
			gameData = data;

			foreach (StateBase stateBase in GetComponent<Animator>().GetBehaviours<StateBase>())
			{
				stateBase.gammaController = this;
			}
		}

		public override InputData UpdateInput(SpaceShipView spaceship, GameData data)
		{
			gameData = data;
			ourSpaceship = spaceship;
			
			float thrust = 0.5f;
			float targetOrient = wayPointA != null ? Quaternion.LookRotation(Vector3.forward, wayPointA.Position - spaceship.Position)
				.eulerAngles.z + 90f : spaceship.Orientation;
			
			float speed = Mathf.Lerp(0f, 1f, targetOrient - spaceship.Orientation <= 20f ? 1f : spaceship.Orientation >= 50f ? 0f : 0.5f);

			return new InputData(speed, targetOrient, needShoot, needMine, _fireShockwave);
		}

		public bool HasToShootEnemy()
		{
			SpaceShipView otherSpaceship = gameData.GetSpaceShipForOwner(1 - ourSpaceship.Owner);
			return AimingHelpers.CanHit(ourSpaceship, otherSpaceship.Position, otherSpaceship.Velocity, 0.15f);
		}
		
		public bool HasToShootMine()
		{
			// Shoot mine
			RaycastHit2D hit2D = Physics2D.Raycast(ourSpaceship.Position, ourSpaceship.LookAt, 5f, minesLayerMask);

			if (hit2D.collider != null && !hit2D.collider.CompareTag("Bullet") && hit2D.collider.CompareTag("Mine"))
			{
				return true;
			}

			return false;
		}

		public bool HasToChoosePoint()
		{
			return wayPointA == null || wayPointA.Owner == ourSpaceship.Owner;
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
		
		private bool IsBetween(double testValue, double bound1, double bound2)
		{
			return (testValue >= Math.Min(bound1, bound2) && testValue <= Math.Max(bound1, bound2));
		}
		
		public void Shockwave()
        {
	        _fireShockwave = true;
        }

		public bool HasToFireShockwave()
        {
			SpaceShipView otherSpaceShip = gameData.GetSpaceShipForOwner(1 - ourSpaceship.Owner);
			if (IsBetween(otherSpaceShip.Position.x, ourSpaceship.Position.x - 3, ourSpaceship.Position.x + 3) || IsBetween(otherSpaceShip.Position.y, ourSpaceship.Position.y - 3, ourSpaceship.Position.y + 3))
			{
				return true;
			}
			if (Physics.CheckSphere(ourSpaceship.Position, 3, minesLayerMask))
			{
				return true;
			}
			return false;
		}

		public bool CanToDropMine()
		{
			return ourSpaceship.Energy >= ourSpaceship.MineEnergyCost;
		}

		public void DropMine()
		{
			needMine = true;
		}
	}
}

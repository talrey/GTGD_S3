using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Enemy_NavDestinationReached : MonoBehaviour {
		
		private Enemy_Master em;
		private NavMeshAgent myNMA;
		private float checkRate;
		private float nextCheck;
		
		void OnEnable () {
			SetInitialReferences();
			checkRate = Random.Range(0.3f, 0.4f);
			
			em.EventEnemyDie += DisableThis;
		}

		void OnDisable () {
			em.EventEnemyDie -= DisableThis;
		}
		
		void Update () {
			if (Time.time > nextCheck) {
				nextCheck = Time.time + checkRate;
				CheckIfDestinationReached();
			}
		}

		void SetInitialReferences () {
			em = GetComponent<Enemy_Master>();
			if (GetComponent<NavMeshAgent>() != null) {
				myNMA = GetComponent<NavMeshAgent>();
			}
		}
		
		void CheckIfDestinationReached () {
			if (em.isOnRoute) {
				if (myNMA.remainingDistance <= myNMA.stoppingDistance) {
					em.isOnRoute = false;
					em.CallEventEnemyReachedNavTarget();
				}
			}
		}
		
		void DisableThis () {
			if (myNMA != null) {
				myNMA.enabled = false;
			}
			this.enabled = false;
		}
	}
}

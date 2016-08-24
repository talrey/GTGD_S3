using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Enemy_NavWander : MonoBehaviour {
		
		private Enemy_Master em;
		private NavMeshAgent myNMA;
		private float checkRate;
		private float nextCheck;
		private float wanderRange = 10;
		private Transform myTransform;
		private NavMeshHit navHit;
		private Vector3 wanderTarget;
		
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
				CheckIfIShouldWander();
			}
		}

		void SetInitialReferences () {
			em = GetComponent<Enemy_Master>();
			if (GetComponent<NavMeshAgent>() != null) {
				myNMA = GetComponent<NavMeshAgent>();
			}
			myTransform = transform;
		}
		
		void CheckIfIShouldWander () {
			if (em.myTarget == null && !em.isOnRoute && !em.isNavPaused) {
				if (RandomWanderTarget(myTransform.position, wanderRange, out wanderTarget)) {
					myNMA.SetDestination(wanderTarget);
					em.isOnRoute = true;
					em.CallEventEnemyWalking();
				}
			}
		}
		
		bool RandomWanderTarget (Vector3 center, float range, out Vector3 result) {
			Vector3 randomPoint = center + Random.insideUnitSphere * wanderRange;
			if (NavMesh.SamplePosition(randomPoint, out navHit, 1.0f, NavMesh.AllAreas)) {
				result = navHit.position;
				return true;
			} else {
				result = center;
				return false;
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

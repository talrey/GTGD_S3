using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Enemy_NavFlee : MonoBehaviour {
		
		public bool isFleeing;
		
		private Enemy_Master em;
		
		private NavMeshAgent myNMA;
		private NavMeshHit navHit;
		private Transform myTransform;
		public Transform fleeTarget;
		private Vector3 runPosition;
		private Vector3	directionToPlayer;
		
		[SerializeField]
		private float fleeRange = 25;
		[SerializeField]
		private float checkRate;
		private float nextCheck;
		
		void OnEnable () {
			SetInitialReferences();
			
			em.EventEnemyDie += DisableThis;
			em.EventEnemySetNavTarget += SetFleeTarget;
			em.EventEnemyHealthLow += IShouldFlee;
			em.EventEnemyHealthRecovered += IShouldStopFleeing;
		}

		void OnDisable () {
			em.EventEnemyDie -= DisableThis;
			em.EventEnemySetNavTarget -= SetFleeTarget;
			em.EventEnemyHealthLow -= IShouldFlee;
			em.EventEnemyHealthRecovered -= IShouldStopFleeing;
		}
		
		void Update () {
			if (Time.time > nextCheck) {
				nextCheck = Time.time + checkRate;
				CheckIfIShouldFlee();
			}
		}

		void SetInitialReferences () {
			em = GetComponent<Enemy_Master>();
			myTransform = transform;
			if (GetComponent<NavMeshAgent>() != null) {
				myNMA = GetComponent<NavMeshAgent>();
			}
			checkRate = Random.Range(0.3f, 0.4f);
		}
		
		void SetFleeTarget (Transform target) {
			fleeTarget = target;
		}
		
		void IShouldFlee () {
			isFleeing = true;
			if (GetComponent<Enemy_NavPursue>() != null) {
				GetComponent<Enemy_NavPursue>().enabled = false;
			}
		}
		
		void IShouldStopFleeing () {
			isFleeing = false;
			if (GetComponent<Enemy_NavPursue>() != null) {
				GetComponent<Enemy_NavPursue>().enabled = true;
			}
		}
		
		void CheckIfIShouldFlee () {
			if (isFleeing) {
				if (fleeTarget != null && !em.isOnRoute && !em.isNavPaused) {
					if (FleeTarget(out runPosition) && Vector3.Distance(myTransform.position, fleeTarget.position) < fleeRange) {
						myNMA.SetDestination(runPosition);
						em.CallEventEnemyWalking();
						em.isOnRoute = true;
					}
				}
			}
		}
		
		bool FleeTarget (out Vector3 result) {
			directionToPlayer = myTransform.position - fleeTarget.position;
			Vector3 checkPos = myTransform.position + directionToPlayer;
			
			if (NavMesh.SamplePosition(checkPos, out navHit, 1.0f, NavMesh.AllAreas)) {
				result = navHit.position;
				return true;
			} else {
				result = myTransform.position;
				return false;
			}
		}
		
		void DisableThis () {
			this.enabled = false;
		}
	}
}

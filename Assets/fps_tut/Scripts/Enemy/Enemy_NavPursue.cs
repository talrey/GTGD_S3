using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Enemy_NavPursue : MonoBehaviour {
		
		private Enemy_Master em;
		private NavMeshAgent myNMA;
		private float checkRate;
		private float nextCheck;
		
		void OnEnable () {
			SetInitialReferences();
			checkRate = Random.Range(0.1f, 0.2f);
			
			em.EventEnemyDie += DisableThis;
		}

		void OnDisable () {
			em.EventEnemyDie -= DisableThis;
		}
		
		void Update () {
			if (Time.time > nextCheck) {
				nextCheck = Time.time + checkRate;
				TryToChaseTarget();
			}
		}

		void SetInitialReferences () {
			em = GetComponent<Enemy_Master>();
			if (GetComponent<NavMeshAgent>() != null) {
				myNMA = GetComponent<NavMeshAgent>();
			}
		}
		
		void TryToChaseTarget () {
			if (em.myTarget != null && myNMA != null && !em.isNavPaused) {
				myNMA.SetDestination(em.myTarget.position);
				if (myNMA.remainingDistance > myNMA.stoppingDistance) {
					em.CallEventEnemyWalking();
					em.isOnRoute = true;
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

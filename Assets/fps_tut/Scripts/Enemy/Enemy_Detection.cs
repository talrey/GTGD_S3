using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Enemy_Detection : MonoBehaviour {
		
		private Enemy_Master em;
		private Transform myTrans;
		public Transform head;
		public LayerMask playerLayer;
		public LayerMask sightLayer;
		public float checkRate;
		public float nextCheck;
		public float detectRadius = 80;
		private RaycastHit hit;
		
		void OnEnable () {
			SetInitialReferences();
			
			em.EventEnemyDie += DisableThis;
		}

		void OnDisable () {
			em.EventEnemyDie -= DisableThis;
		}
		
		void Update () {
			CarryOutDetection();
		}

		void SetInitialReferences () {
			em = GetComponent<Enemy_Master>();
			myTrans = transform;
			if (head == null) {
				head = myTrans;
			}
			checkRate = Random.Range(0.8f, 1.2f);
		}
		
		bool CanPotentialTargetBeSeen (Transform target) {
			if (Physics.Linecast(head.position, target.position, out hit, sightLayer)) {
				if (hit.transform == target) {
					em.CallEventEnemySetNavTarget(target);
					return true;
				}
			}
			em.CallEventEnemyLostTarget();
			return false;
		}
		
		void CarryOutDetection () {
			if (Time.time > nextCheck) {
				nextCheck = Time.time + checkRate;
				
				Collider[] colliders = Physics.OverlapSphere(myTrans.position, detectRadius, playerLayer);
				
				if (colliders.Length > 0) {
					foreach (Collider potentialTarget in colliders) {
						if (potentialTarget.CompareTag(GM_References._playerTag)) {
							if (CanPotentialTargetBeSeen(potentialTarget.transform)) {
								break; // the check itself fires the event
							}
						}
					}
				} else {
					em.CallEventEnemyLostTarget();
				}
			}
		}
		
		void DisableThis () {
			this.enabled = false;
		}
	}
}

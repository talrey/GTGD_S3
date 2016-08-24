using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Enemy_RagdollActivation : MonoBehaviour {
		
		private Enemy_Master em;
		private Collider myCollider;
		private Rigidbody myRB;
		
		void OnEnable () {
			SetInitialReferences();
			
			em.EventEnemyDie += ActivateRagdoll;
		}

		void OnDisable () {
			em.EventEnemyDie -= ActivateRagdoll;
		}
		
		void SetInitialReferences () {
			em = transform.root.GetComponent<Enemy_Master>();
			if (GetComponent<Collider>() != null) {
				myCollider = GetComponent<Collider>();
			}
			if (GetComponent<Rigidbody>() != null) {
				myRB = GetComponent<Rigidbody>();
			}
		}
		
		void ActivateRagdoll () {
			if (myCollider != null) {
				myCollider.isTrigger = false;
				myCollider.enabled = true;
			}
			if (myRB != null) {
				myRB.isKinematic = false;
				myRB.useGravity = true;
			}
		}
	}
}

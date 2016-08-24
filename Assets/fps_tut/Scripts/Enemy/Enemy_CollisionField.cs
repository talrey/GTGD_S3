using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Enemy_CollisionField : MonoBehaviour {
		
		private Enemy_Master em;
		private Rigidbody rigidbodyStrikingMe;
		private int damageToApply;
		[SerializeField]
		public float massRequirement = 50;
		[SerializeField]
		public float speedRequirement = 5;
		[SerializeField]
		private float damageFactor = 0.1f;
		
		void OnEnable () {
			SetInitialReferences();
			
			em.EventEnemyDie += DisableThis;
		}

		void OnDisable () {
			em.EventEnemyDie -= DisableThis;
		}
		
		void SetInitialReferences () {
			em = transform.root.GetComponent<Enemy_Master>();
		}
		
		void OnTriggerEnter (Collider other) {
			if (other.GetComponent<Rigidbody>() != null) {
				rigidbodyStrikingMe = other.GetComponent<Rigidbody>();
				if (rigidbodyStrikingMe.mass >= massRequirement
				&& rigidbodyStrikingMe.velocity.sqrMagnitude > speedRequirement*speedRequirement) {
					damageToApply = (int)(damageFactor * rigidbodyStrikingMe.mass * rigidbodyStrikingMe.velocity.magnitude);
					em.CallEventEnemyDecreaseHealth(damageToApply);
				}
			}
		}
		
		void DisableThis () {
			gameObject.SetActive(false);
		}
	}
}

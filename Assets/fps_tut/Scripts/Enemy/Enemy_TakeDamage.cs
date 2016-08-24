using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Enemy_TakeDamage : MonoBehaviour {
		
		private Enemy_Master em;
		public int damageMultiplier = 1;
		public bool shouldRemoveCollider = true;
		
		void OnEnable () {
			SetInitialReferences();
			
			em.EventEnemyDie += RemoveThis;
		}

		void OnDisable () {
			em.EventEnemyDie -= RemoveThis;
		}
		
		void SetInitialReferences () {
			em = transform.root.GetComponent<Enemy_Master>();
		}
		
		public void ProcessDamage (int damage) {
			int damageToApply = damage * damageMultiplier;
			em.CallEventEnemyDecreaseHealth(damageToApply);
		}
		
		void RemoveThis () {
			if (shouldRemoveCollider) {
				if (GetComponent<Collider>() != null) {
					Destroy(GetComponent<Collider>());
				}
				if (GetComponent<Rigidbody>() != null) {
					Destroy(GetComponent<Rigidbody>());
				}
			}
			Destroy(this);
		}
	}
}

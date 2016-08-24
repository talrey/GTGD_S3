using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_Colliders : MonoBehaviour {
		/* Disables hitboxes on an item when it's being held.
		 * Disable this script for fun G-Mod-style item smashing.
		 * Probably.
		 */
		private Item_Master im;
		public Collider[] colliders;
		public PhysicMaterial myPM;
		
		void OnEnable () {
			SetInitialReferences();
			CheckIfStartsInInventory();
			
			im.EventObjectThrow += EnableColliders;
			im.EventObjectPickup += DisableColliders;
		}

		void OnDisable () {
			im.EventObjectThrow -= EnableColliders;
			im.EventObjectPickup -= DisableColliders;
		}
		
		void SetInitialReferences () {
			im = GetComponent<Item_Master>();
		}
		
		void CheckIfStartsInInventory () {
			if (transform.root.CompareTag(GM_References._playerTag)) {
				DisableColliders();
			}
		}
		
		void EnableColliders () {
			if (colliders.Length > 0) {
				foreach (Collider col in colliders) {
					col.enabled = true;
					if (myPM != null) {
						col.material = myPM;
					}
				}
			}
		}
		
		void DisableColliders () {
			if (colliders.Length > 0) {
				foreach (Collider col in colliders) {
					col.enabled = false;
				}
			}
		}
	}
}

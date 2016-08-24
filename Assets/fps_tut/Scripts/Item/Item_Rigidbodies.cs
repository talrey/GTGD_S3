using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_Rigidbodies : MonoBehaviour {
		/* if an item has multible RBs, this can turn on or off "ragdolling"
		 * which will make it easier to throw or drag the item 
		 * (it won't flip out when held)
		 */
		private Item_Master im;
		public Rigidbody[] bodies;
		
		void OnEnable () {
			SetInitialReferences();
			CheckIfStartsInInventory();
			im.EventObjectThrow += SetAllKinematicFalse;
			im.EventObjectPickup += SetAllKinematicTrue;
		}

		void OnDisable () {
			im.EventObjectThrow -= SetAllKinematicFalse;
			im.EventObjectPickup -= SetAllKinematicTrue;
		}
		
		void SetInitialReferences () {
			im = GetComponent<Item_Master>();
		}
		
		void CheckIfStartsInInventory () {
			if (transform.root.CompareTag(GM_References._playerTag)) {
				SetAllKinematic(true);
			}
		}
		
		void SetAllKinematicFalse () {
			SetAllKinematic(false);
		}
		
		void SetAllKinematicTrue () {
			SetAllKinematic(true);
		}
		
		void SetAllKinematic (bool isKinematic) {
			if (bodies.Length > 0) {
				foreach (Rigidbody body in bodies) {
					body.isKinematic = isKinematic;
				}
			}
		}
	}
}

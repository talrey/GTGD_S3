using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_SetRotation : MonoBehaviour {
		/* rectifies the rotation of an item when it's picked up
		 */
		
		private Item_Master im;
		public Quaternion itemLocalRot;
		
		void OnEnable () {
			SetInitialReferences();
			SetRotationOnPlayer();
			
			im.EventObjectPickup += SetRotationOnPlayer;
		}

		void OnDisable () {
			im.EventObjectPickup -= SetRotationOnPlayer;
		}
		
		void SetInitialReferences () {
			im = GetComponent<Item_Master>();
		}
		
		void SetRotationOnPlayer () {
			if (transform.root.CompareTag(GM_References._playerTag)) {
				transform.localRotation = itemLocalRot;
			}
		}
	}
}

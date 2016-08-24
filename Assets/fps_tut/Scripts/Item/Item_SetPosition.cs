using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_SetPosition : MonoBehaviour {
		/* rectifies the position of an item when it's picked up
		 */
		
		private Item_Master im;
		public Vector3 itemLocalPos;
		
		void OnEnable () {
			SetInitialReferences();
			SetPositionOnPlayer();
			
			im.EventObjectPickup += SetPositionOnPlayer;
		}

		void OnDisable () {
			im.EventObjectPickup -= SetPositionOnPlayer;
		}
		
		void SetInitialReferences () {
			im = GetComponent<Item_Master>();
		}
		
		void SetPositionOnPlayer () {
			if (transform.root.CompareTag(GM_References._playerTag)) {
				transform.localPosition = itemLocalPos;
			}
		}
	}
}

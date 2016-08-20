using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_Pickup : MonoBehaviour {
		
		private Item_Master im;
		
		void OnEnable () {
			SetInitialReferences();
			im.EventPickupAction += CarryOutPickupActions;
		}

		void OnDisable () {
			im.EventPickupAction -= CarryOutPickupActions;
		}

		void SetInitialReferences () {
			im = GetComponent<Item_Master>();
		}
		
		void CarryOutPickupActions (Transform tParent) {
			transform.SetParent(tParent);
			im.CallEventObjectPickup();
			transform.gameObject.SetActive(false);
		}
	}
}

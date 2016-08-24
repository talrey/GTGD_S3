using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_Ammo : MonoBehaviour {
		
		private Item_Master im;
		public GameObject plGO;
		public string ammoName;
		public int quantity;
		public bool isTriggerPickup;
		
		void OnEnable () {
			SetInitialReferences();
			
			im.EventObjectPickup += TakeAmmo;
		}

		void OnDisable () {
			im.EventObjectPickup -= TakeAmmo;
		}
		
		void SetInitialReferences () {
			im = GetComponent<Item_Master>();
			plGO = GM_References._player;
			
			if (isTriggerPickup) {
				if (GetComponent<Collider>() != null) {
					GetComponent<Collider>().isTrigger = true;
				}
				if (GetComponent<Rigidbody>() != null) {
					GetComponent<Rigidbody>().isKinematic = true;
				}
			}
		}
		
		void OnTriggerEnter (Collider other) {
			if (other.CompareTag(GM_References._playerTag) && isTriggerPickup) {
				TakeAmmo();
			}
		}
		
		void TakeAmmo () {
			plGO.GetComponent<Player_Master>().CallEventPickedUpAmmo(ammoName, quantity);
			Destroy(gameObject);
		}
	}
}

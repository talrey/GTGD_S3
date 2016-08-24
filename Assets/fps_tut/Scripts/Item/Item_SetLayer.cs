using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_SetLayer : MonoBehaviour {
		/*
		 * Sets the layer of an item, to prevent a held item from
		 * clipping into world objects.
		 */
		 
		private Item_Master	im;
		public string itemThrowLayer;  // the layer visible to the world camera
		public string itemPickupLayer; // the layer visible to the HUD camera
		
		void OnEnable () {
			SetInitialReferences();
			SetLayerOnEnable();
			
			im.EventObjectPickup += SetItemToPickupLayer;
			im.EventObjectThrow += SetItemToThrowLayer;
		}

		void OnDisable () {
			im.EventObjectPickup -= SetItemToPickupLayer;
			im.EventObjectThrow -= SetItemToThrowLayer;
		}
		
		void SetInitialReferences () {
			im = GetComponent<Item_Master>();
		}
		
		void SetItemToThrowLayer () {
			SetLayer(transform, itemThrowLayer);
		}
		
		void SetItemToPickupLayer () {
			SetLayer(transform, itemPickupLayer);
		}
		
		void SetLayerOnEnable () {
			if (itemPickupLayer == "") {
				itemPickupLayer = "Weapon";
			}
			if (itemThrowLayer == "") {
				itemThrowLayer = "Item";
			}
			if (transform.root.CompareTag(GM_References._playerTag)) {
				SetItemToPickupLayer();
			} else {
				SetItemToThrowLayer();
			}
		}
		
		void SetLayer (Transform tr, string itemLayerName) {
			tr.gameObject.layer = LayerMask.NameToLayer(itemLayerName);
			
			foreach (Transform child in tr) {
				SetLayer(child, itemLayerName);
			}
		}
	}
}

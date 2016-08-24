using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_UI : MonoBehaviour {
		/* turns on and off a held item's UI
		 */
		
		private Item_Master im;
		public GameObject ui;
		
		void OnEnable () {
			SetInitialReferences();
			
			im.EventObjectThrow += DisableUI;
			im.EventObjectPickup += EnableUI;
		}

		void OnDisable () {
			im.EventObjectThrow -= DisableUI;
			im.EventObjectPickup -= EnableUI;
		}
		
		void SetInitialReferences () {
			im = GetComponent<Item_Master>();
		}
		
		void EnableUI () {
			if (ui != null) {
				ui.SetActive(true);
			}
		}
		
		void DisableUI () {
			if (ui != null) {
				ui.SetActive(false);
			}
		}
	}
}

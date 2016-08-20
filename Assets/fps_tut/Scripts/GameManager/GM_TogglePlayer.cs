using UnityEngine;
using System.Collections;

using UnityStandardAssets.Characters.FirstPerson;

namespace Talrey {
	public class GM_TogglePlayer : MonoBehaviour {
		
		public FirstPersonController player;
		private GM_Master manager;
		
		void OnEnable () {
			SetInitialReferences();
			manager.MenuToggleEvent += TogglePlayerController;
			manager.InventoryUIToggleEvent += TogglePlayerController;
		}
		
		void OnDisable () {
			manager.MenuToggleEvent -= TogglePlayerController;
			manager.InventoryUIToggleEvent += TogglePlayerController;
		}
		
		void SetInitialReferences () {
			manager = GetComponent<GM_Master>();
		}
		
		void TogglePlayerController () {
			if (player != null) {
				player.enabled = !player.enabled;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

namespace Talrey {
	public class GM_TogglePause : MonoBehaviour {
		
		private GM_Master manager;
		private bool isPaused;
		
		void OnEnable () {
			SetInitialReferences();
			manager.MenuToggleEvent += TogglePause;
			manager.InventoryUIToggleEvent += TogglePause;
		}
		
		void OnDisable () {
			manager.MenuToggleEvent -= TogglePause;
			manager.InventoryUIToggleEvent -= TogglePause;
		}
		
		void SetInitialReferences () {
			manager = GetComponent<GM_Master>();
		}
		
		void TogglePause () {
			if (isPaused) {
				Time.timeScale = 1;
			} else {
				Time.timeScale = 0;
			}
			isPaused = !isPaused;
		}
	}
}

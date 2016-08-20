using UnityEngine;
using System.Collections;

namespace Talrey {

	public class GM_ToggleCursor : MonoBehaviour {
	
		private GM_Master manager;
		private bool isCursorLocked = true;
	
		void OnEnable () {
			SetInitialReferences();
			manager.MenuToggleEvent += ToggleCursorState;
			manager.InventoryUIToggleEvent += ToggleCursorState;
		}
		
		void OnDisable () {
			manager.MenuToggleEvent -= ToggleCursorState;
			manager.InventoryUIToggleEvent -= ToggleCursorState;
		}
		
		void Update () {
			CheckIfCursorShouldBeLocked();
		}
		
		void SetInitialReferences () {
			manager = GetComponent<GM_Master>();
		}
		
		void ToggleCursorState () {
			isCursorLocked = !isCursorLocked;
		}
		
		void CheckIfCursorShouldBeLocked () {
			if (isCursorLocked) {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			} else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}
	}
}

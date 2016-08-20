using UnityEngine;
using System.Collections;

namespace Talrey {
	public class GM_ToggleInventoryUI : MonoBehaviour {
	
		[Tooltip("Does this game mode have an inventory?")]
		public bool hasInventory;
		public GameObject inventoryUI;
		public string toggleInventoryButton;
		
		private GM_Master manager;
		
		void Start () {
			SetInitialReferences();
		}
		
		void Update () {
			CheckForInventoryUIToggleRequest();
		}
		
		void SetInitialReferences () {
			manager = GetComponent<GM_Master>();
			
			if (toggleInventoryButton == "") {
				Debug.LogWarning("No button assigned to inventory toggling! Disabling inventory toggle.");
				this.enabled = false;
			}
		}
		
		void CheckForInventoryUIToggleRequest () {
			if (Input.GetButtonUp(toggleInventoryButton) && !manager.isMenuOn && !manager.isGameOver && hasInventory) {
				ToggleInventoryUI();
			}
		}
		
		public void ToggleInventoryUI () {
			if (inventoryUI != null) {
				inventoryUI.SetActive(!inventoryUI.activeSelf);
				manager.isInventoryUIOn = !manager.isInventoryUIOn;
				manager.CallEventInventoryUIToggle();
			}
		}
	}
}

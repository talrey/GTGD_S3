using UnityEngine;
using System.Collections;

namespace Talrey {
	public class GM_ToggleMenu : MonoBehaviour {
		
		private GM_Master manager;
		public GameObject menu;
		
		void Start () {
			ToggleMenu(); // menu starts disabled, this turns it on
		}
		
		void Update () {
			CheckForMenuToggleRequest();
		}
		
		void OnEnable () {
			SetInitialReferences();
			manager.GameOverEvent += ToggleMenu;
		}
		
		void OnDisable () {
			manager.GameOverEvent -= ToggleMenu;
		}
		
		void SetInitialReferences () {
			manager = GetComponent<GM_Master>();
		}
		
		void CheckForMenuToggleRequest () {
			if (Input.GetKeyUp(KeyCode.Escape) && !manager.isGameOver && !manager.isInventoryUIOn) {
				ToggleMenu();
			}
		}
		
		void ToggleMenu () {
			if (menu != null) {
				menu.SetActive(!menu.activeSelf);
				manager.isMenuOn = !manager.isMenuOn;
				manager.CallEventMenuToggle();
			} else {
				Debug.LogError("Menu object is null!");
			}
		}
	}
}

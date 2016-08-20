using UnityEngine;
using System.Collections;

namespace Talrey {
	public class GM_PanelHelp : MonoBehaviour {
		
		public GameObject panelHelp;
		private GM_Master manager;
		
		void OnEnable () {
			SetInitialReferences();
			manager.GameOverEvent += TurnOffPanelHelp;
		}

		void OnDisable () {
			manager.GameOverEvent -= TurnOffPanelHelp;
		}

		void SetInitialReferences () {
			manager = GetComponent<GM_Master>();
		}
		
		void TurnOffPanelHelp () {
			if (panelHelp != null)
			{
				panelHelp.SetActive(false);
			}
		}
	}
}

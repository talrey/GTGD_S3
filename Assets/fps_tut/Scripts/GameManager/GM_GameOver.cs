using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

namespace Talrey {
	public class GM_GameOver : MonoBehaviour {
	
		private GM_Master manager;
		public GameObject panelGameOver;
		
		void OnEnable () {
			SetInitialReferences();
			
			manager.GameOverEvent += TurnOnGameOverPanel;
		}
		
		void OnDisable () {
			manager.GameOverEvent -= TurnOnGameOverPanel;
		}
		
		void SetInitialReferences () {
			manager = GetComponent<GM_Master>();
		}
		
		void TurnOnGameOverPanel () {
			if (panelGameOver != null) {
				panelGameOver.SetActive(true);
			} else {
				Debug.LogError("Game Over panel not set!");
			}
		}
		
	}
}

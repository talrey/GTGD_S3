using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

namespace Talrey {
	public class GM_RestartLevel : MonoBehaviour {
	
		private GM_Master manager;
		
		void OnEnable () {
			SetInitialReferences();
			
			manager.RestartLevelEvent += RestartLevel;
		}
		
		void OnDisable () {
			manager.RestartLevelEvent -= RestartLevel;
		}
		
		void SetInitialReferences () {
			manager = GetComponent<GM_Master>();
		}
		
		void RestartLevel () {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // see Build Settings list
		}
		
	}
}

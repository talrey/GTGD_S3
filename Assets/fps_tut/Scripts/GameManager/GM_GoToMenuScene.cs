using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

namespace Talrey {
	public class GM_GoToMenuScene : MonoBehaviour {
	
		private GM_Master manager;
		
		void OnEnable () {
			SetInitialReferences();
			
			manager.GoToMenuSceneEvent += GoToMenuScene;
		}
		
		void OnDisable () {
			manager.GoToMenuSceneEvent -= GoToMenuScene;
		}
		
		void SetInitialReferences () {
			manager = GetComponent<GM_Master>();
		}
		
		void GoToMenuScene () {
			SceneManager.LoadScene(0); // see Build Settings list
		}
		
	}
}

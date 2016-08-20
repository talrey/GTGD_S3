using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

namespace Talrey {
	public class MainMenu : MonoBehaviour {
	
		public void PlayGame () {
			SceneManager.LoadScene(1); // see Build Settings list
		}
		
		public void ExitGame () {
			Application.Quit();
		}
	}
}

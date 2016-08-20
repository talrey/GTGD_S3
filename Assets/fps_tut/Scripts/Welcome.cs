using UnityEngine;
using System.Collections;

using UnityEngine.UI;

namespace Talrey {
	public class Welcome : MonoBehaviour {
	
	public Text textWelcome;
	public GameObject canvasWelcome;
	
		// Use this for initialization
		void Start () {
			SetInitialreferences();
			MyWelcomeMessage();
		}
		
		/*
		// Update is called once per frame
		void Update () {
		
		}
		// */
		
		void SetInitialreferences () {
			textWelcome = GameObject.Find("TextWelcome").GetComponent<Text>();
		}
		
		void MyWelcomeMessage () {
			if (textWelcome != null) {
				textWelcome.text = "Welcome";
				Debug.Log("Welcome.");
			}
			else {
				Debug.LogWarning("Welcome text not assigned.");
			}
			StartCoroutine(DisableCanvas());
			
			// sometimes useful for simple delays, can't call args
			//Invoke("DisableCanvas", 10);
		}
		
		IEnumerator DisableCanvas () {
			yield return new WaitForSeconds(5);
			canvasWelcome.SetActive(false);
		}
	}
}

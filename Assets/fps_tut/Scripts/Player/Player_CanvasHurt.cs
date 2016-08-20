using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Player_CanvasHurt : MonoBehaviour {

		public GameObject hurtCanvas;
		private Player_Master pl;
		private float secondsTillHide = 2;
		
		void OnEnable () {
			SetInitialReferences();
			
			pl.EventPlayerHealthDecrease += TurnOnHurtEffect;
		}

		void OnDisable () {
			pl.EventPlayerHealthDecrease -= TurnOnHurtEffect;
		}

		void SetInitialReferences () {
			pl = GetComponent<Player_Master>();
		}
		
		void TurnOnHurtEffect (int dummy) {
			if (hurtCanvas != null) {
				StopCoroutine(ResetHurtCanvas());
				hurtCanvas.SetActive(true);
				StartCoroutine(ResetHurtCanvas());
			}
		}
		
		IEnumerator ResetHurtCanvas () {
			yield return new WaitForSeconds(secondsTillHide);
			hurtCanvas.SetActive(false);
		}
	}
}

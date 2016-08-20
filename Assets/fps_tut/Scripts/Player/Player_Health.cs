using UnityEngine;
using System.Collections;

using UnityEngine.UI;

namespace Talrey {
	public class Player_Health : MonoBehaviour {

		private GM_Master manager;
		private Player_Master pl;
		
		public int health;
		public Text healthText;
		
		public const int MAX_HEALTH = 100;
		
		void OnEnable () {
			SetInitialReferences();
			SetUI();
			pl.EventPlayerHealthDecrease += LoseHealth;
			pl.EventPlayerHealthIncrease += GainHealth;
		}

		void OnDisable () {
			pl.EventPlayerHealthDecrease -= LoseHealth;
			pl.EventPlayerHealthIncrease -= GainHealth;
		}
	
		void Start () {
			// for testing
			//StartCoroutine(TestHealthDeduction());
			health = MAX_HEALTH;
		}
		
		void SetInitialReferences () {
			manager = GameObject.Find("Game Manager").GetComponent<GM_Master>();
			pl = GetComponent<Player_Master>();
		}
		
		IEnumerator TestHealthDeduction () {
			yield return new WaitForSeconds(2);
			pl.CallEventPlayerHealthDecrease(10);
		}
		
		void LoseHealth (int del) {
			health -= del;
			
			if (health <= 0) {
				health = 0;
				manager.CallEventGameOver();
			}
			
			SetUI();
		}
		
		void GainHealth (int del) {
			health += del;
			
			if (health > MAX_HEALTH)
			{
				health = MAX_HEALTH;
			}
		}
		
		void SetUI () {
			if (healthText != null)
			{
				healthText.text = health.ToString();
			}
		}
	}
}

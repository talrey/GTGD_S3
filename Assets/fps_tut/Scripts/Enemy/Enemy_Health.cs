using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Enemy_Health : MonoBehaviour {
		
		private Enemy_Master em;
		[SerializeField]
		private int enemyHealth = 100;
		[SerializeField]
		private int lowHealth = 30;
		[SerializeField]
		private int maxHealth = 100;
		
		void OnEnable () {
			SetInitialReferences();
			
			em.EventEnemyDecreaseHealth += DecreaseHealth;
			em.EventEnemyIncreaseHealth += IncreaseHealth;
		}

		void OnDisable () {
			em.EventEnemyDecreaseHealth -= DecreaseHealth;
			em.EventEnemyIncreaseHealth -= IncreaseHealth;
		}
		
		void SetInitialReferences () {
			em = GetComponent<Enemy_Master>();
		}
		
		void DecreaseHealth (int del) {
			enemyHealth -= del;
			if (enemyHealth <= 0) {
				enemyHealth = 0;
				em.CallEventEnemyDie();
				Destroy(gameObject, Random.Range(10,20));
			} else {
				CheckHealthLevel();
			}
		}
		
		void CheckHealthLevel () {
			if (enemyHealth <= lowHealth && enemyHealth > 0) {
				em.CallEventEnemyHealthLow();
			} else if (enemyHealth > lowHealth) {
				em.CallEventEnemyHealthRecovered();
			}
		}
		
		void IncreaseHealth (int del) {
			enemyHealth += del;
			if (enemyHealth > maxHealth) {
				enemyHealth = maxHealth;
			}
			CheckHealthLevel();
		}
	}
}

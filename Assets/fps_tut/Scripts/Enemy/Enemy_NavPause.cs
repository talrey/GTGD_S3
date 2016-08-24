using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Enemy_NavPause : MonoBehaviour {
		
		private Enemy_Master em;
		private NavMeshAgent myNMA;
		[SerializeField]
		private float pauseTime = 1;
		
		void OnEnable () {
			SetInitialReferences();
			
			em.EventEnemyDie += DisableThis;
			em.EventEnemyDecreaseHealth += PauseNavMeshAgent;
		}

		void OnDisable () {
			em.EventEnemyDie -= DisableThis;
			em.EventEnemyDecreaseHealth -= PauseNavMeshAgent;
		}
		
		void SetInitialReferences () {
			em = GetComponent<Enemy_Master>();
			if (GetComponent<NavMeshAgent>() != null) {
				myNMA = GetComponent<NavMeshAgent>();
			}
		}
		
		void PauseNavMeshAgent (int dummy) {
			if (myNMA != null) {
				if (myNMA.enabled) {
					myNMA.ResetPath();
					em.isNavPaused = true;
					StartCoroutine(RestartNavMeshAgent());
				}
			}
		}
		
		IEnumerator RestartNavMeshAgent () {
			yield return new WaitForSeconds(pauseTime);
			em.isNavPaused = false;
		}
		
		void DisableThis () {
			StopAllCoroutines();
		}
	}
}

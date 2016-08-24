using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Enemy_Animation : MonoBehaviour {
		
		private Enemy_Master em;
		private Animator myAn;
		
		void OnEnable () {
			SetInitialReferences();
			
			em.EventEnemyDie += DisableAnimator;
			em.EventEnemyWalking += SetAnimationWalk;
			em.EventEnemyReachedNavTarget += SetAnimationIdle;
			em.EventEnemyAttack += SetAnimationAttack;
			em.EventEnemyDecreaseHealth += SetAnimationStruck;
		}

		void OnDisable () {
			em.EventEnemyDie -= DisableAnimator;
			em.EventEnemyWalking -= SetAnimationWalk;
			em.EventEnemyReachedNavTarget -= SetAnimationIdle;
			em.EventEnemyAttack -= SetAnimationAttack;
			em.EventEnemyDecreaseHealth -= SetAnimationStruck;
		}
		
		void SetInitialReferences () {
			em = GetComponent<Enemy_Master>();
			if (GetComponent<Animator>() != null) {
				myAn = GetComponent<Animator>();
			}
		}
		
		void SetAnimationWalk () {
			if ( (myAn != null) && (myAn.enabled) ) {
				myAn.SetBool("isPursuing", true);
			}
		}
		
		void SetAnimationIdle () {
			if ( (myAn != null) && (myAn.enabled) ) {
				myAn.SetBool("isPursuing", false);
			}
		}
		
		void SetAnimationAttack () {
			if ( (myAn != null) && (myAn.enabled) ) {
				myAn.SetTrigger("Attack");
			}
		}
		
		void SetAnimationStruck (int dummy) {
			if ( (myAn != null) && (myAn.enabled) ) {
				myAn.SetTrigger("Struck");
			}
		}
		
		void DisableAnimator () {
			if (myAn != null) {
				myAn.enabled = false;
			}
		}
	}
}

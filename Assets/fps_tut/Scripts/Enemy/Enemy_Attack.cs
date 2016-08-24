using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Enemy_Attack : MonoBehaviour {
		
		private Enemy_Master em;
		private Transform attackTarget;
		private Transform myTransform;
		[SerializeField]
		private float attackRate = 2;
		private float nextAttack;
		[SerializeField]
		private float attackRange = 3.5f;
		[SerializeField]
		private int attackDamage = 10;
		
		void OnEnable () {
			SetInitialReferences();
			
			em.EventEnemyDie += DisableThis;
			em.EventEnemySetNavTarget += SetAttackTarget;
		}

		void OnDisable () {
			em.EventEnemyDie -= DisableThis;
			em.EventEnemySetNavTarget -= SetAttackTarget;
		}
	
		void Start () {
			
		}
		
		void Update () {
			TryToAttack();
		}

		void SetInitialReferences () {
			em = GetComponent<Enemy_Master>();
			myTransform = transform;
		}
		
		void SetAttackTarget (Transform targetTransform) {
			attackTarget = targetTransform;
		}
		
		void TryToAttack () {
			if (attackTarget != null) {
				if (Time.time > nextAttack) {
					nextAttack = Time.time + attackRate;
					if (Vector3.Distance(myTransform.position, attackTarget.position) <= attackRange) {
						Vector3 lookAtVector = new Vector3(
							attackTarget.position.x,
							myTransform.position.y,
							attackTarget.position.z
						);
						myTransform.LookAt(lookAtVector);
						em.CallEventEnemyAttack();
						em.isOnRoute = false;
					}
				}
			}
		}
		
		public void OnEnemyAttack () { // called by hPunch animation
			if (attackTarget != null) {
				if (Vector3.Distance(myTransform.position, attackTarget.position) <= attackRange
				&& attackTarget.GetComponent<Player_Master>() != null) {
					Vector3 toOther = attackTarget.position - myTransform.position;
					if (Vector3.Dot(toOther, myTransform.forward) > 0.5f) {
						attackTarget.GetComponent<Player_Master>().CallEventPlayerHealthDecrease(attackDamage);
					}
				}
			}
		}
		
		void DisableThis () {
			this.enabled = false;
		}
	}
}

using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_Animator : MonoBehaviour {
		/* permits or disables held item animations
		 */
		
		private Item_Master im;
		public Animator anim;
		
		void OnEnable () {
			SetInitialReferences();
			
			im.EventObjectThrow += DisableAnimator;
			im.EventObjectPickup += EnableAnimator;
		}

		void OnDisable () {
			im.EventObjectThrow -= DisableAnimator;
			im.EventObjectPickup -= EnableAnimator;
		}
		
		void SetInitialReferences () {
			im = GetComponent<Item_Master>();
		}
		
		void EnableAnimator () {
			if (anim != null) {
				anim.enabled = true;
			}
		}
		
		void DisableAnimator () {
			if (anim != null) {
				anim.enabled = false;
			}
		}
	}
}

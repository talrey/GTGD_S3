using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_Sounds : MonoBehaviour {
		/*
		 * Sound manager for items, such as being picked up or tossed.
		 */
		
		private Item_Master im;
		public float defaultVolume;
		public AudioClip throwSound;
		
		void OnEnable () {
			SetInitialReferences();
			
			im.EventObjectThrow += PlayThrowSound;
		}

		void OnDisable () {
			im.EventObjectThrow -= PlayThrowSound;
		}
		
		void SetInitialReferences () {
			im = GetComponent<Item_Master>();
		}
		
		void PlayThrowSound () {
			if (throwSound != null) {
				AudioSource.PlayClipAtPoint(throwSound, transform.position, defaultVolume);
			}
		}
	}
}

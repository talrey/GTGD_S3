using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Talrey {
	public class Player_AmmoBox : MonoBehaviour {
		
		private Player_Master pl;
		
		[System.Serializable]
		public class AmmoType {
			public string ammoName;
			public int ammoCurrent;
			public int ammoMax;
			
			public AmmoType (string name, int current, int max) {
				ammoName = name;
				ammoCurrent = current;
				ammoMax = max;
			}
		}
		
		public List<AmmoType> ammoTypes = new List<AmmoType>();

		void OnEnable () {
			SetInitialReferences();
			pl.EventPickedUpAmmo += PickedUpAmmo;
		}

		void OnDisable () {
			pl.EventPickedUpAmmo -= PickedUpAmmo;
		}
		
		void SetInitialReferences () {
			pl = GetComponent<Player_Master>();
		}
		
		void PickedUpAmmo (string name, int amount) {
			for (int i=0; i<ammoTypes.Count; i++) {
				if (ammoTypes[i].ammoName == name) {
					ammoTypes[i].ammoCurrent += amount;
					if (ammoTypes[i].ammoCurrent > ammoTypes[i].ammoMax) {
						ammoTypes[i].ammoCurrent = ammoTypes[i].ammoMax;
					}
					pl.CallEventAmmoChanged();
					break;
				}
			}
		}
	}
}

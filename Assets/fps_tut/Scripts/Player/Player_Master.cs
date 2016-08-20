using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Player_Master : MonoBehaviour {

		public delegate void GeneralEventHandler ();
		public event GeneralEventHandler EventInventoryChanged;
		public event GeneralEventHandler EventHandsEmpty;
		public event GeneralEventHandler EventAmmoChanged;
		
		public delegate void AmmoPickupEventHandler (string name, int amount);
		public event AmmoPickupEventHandler	EventPickedUpAmmo;
		
		public delegate void PlayerHealthEventHandler (int healthChange);
		public event PlayerHealthEventHandler EventPlayerHealthDecrease;
		public event PlayerHealthEventHandler EventPlayerHealthIncrease;
		
		public void CallEventInventoryChanged () {
			if (EventInventoryChanged != null) {
				EventInventoryChanged();
			}
		}
		
		public void CallEventHandsEmpty () {
			if (EventHandsEmpty != null) {
				EventHandsEmpty();
			}
		}
		
		public void CallEventAmmoChanged () {
			if (EventAmmoChanged != null) {
				EventAmmoChanged();
			}
		}
		
		public void CallEventPickedUpAmmo (string name, int amount) {
			if (EventPickedUpAmmo != null) {
				EventPickedUpAmmo(name, amount);
			}
		}
		
		public void CallEventPlayerHealthDecrease (int del) {
			if (EventPlayerHealthDecrease != null) {
				EventPlayerHealthDecrease(del);
			}
		}
		
		public void CallEventPlayerHealthIncrease (int del) {
			if (EventPlayerHealthIncrease != null) {
				EventPlayerHealthIncrease(del);
			}
		}
	}
}

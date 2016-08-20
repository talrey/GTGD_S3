using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_Master : MonoBehaviour {
		
		private Player_Master pl;
		
		public delegate void GeneralEventHandler ();
		public event GeneralEventHandler EventObjectThrow;
		public event GeneralEventHandler EventObjectPickup;
		
		public delegate void PickupActionEventHandler (Transform item);
		public event PickupActionEventHandler EventPickupAction;
		
		void OnEnable () {
			SetInitialReferences();
		}
		
		void OnDisable () {
		}

		void SetInitialReferences () {
			if (GM_References._player != null) {
				pl = GM_References._player.GetComponent<Player_Master>();
				if ( !(pl is Player_Master) ) {
					Debug.LogError("invalid player reference");
				}
			}
		}
		
		public void CallEventObjectThrow () {
			if (EventObjectThrow != null) {
				EventObjectThrow();
				pl.CallEventHandsEmpty();
				pl.CallEventInventoryChanged();
			}
		}
		
		public void CallEventObjectPickup () {
			if (EventObjectPickup != null) {
				EventObjectPickup();
				if ( !(pl is Player_Master) ) {
					if (!(GM_References._player is GameObject)) {
						Debug.LogError("invalid player reference later");
					} else {
						Debug.LogError("invalid player reference later, but Ref is ok");
					}
				}
				pl.CallEventInventoryChanged();
				//Debug.Log("picking up item");
			} else {
				Debug.Log("null object event");
			}
		}
		
		public void CallEventPickupAction (Transform item) {
			if (EventPickupAction != null) {
				EventPickupAction(item);
			}
		}
	}
}

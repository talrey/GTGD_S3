using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_Throw : MonoBehaviour {
		
		private Item_Master im;
		private Transform myTransform;
		private Rigidbody myRB;
		private Vector3 throwDirection;
		
		public bool canBeThrown;
		public string throwButtonName;
		public float throwForce;
		
		void OnStart () {
			SetInitialReferences();
		}
		
		void SetInitialReferences () {
			im = GetComponent<Item_Master>();
			myTransform = transform;
			myRB = GetComponent<Rigidbody>();
			if ( !(myTransform is Transform) || !(im is Item_Master) || !(myRB is Rigidbody) ) {
				Debug.Log("init failed");
			}
		}
		
		void Update () {
			CheckForThrowInput();
		}
		
		void CheckForThrowInput () {
			if (throwButtonName != null) {
				if (Input.GetButtonDown(throwButtonName)) {
					Debug.Log("trying to throw");
					if (Time.timeScale > 0 && canBeThrown) {
						if (!(myTransform is Transform)) Debug.Log("transform not ok");
						if (transform.root.CompareTag(GM_References._playerTag)) {
							CarryOutThrowActions();
						}
					}
				}
			} else Debug.Log("throw key is null");
		}
		
		void CarryOutThrowActions () {
			throwDirection = transform.parent.forward;
			transform.parent = null;
			if (! (im is Item_Master) ) Debug.Log("that's why");
			im.CallEventObjectThrow();
			HurlItem();
			Debug.Log("Item thrown");
		}
		
		void HurlItem () {
			myRB.AddForce(throwDirection*throwForce, ForceMode.Impulse);
		}
	}
}

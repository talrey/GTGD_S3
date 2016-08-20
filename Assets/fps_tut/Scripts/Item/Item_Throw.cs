using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Item_Throw : MonoBehaviour {
		
		//private Item_Master im;
		//private Transform myTransform;
		private Rigidbody myRB;
		private Vector3 throwDirection;
		
		public bool canBeThrown;
		public string throwButtonName;
		public float throwForce;
		
		void OnStart () {
			SetInitialReferences();
		}
		
		void SetInitialReferences () {
			//im = GetComponent<Item_Master>();
			//myTransform = transform;
			//myRB = GetComponent<Rigidbody>();
		}
		
		void Update () {
			CheckForThrowInput();
		}
		
		void CheckForThrowInput () {
			if (throwButtonName != null) {
				if (Input.GetButtonDown(throwButtonName)) {
					//Debug.Log("trying to throw");
					if (Time.timeScale > 0 && canBeThrown && transform.root.CompareTag(GM_References._playerTag)) {
						CarryOutThrowActions();
					}
				}
			} else Debug.Log("throw key is null");
		}
		
		void CarryOutThrowActions () {
			throwDirection = transform.parent.forward;
			transform.parent = null;
			//im.CallEventObjectThrow();
			GetComponent<Item_Master>().CallEventObjectThrow();
			HurlItem();
			//Debug.Log("Item thrown");
		}
		
		void HurlItem () {
			myRB = GetComponent<Rigidbody>();
			//myRB.isKinematic = false;
			myRB.AddForce(throwDirection*throwForce, ForceMode.Impulse);
		}
	}
}

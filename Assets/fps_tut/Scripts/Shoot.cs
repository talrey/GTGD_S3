using UnityEngine;
using System.Collections;

namespace Talrey {
	public class Shoot : MonoBehaviour {
	
		private float fireRate = 0.3f;
		private float nextFire;
		
		private RaycastHit hit;
		private float range = 300;
		
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			CheckForInput();
		}
		
		void CheckForInput () {
			// a little redundant, but good enough for learning
			if (Input.GetKey(KeyCode.Mouse0) || Input.GetButton("Fire1")) {
				if (Time.time > nextFire) {
					// instant, hitscan type
					Debug.DrawRay(transform.TransformPoint(0,0,1), transform.forward*range, Color.green, 3);
					if (Physics.Raycast(transform.TransformPoint(0,0,1), transform.forward, out hit, range)) {
						if (hit.transform.CompareTag("Enemy")) {
							Debug.Log("Hit Enemy " + hit.transform.name);
						}
					}
					nextFire = Time.time + fireRate;
					//Debug.Log("Mouse 0 pressed.");
				}
			}
		}
	}
}

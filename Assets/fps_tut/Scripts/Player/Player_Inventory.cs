using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Talrey {
	public class Player_Inventory : MonoBehaviour {
		
		public Transform inventoryPlayerParent;
		public Transform inventoryUIParent;
		public GameObject uiButton;
		
		private Player_Master pl;
		private GM_ToggleInventoryUI gmUI;
		private float timeToPlaceInHands = 0.1f;
		private Transform currentlyHeldItem;
		private int counter;
		private string buttonText;
		private List<Transform> listInventory = new List<Transform>();
		
		void OnEnable () {
			SetInitialReferences();
			UpdateInventoryListAndUI();
			CheckIfHandsEmpty();
			
			pl.EventInventoryChanged += UpdateInventoryListAndUI;
			pl.EventInventoryChanged += CheckIfHandsEmpty;
			pl.EventHandsEmpty += ClearHands;
		}

		void OnDisable () {
			pl.EventInventoryChanged -= UpdateInventoryListAndUI;
			pl.EventInventoryChanged -= CheckIfHandsEmpty;
			pl.EventHandsEmpty -= ClearHands;
		}
		
		void SetInitialReferences () {
			gmUI = GameObject.Find("Game Manager").GetComponent<GM_ToggleInventoryUI>();
			pl = GetComponent<Player_Master>();
		}
		
		void UpdateInventoryListAndUI () {
			counter = 0;
			listInventory.Clear();
			listInventory.TrimExcess();
			ClearInventoryUI();
			
			foreach (Transform child in inventoryPlayerParent) {
				if (child.CompareTag("Item")) {
					listInventory.Add(child);
					GameObject go = Instantiate(uiButton) as GameObject;
					buttonText = child.name;
					go.GetComponentInChildren<Text>().text = buttonText;
					int index = counter;
					go.GetComponent<Button>().onClick.AddListener(delegate { ActivateInventoryItem(index); });
					go.GetComponent<Button>().onClick.AddListener(gmUI.ToggleInventoryUI);
					go.transform.SetParent(inventoryUIParent, false);
					counter++;
				}
			}
		}
		
		void CheckIfHandsEmpty () {
			if (currentlyHeldItem == null && listInventory.Count > 0) {
				StartCoroutine(PlaceItemInHands(listInventory[listInventory.Count-1]));
				Debug.Log("hands empty, refilling...");
			}
		}
		
		void ClearHands () {
			currentlyHeldItem = null;
		}
		
		void ClearInventoryUI () {
			foreach (Transform child in inventoryUIParent) {
				Destroy(child.gameObject);
			}
		}
		
		public void ActivateInventoryItem (int index) {
			DeactivateAllInventoryItems();
			StartCoroutine(PlaceItemInHands(listInventory[index]));
		}
		
		void DeactivateAllInventoryItems () {
			foreach (Transform child in inventoryPlayerParent) {
				if (child.CompareTag("Item")) {
					child.gameObject.SetActive(false);
				}
			}
		}
		
		IEnumerator PlaceItemInHands (Transform item) {
			yield return new WaitForSeconds(timeToPlaceInHands);
			currentlyHeldItem = item;
			currentlyHeldItem.gameObject.SetActive(true);
			//currentlyHeldItem.GetComponent<Rigidbody>().isKinematic = true;
		}
	}
}

using UnityEngine;
using System.Collections;

namespace Talrey {
	public class GM_References : MonoBehaviour {
	
		public string playerTag;
		public static string _playerTag;
		
		public string enemyTag;
		public static string _enemyTag;
		
		public static GameObject _player;
		
		void OnEnable () {
			if (playerTag == "") {
				Debug.LogError("Player Tag reference is empty!");
			}
			if (enemyTag == "") {
				Debug.LogError("Enemy Tag reference is empty!");
			}
			
			_playerTag = playerTag;
			_enemyTag = enemyTag;
			
			_player = GameObject.FindGameObjectWithTag(_playerTag);
		}
	}
}

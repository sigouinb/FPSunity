using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TagHolders;

public class WinCondition : MonoBehaviour 
{
	public string nextLevelName;

	private void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player") {

			if(nextLevelName != "") {
				SceneManager.LoadScene(nextLevelName);
			}
		}
		
	}

} // class

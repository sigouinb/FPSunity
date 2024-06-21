using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TagHolders;

public class Lava : MonoBehaviour
{
	private void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
} // class

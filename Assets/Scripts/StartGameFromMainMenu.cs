using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameFromMainMenu : MonoBehaviour {

	// Use this for initialization
	public void LoadGame(){
		SceneManager.UnloadSceneAsync ("MainMenu");
		SceneManager.LoadSceneAsync ("IngameConstants", LoadSceneMode.Additive);
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

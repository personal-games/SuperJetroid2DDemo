﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToContinue : MonoBehaviour {

    public string scene;
    private bool loadLock;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !loadLock)
            LoadScene();
	}

    void LoadScene()
    {
        loadLock = true;
        Application.LoadLevel(scene);
    }
}

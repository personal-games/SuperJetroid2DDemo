using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRestartText : MonoBehaviour {

    private Texture2D restartText;

	// Use this for initialization
	void Start () {
        restartText = Resources.Load<Texture2D>("restart-text");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        var x = (Screen.width - restartText.width) / 2;
        var y = Screen.height - 50;
        
        if (Time.time % 2 > 1)
        GUI.DrawTexture(new Rect(x, y, restartText.width, restartText.height), restartText);
    }
}

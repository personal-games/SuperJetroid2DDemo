using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForward : MonoBehaviour {

    public Transform slightStart, slightEnd;
    public bool needsCollision = true;

    private bool collision = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        collision = Physics2D.Linecast(slightStart.position, slightEnd.position, 1 << LayerMask.NameToLayer("Solid"));
        Debug.DrawLine(slightStart.position, slightEnd.position, Color.green);

        if (collision == needsCollision)
            this.transform.localScale = new Vector3((transform.localScale.x == 1 ? -1 : 1), 1, 1);

	}
}

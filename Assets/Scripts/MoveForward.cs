using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    public float speed = 2.5f;
    public Rigidbody2D rigidBody2D;
	// Use this for initialization
	void Start () {
        rigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidBody2D.velocity = new Vector2(transform.localScale.x, 0) * speed;
	}
}

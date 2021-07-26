using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    private Transform _t;
    private Camera camera;
    void Awake()
    {
        camera = GetComponent<Camera>();
        camera.orthographicSize = ((Screen.height / 2.0f) / 100f);      
    }

    // Use this for initialization
    void Start () {
        _t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (_t)
        transform.position = new Vector3(_t.position.x, _t.position.y, transform.position.z);
	}
}

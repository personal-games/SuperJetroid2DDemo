using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public const int IDLE = 0;
    public const int OPENING = 1;
    public const int OPEN = 2;
    public const int CLOSING = 3;
    public float closeDelay = 0.5f;
    private int state = IDLE;

    private Animator animator;
    private Collider2D collider2D;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnOpenStart()
    {
        state = OPENING;
    } 

    void OnOpenEnd()
    {
        state = OPEN;
    }

    void OnCloseStart()
    {
        state = CLOSING;
    }

    void OnCloseEnd()
    {
        state = IDLE;
    }

    void DissableCollider2D()
    {
        collider2D.enabled = false;
    }

    void EnableCollider2D()
    {
        collider2D.enabled = true;
    }

    public void Open()
    {
        animator.SetInteger("AnimState", 1);
    }

    public void Close()
    {
        StartCoroutine(CloseNow());
    }

    private IEnumerator CloseNow()
    {
        yield return new WaitForSeconds(closeDelay);
        animator.SetInteger("AnimState", 2);
    }
}

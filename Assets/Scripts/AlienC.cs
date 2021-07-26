using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienC : MonoBehaviour {

    public AudioClip attackSound;

    public float attackDelay = 3f;
    private Animator animator;
    public ProjectTile projectTile;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        if (attackDelay > 0)
        {
            StartCoroutine(OnAttack());
        }

	}
	
	// Update is called once per frame
	void Update () {
        animator.SetInteger("AnimState", 0);
    }

    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        Fire();
        StartCoroutine(OnAttack());
    }

    void Fire()
    {
        animator.SetInteger("AnimState", 1);
        if (attackSound)
            AudioSource.PlayClipAtPoint(attackSound, transform.position);
    }

    void OnShoot()
    {
        if (projectTile)
        {
            ProjectTile clone = Instantiate(projectTile, transform.position, Quaternion.identity) as ProjectTile;
        }
            
            
    }
}

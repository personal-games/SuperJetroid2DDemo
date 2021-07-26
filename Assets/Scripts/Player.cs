using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2 (3, 5);
	private Rigidbody2D rigidBody2D;
    public bool standing;
    public float jetSpeed = 15f;
    public float airSpeedMultiplier = .3f;
    public AudioClip leftFootSound;
    public AudioClip rightFootSound;
    public AudioClip thudSound;
    public AudioClip rocketSound;

    private PlayerController controller;
    private Animator animator;

	void Start(){
		rigidBody2D = GetComponent<Rigidbody2D> ();
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
	}

    void PlayerLeftFootSound()
    {
        if (leftFootSound)
            AudioSource.PlayClipAtPoint(leftFootSound, transform.position);
    }

    void PlayerRightFootSound()
    {
        if (rightFootSound)
            AudioSource.PlayClipAtPoint(rightFootSound, transform.position);
    }

    void PlayRocketSound()
    {
        if (!rocketSound || GameObject.Find("RocketSound"))
            return;
        GameObject gameObject = new GameObject("RocketSound");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = rocketSound;
        audioSource.volume = 0.7f;
        audioSource.Play();

        Destroy(gameObject, rocketSound.length); 
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (!standing)
        {
            var absVelx = Mathf.Abs(rigidBody2D.velocity.x);
            var absVely = Mathf.Abs(rigidBody2D.velocity.y);
            if (absVelx <=.1f || absVely <= .1f)
            {
                if (thudSound)
                    AudioSource.PlayClipAtPoint(thudSound, transform.position);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		var forceX = 0f;
		var forceY = 0f;
		var absVelocityX = Mathf.Abs (rigidBody2D.velocity.x);
        var absVelocityY = Mathf.Abs(rigidBody2D.velocity.y);

        //checking standing
        if (absVelocityY < .2f)
        {
            standing = true;
            animator.SetInteger("AnimState", 0);
        }
        else
        {
            standing = false;
        }

		if (controller.moving.x != 0)
        {
            if (absVelocityX < maxVelocity.x)
            {
                forceX = standing ? (speed * controller.moving.x) : (speed * controller.moving.x * airSpeedMultiplier);
                transform.localScale = new Vector3(forceX < 0 ? -1 : 1, 1, 1);   
            }
            animator.SetInteger("AnimState", 1);
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }

        if (controller.moving.y > 0)
        {
            PlayRocketSound();
            if (absVelocityY < maxVelocity.y)
                forceY = jetSpeed * controller.moving.y;
          animator.SetInteger("AnimState", 2);
        }else if (absVelocityY > 0)
        {
             animator.SetInteger("AnimState", 3);
        }

        rigidBody2D.AddForce(new Vector2(forceX, forceY));
	}
}

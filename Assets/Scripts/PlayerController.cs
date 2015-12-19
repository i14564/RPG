using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Animator anim;
    private bool playerMoving;
	private Rigidbody2D rbody;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
		rbody = GetComponent<Rigidbody2D>();
	}

    /// <summary>
    /// Player controller 
    /// </summary>
    void Update () {
		playerMoving = false;


        //Move in horisontal direction
		if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
			rbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rbody.velocity.y);
			playerMoving = true;
			anim.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
			anim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
		}

        //Move in vertical direction
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
			rbody.velocity = new Vector2(rbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
			playerMoving = true;
			anim.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
			anim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
		}

        //Setting speed to zero 
		if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f) {
			rbody.velocity = new Vector2(0f, rbody.velocity.y);
		}

		if(Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f) {
			rbody.velocity = new Vector2(rbody.velocity.x, 0f);
		}

        //Setting animations properties
		anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private Animator anim;
	private float hMove;
	private float vMove;
	public int test = 21;
	public bool CanMove;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!CanMove) {
			return;
		}

		if (Input.GetKey (KeyCode.P)) {
			anim.SetTrigger ("IsAttacking");
		}

		hMove = Input.GetAxis ("Horizontal");
		vMove = Input.GetAxis ("Vertical");
		anim.SetFloat ("h",hMove);
		anim.SetFloat ("v",vMove);

		float h = hMove * 5f * Time.deltaTime;
		float v = vMove * 5f * Time.deltaTime;
		Vector3 move = new Vector3 (h,0f,v);
		transform.Translate(move);

	}
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour{
	public float moveSpeed = 0.1f;
	Animator animator;
	int walkState = Animator.StringToHash("Base Layer.Walk");
	int idleState = Animator.StringToHash("Base Layer.Idle");
	// Use this for initialization
	void Start () {
		Vector3 tempPos = transform.position;
		tempPos.x = 0;
		tempPos.y = 0;
		transform.position = tempPos;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tempPos = transform.position;
		Vector2 move;
		move.x = CrossPlatformInputManager.GetAxis ("Horizontal");
		move.y = CrossPlatformInputManager.GetAxis ("Vertical");
		move.Normalize();
		AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo (0);
		if (move != Vector2.zero && state.nameHash == idleState) {
			animator.SetTrigger ("Walking");
		}
		if (move == Vector2.zero && state.nameHash == walkState) {
			animator.SetTrigger ("Walking");
		}
		move *= moveSpeed;
		tempPos.x += move.x;
		tempPos.y += move.y;
		transform.position = tempPos;
	}
}

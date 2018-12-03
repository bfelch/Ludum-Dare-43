using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour {

	private int direction = 1;
	public Animator animator;
	public GameObject rod;

	// Use this for initialization
	void Start () {
		InitializeSplitter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InitializeSplitter() {
		Vector3 pos = rod.transform.localPosition;
		pos.x = -0.34375f * direction;
		rod.transform.localPosition = pos;
	}

	public int TriggerDirection() {
		direction *= -1;

		animator.SetInteger("Direction", direction);
		return direction;
	}
}

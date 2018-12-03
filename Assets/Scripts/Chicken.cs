using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour {

	public Vector3 target = Vector3.positiveInfinity;
	private float speed = 0.75f;
	private bool canMove = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!canMove) {
			return;
		}

		if (IsFarTarget(target)) {
			RaycastHit hit;

			Vector3 start = transform.position + new Vector3(0, 0.5f, 0);
			if (Physics.Raycast(start, Vector3.down, out hit, 1.5f)) {
				string tag = hit.transform.gameObject.tag;
				switch (tag) {
					case "Conveyor":
					case "Conveyor Permanent":
						transform.rotation = hit.transform.rotation;
						SetTarget(transform.position + transform.forward);
						break;
					case "Splitter":
					case "Splitter Permanent":
						Splitter splitter = hit.transform.gameObject.GetComponent<Splitter>();
						int direction = splitter.TriggerDirection();
						transform.Rotate(0, 90 * direction, 0);
						SetTarget(transform.position + transform.forward);
						break;
					case "Ritual":
						hit.transform.gameObject.GetComponent<RitualCircle>().PerformRitual();
						Destroy(gameObject);
						break;
					case "MainMenuTile":
						transform.position = new Vector3(0, 0, 6);
						break;
				}
			}
		} else {
			if (!IsForwardBlocked()) {
				transform.position = Vector3.MoveTowards(
					transform.position, target, speed * Time.deltaTime);
			}

			if (Vector3.Distance(target, transform.position) < 0.01f) {
				SetTarget(Vector3.positiveInfinity);
			}
		}
	}

	public void SetTarget(Vector3 target) {
		this.target = target;

		canMove = true;
	}

	private bool IsForwardBlocked() {
		float distance = 0.3f;
		RaycastHit hit;

		Vector3 forward = transform.position + (transform.forward * distance);
		if (forward.x < -0.5f || forward.z < -0.5f) {
			return true;
		}

		Vector3 start = transform.position + new Vector3(0, 0.5f, 0);
		if (Physics.Raycast(start, transform.forward, out hit, distance)) {
			return (hit.transform.gameObject.tag == "Blocker");
		}

		return false;
	}

	private bool IsFarTarget(Vector3 target) {
		return (Vector3.Distance(target, transform.position) > 10.0f);
	}
}

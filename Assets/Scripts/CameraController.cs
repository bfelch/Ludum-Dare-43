using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private int edge = 60;
	private float speed = 4.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Input.mousePosition;

		bool moveU = pos.y > Screen.height - edge;
		bool moveD = pos.y < edge;
		bool moveL = pos.x < edge;
		bool moveR = pos.x > Screen.width - edge;

		int xMod = 0;
		int zMod = 0;

		if (moveU) {
			xMod = moveL ? 0 : 1;
			zMod = moveR ? 0 : 1;
		} else if (moveD) {
			xMod = moveR ? 0 : -1;
			zMod = moveL ? 0 : -1;
		} else if (moveL) {
			xMod = -1;
			zMod = 1;
		} else if (moveR) {
			xMod = 1;
			zMod = -1;
		}

		transform.Translate(new Vector3(xMod * speed, 0, zMod * speed) * Time.deltaTime);
	}
}

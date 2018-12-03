using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class BoardController : MonoBehaviour {

	public int width = 8;
	public int length = 8;

	public GameObject floorTile;
	public GameObject wallTile;
	public GameObject shortWallTile;
	public GameObject dispensorTile;
	public GameObject lightTile;

	public int dispensorPoint;

	public CameraController cameraTarget;

	private string format = "00";

	// Use this for initialization
	void Start () {
		IntializeBoard();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IntializeBoard() {
		IList<Transform> transforms = transform.Cast<Transform>().ToList();
		foreach (Transform child in transforms) {
			DestroyImmediate(child.gameObject);
		}

		for (int x = 0; x < width; x++) {
			PlaceWall(x, length - 1, 2);
			PlaceShortWall(x, 0, 0);

			for (int z = 0; z < length; z++) {
				if (x == 0) {
					PlaceWall(width - 1, z, 3);
					PlaceShortWall(0, z, 1);
				}
				PlaceFloor(x, z);
			}
		}

		if (cameraTarget != null) {
			cameraTarget.transform.position = new Vector3(width / 2, 0, length / 2);
		}
	}

	private bool PlaceLight(int width, int length, int x, int z) {
		return (width - x == 1) && ((length - z) % 3 == 0);
	}

	private void PlaceWall(int x, int z, int rot) {
		if (dispensorPoint == x && rot == 2) {
			PlaceObject("Dispensor", dispensorTile, x, z, rot);
		} else {
			PlaceObject("Wall", wallTile, x, z, rot);
		}

		if (PlaceLight(width, length, x, z) ||
			PlaceLight(length, width, z, x)) {
			PlaceObject("Light", lightTile, x, z, rot);
		}
	}

	private void PlaceShortWall(int x, int z, int rot) {
		PlaceObject("Short Wall", shortWallTile, x, z, rot);
	}

	private void PlaceFloor(int x, int z) {
		PlaceObject("Floor", floorTile, x, z, 0);
	}

	private void PlaceObject(string name, GameObject prefab, int x, int z, int rot) {
		GameObject obj = GameObject.Instantiate(
			prefab, new Vector3(x, 0, z), Quaternion.Euler(new Vector3(0, 90.0f * rot, 0)));
		
		obj.gameObject.name = name + GetPositionString(x, z);
		obj.transform.SetParent(gameObject.transform);
	}

	private string GetPositionString(int x, int z) {
		return " [" + x.ToString(format) + "," + z.ToString(format) + "]";
	}
}

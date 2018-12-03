using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConveyorController : MonoBehaviour {

	public GameObject highlight;
	public GameObject conveyorTile;
	private GameObject selectedTile;

	public AudioSource sound;

	public GameObject tileUI;

	private bool canPlace;

	// Use this for initialization
	void Start () {
		InitializeConveyors();
	}
	
	// Update is called once per frame
	void Update () {
		bool lClick = Input.GetMouseButtonDown(0);
		bool rClick = Input.GetMouseButtonDown(1);

		if (canPlace && (lClick || rClick)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			int layerMask = LayerMask.NameToLayer("IgnoreClick");
			if (Physics.Raycast(ray, out hit, 100.0f, layerMask)) {
				string tag = hit.transform.gameObject.tag;
				switch (tag) {
					case "Floor":
						if (lClick) {
							if (IsBelowBlocked(hit.transform.position)) {
								return;
							}

							GameObject conveyor = GameObject.Instantiate(
								conveyorTile, hit.transform.position, Quaternion.Euler(new Vector3(0, 180.0f, 0)));
							
							conveyor.gameObject.name = "Conveyor " + hit.transform.position;
							conveyor.transform.SetParent(gameObject.transform);
							SetSelected(conveyor);
						} else {
							SetSelected(null);
						}
						break;
					case "Conveyor":
						SetSelected(hit.transform.gameObject);
						RotateTile(selectedTile, rClick);
						break;
				}

				if (tag == "Floor" ||
					tag == "Conveyor" ||
					tag == "Splitter") {
					sound.Play();
				}
			}
		}
	}

	public void BeginChallenge() {
		InitializeConveyors();
		EnablePlacement();
	}

	public void InitializeConveyors() {
		DisablePlacement();
		SetSelected(null);

		IList<Transform> transforms = transform.Cast<Transform>().ToList();
		foreach (Transform child in transforms) {
			DestroyImmediate(child.gameObject);
		}
	}

	private void SetSelected(GameObject selected) {
		if (selected == null) {
			tileUI.SetActive(false);
			highlight.SetActive(false);
		} else {
			tileUI.SetActive(true);
			highlight.SetActive(true);
			highlight.transform.position = selected.transform.position;
		}

		selectedTile = selected;
	}

	public void RotateCW() {
		RotateTile(selectedTile, true);
	}

	public void RotateCCW() {
		RotateTile(selectedTile, false);
	}

	public void DeleteTile() {
		Destroy(selectedTile);
		SetSelected(null);
	}

	private void RotateTile(GameObject tile, bool clockwise) {
		int rot = (int) tile.transform.eulerAngles.y;
		rot = (rot + 90 * (clockwise ? 1 : -1)) % 360;
		tile.transform.rotation = Quaternion.Euler(new Vector3(0, (float) rot, 0));
	}

	public void DisablePlacement() {
		canPlace = false;

		SetSelected(null);
	}

	public void EnablePlacement() {
		canPlace = true;
	}

	private bool IsBelowBlocked(Vector3 position) {
		RaycastHit hit;

		position.y -= 0.01f;
		if (Physics.Raycast(position, Vector3.up, out hit, 1.0f)) {
			return (hit.transform.gameObject.tag == "Blocker");
		}

		return false;
	}
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChickenController : MonoBehaviour {

	public BoardController boardController;
	public GameController gameController;

	public AudioSource sound;

	public GameObject chickenObj;
	public int numChickens;

	private IList<GameObject> chickens;
	private Vector3 target;

	private Coroutine coroutine = null;

	// Use this for initialization
	void Start () {
		InitializeChickens();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InitializeChickens() {
		if (coroutine != null) {
			StopCoroutine(coroutine);
		}

		chickens = new List<GameObject>();

		IList<Transform> transforms = transform.Cast<Transform>().ToList();
		foreach (Transform child in transforms) {
			DestroyImmediate(child.gameObject);
		}

		gameController.SetChickenCount(numChickens);
		target = new Vector3(boardController.dispensorPoint, 0, boardController.length);
		Vector3 offset = new Vector3(0, 0.5f, 0);
		for (int i = 0; i < numChickens; i++) {
			GameObject chicken = GameObject.Instantiate(
				chickenObj, target + offset, Quaternion.Euler(0, 180, 0));
			
			chicken.gameObject.name = "Chicken [" + i.ToString() + "]";
			chicken.transform.SetParent(gameObject.transform);

			chickens.Add(chicken);
		}
	}

	public void DeployChickens() {
		coroutine = StartCoroutine(DeployChicken(0));
	}

	public IEnumerator DeployChicken(int i) {
		GameObject chicken = chickens[i];
		chicken.GetComponent<Chicken>().SetTarget(target);
		sound.Play();

		if (i + 1 < chickens.Count) {
			yield return new WaitForSeconds(1.5f);
			coroutine = StartCoroutine(DeployChicken(i + 1));
		}
	}
}

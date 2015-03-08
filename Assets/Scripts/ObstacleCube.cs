using UnityEngine;
using System.Collections;

public class ObstacleCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(0.1f, 0.1f, 1f);
		transform.Translate (new Vector3 (4f,0.1f,Random.Range(-1f, 1f)));
		GetComponent<Rigidbody>().useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -5) {
			Destroy(this.gameObject);
		}
		transform.Translate (new Vector3 (-0.05f,0f,0f));
	}
}

using UnityEngine;
using System.Collections;

public class GameTouchEvent : MonoBehaviour {
	private bool moving;
	public GameObject obstacleCube;

	// Use this for initialization
	void Start () {
		//Debug.Log ("Hello world");
		moving = false;
		StartCoroutine(RespawnObstacleCube());
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			ShapeChange.phase += 0.1F;
		}

		//float current = Time.time;
	}

	IEnumerator RespawnObstacleCube() {
		yield return new WaitForSeconds(2f);
		while (true)
		{
			for (int i = 0; i < 10; i++)
			{
				InitObstacleCube();
				yield return new WaitForSeconds(0.5f);
			}
			yield return new WaitForSeconds(2f);
		}		
	}

	void InitObstacleCube() {
		Instantiate(obstacleCube,obstacleCube.transform.position,Quaternion.identity);
	}


	void OnMouseDown() {
		//Debug.Log("Mouse down");
		moving = true;
	}

	void OnMouseUp() {
		//Debug.Log("Mouse up");
		moving = false;
	}

	/*
	 * Touch Screen Devices
	 */
	/*
	void OnUpdate()	{
		foreach(Touch t in Input.touches) {
			if(t.phase == TouchPhase.Began)	{
				Vector3 point = new Vector3(t.position.x, t.position.y, 0);
				Ray ray = Camera.main.ViewportPointToRay(point);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit)){
					//hit.collider.SendMessage("OnMouseDown", null, SendMessageOptions.DontRequireReceiver);
					moving = true;
				} else {
					moving = false;
				}
			}
		}
	}*/

}


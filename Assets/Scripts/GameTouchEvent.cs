using UnityEngine;
using System.Collections;

public class GameTouchEvent : MonoBehaviour {
	private int moving;
	public GameObject obstacleCube;
	public float speed;
	public Camera mainCamera;

	// Use this for initialization
	void Start () {
		//Debug.Log ("Hello world");
		moving = 0;
		StartCoroutine(RespawnObstacleCube());
	}
	
	// Update is called once per frame
	void Update () {
		if (moving > 0) {
			ShapeChange.phase += speed;
		} else if (moving < 0) {
			ShapeChange.phase -= speed;
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

		Vector3 worldLoc = mainCamera.ScreenToWorldPoint(Input.mousePosition);

		if (worldLoc.x > 0) {
			moving = 1;
		} else {
			moving = -1;
		}
		//Debug.Log("x:"+worldLoc.x+"y:"+worldLoc.y+"z:"+worldLoc.z);
	}

	void OnMouseUp() {
		//Debug.Log("Mouse up");
		moving = 0;
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


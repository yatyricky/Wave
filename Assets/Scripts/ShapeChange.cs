using UnityEngine;
using System.Collections;

public class ShapeChange : MonoBehaviour {
	public int lengthOfLineRenderer;
	public GameObject dot;
	public float frame;
	public float speed;

	//public Material matTheLine;
	public static float phase = 0.0F;
	private static int waveLeftSideOffset = -80;

	void Start() {
		LineRenderer lineRenderer = this.gameObject.GetComponent<LineRenderer>();

		//lineRenderer.material = matTheLine;
		//Debug.Log("after assignment, current Mat " + lineRenderer.material.name);
		lineRenderer.SetVertexCount(lengthOfLineRenderer);
		//lineRenderer.SetColors(Color.white, Color.white);
		//lineRenderer.SetWidth(0.05f, 0.05f);
		//lineRenderer.transform.Translate (new Vector3 (-3.0f, 0f, 0f)); 
	}

	void Update() {
		LineRenderer lineRenderer = this.gameObject.GetComponent<LineRenderer>();
		int i = 0;
		while (i < lengthOfLineRenderer) {
			float cx = (i * speed + waveLeftSideOffset) * frame;
			Vector3 pos = new Vector3(cx, 0.05f, Mathf.Sin(cx + phase));
			//Debug.Log("Dot["+i+"]=("+i * 0.1F+","+0.1f+","+Mathf.Sin(i * 0.1F + phase)+")");
			lineRenderer.SetPosition(i, pos);
			i++;
		}

		dot.transform.position = new Vector3 (0.0f, 0.0f, Mathf.Sin (phase));
	}
}

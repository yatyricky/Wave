using UnityEngine;
using System.Collections;

public class ShapeChange : MonoBehaviour {
	public int lengthOfLineRenderer;
	private static int waveLeftSideOffset = -80;

	public Material matTheLine;
	public static float phase = 0.0F;
	public GameObject dot;

	void Start() {
		LineRenderer lineRenderer = this.gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = matTheLine;
		//Debug.Log("after assignment, current Mat " + lineRenderer.material.name);
		lineRenderer.SetVertexCount(lengthOfLineRenderer);
		//lineRenderer.SetColors(Color.white, Color.white);
		lineRenderer.SetWidth(0.05f, 0.05f);
		lineRenderer.useWorldSpace = false;
		//lineRenderer.transform.Translate (new Vector3 (-3.0f, 0f, 0f)); 
	}

	void Update() {
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		int i = 0;
		while (i < lengthOfLineRenderer) {
			Vector3 pos = new Vector3((i + waveLeftSideOffset) * 0.1F, 0.05f, Mathf.Sin((i + waveLeftSideOffset) * 0.1F + phase));
			//Debug.Log("Dot["+i+"]=("+i * 0.1F+","+0.1f+","+Mathf.Sin(i * 0.1F + phase)+")");
			lineRenderer.SetPosition(i, pos);
			i++;
		}

		dot.transform.position = new Vector3 (0.0f, 0.0f, Mathf.Sin (phase));
	}
}

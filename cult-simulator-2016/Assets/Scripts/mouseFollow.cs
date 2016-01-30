using UnityEngine;
using System.Collections;

public class mouseFollow : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 position = Input.mousePosition;
		position.z = Camera.main.ScreenToWorldPoint (position).z + 1.0f;
		this.transform.position = Camera.main.ScreenToWorldPoint (position);
	}
}
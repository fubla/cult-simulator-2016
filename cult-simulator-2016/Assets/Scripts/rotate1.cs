using UnityEngine;
using System.Collections;

public class rotate1 : MonoBehaviour {
	public float speed = 1.0f;
	public float maxHoriz;
	public float minHoriz;
	public float maxVerti;
	public float minVerti;
	private float horiz;
	private float verti;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		horiz = speed * Input.GetAxis ("Horizontal1") * Time.deltaTime;
		Debug.Log(this.transform.eulerAngles);
		if ((this.transform.eulerAngles.y + horiz > maxHoriz && this.transform.eulerAngles.y + horiz < minHoriz)) {
			horiz = 0.0f;
		}
		verti = speed * Input.GetAxis ("Vertical1") * Time.deltaTime;
		if ((this.transform.eulerAngles.x + verti > maxVerti && this.transform.eulerAngles.x + verti < minVerti)) {
			verti = 0.0f;
		}
		transform.eulerAngles = new Vector3(this.transform.eulerAngles.x + verti, this.transform.eulerAngles.y + horiz, 0f);
	}
}

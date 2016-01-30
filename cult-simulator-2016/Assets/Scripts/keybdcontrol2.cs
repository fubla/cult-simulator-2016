using UnityEngine;
using System.Collections;

public class keybdcontrol2 : MonoBehaviour {
	public float speed = 10.0f;
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
		horiz = speed * Input.GetAxis ("Horizontal2") * Time.deltaTime;
		if (this.transform.position.x + horiz > maxHoriz) {
			horiz = 0.0f;
		}
		else if(this.transform.position.x + horiz < minHoriz){
			horiz = 0.0f;
		}
		verti = speed * Input.GetAxis ("Vertical2") * Time.deltaTime;
		if (this.transform.position.y + verti > maxVerti) {
			verti = 0.0f;
		}
		else if(this.transform.position.y + verti < minVerti){
			verti = 0.0f;
		}
		transform.Translate (horiz, verti, 0f, Camera.main.transform);
	}
}

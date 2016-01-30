using UnityEngine;
using System.Collections;

public class PlayerFollowerScript : MonoBehaviour {
	public Transform leftHand;
	public Transform rightHand;
	public Transform head;
	
	public Transform leftPosition;
	public Transform rightPosition;
	public Transform upPosition;
	public Transform downPosition;
	public Transform frontPosition;

	public float closeHandDistance;
	public float farHandDistance;

	enum Position {left, right, up, down, front, none}
	private Position leftHandPosition = Position.none;
	private Position rightHandPosition = Position.none;
	private Position headPosition = Position.none; 

	public float angleToUp;
	public float angleToDown; 
	// Update is called once per frame
	void Update () {
		// Check left hand
		if ((leftHand.position - leftPosition.position).magnitude < closeHandDistance)
			leftHandPosition = Position.left;
		else if ((leftHand.position - rightPosition.position).magnitude < farHandDistance)
			leftHandPosition = Position.right;
		else if ((leftHand.position - upPosition.position).magnitude < closeHandDistance)
			leftHandPosition = Position.up;
		else if ((leftHand.position - downPosition.position).magnitude < closeHandDistance)
			leftHandPosition = Position.down;
		else if ((leftHand.position - frontPosition.position).magnitude < closeHandDistance)
			leftHandPosition = Position.front;
		else
			leftHandPosition = Position.none;
		// Check right hand
		if ((rightHand.position - leftPosition.position).magnitude < farHandDistance)
			rightHandPosition = Position.left;
		else if ((rightHand.position - rightPosition.position).magnitude < closeHandDistance)
			rightHandPosition = Position.right;
		else if ((rightHand.position - upPosition.position).magnitude < closeHandDistance)
			rightHandPosition = Position.up;
		else if ((rightHand.position - downPosition.position).magnitude < closeHandDistance)
			rightHandPosition = Position.down;
		else if ((rightHand.position - frontPosition.position).magnitude < closeHandDistance)
			rightHandPosition = Position.front;
		else
			rightHandPosition = Position.none;
		// Check head angle
		if ((head.eulerAngles.z > lookMaxAngle))
			headPosition = Position.up;
		else if ((head.eulerAngles.z < lookMaxAngle))
			headPosition = Position.down;
	}



}

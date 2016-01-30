using UnityEngine;
using System.Collections;


// To use: add to a camera
public class CameraControls : MonoBehaviour {
    public KeyCode lookDownKey = KeyCode.LeftShift;
    public KeyCode lookUpKey = KeyCode.Space;
    //public float sensitivityX = 0.1F;
    public float rotationAcceleration = 0.1F;
    //public float minimumX = -360F;
    //public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    public float neckLength = 2F;
    public float maxRotationSpeed = 5F;
    Vector3 neckOffset;
    float rotationY = 0F;
    float rotationSpeed = 0F;

    Vector3 characterPosition; // contains the real position and idle rotation
    Quaternion characterRotation; // contains the real position and idle rotation

    // Use this for initialization
    void Start () {
        // Make the rigid body not change rotation
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        if (rigidBody != null)
            rigidBody.freezeRotation = true;

        characterPosition = transform.position;
        characterRotation = transform.rotation;
        neckOffset = new Vector3(0F, -neckLength, 0F);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey (lookDownKey)) {
            rotationSpeed += rotationAcceleration;
        } else if (Input.GetKey (lookUpKey)) {
            rotationSpeed -= rotationAcceleration;
        } else {
            rotationSpeed += (rotationSpeed > 0)? -rotationAcceleration: rotationAcceleration;
            if (System.Math.Abs(rotationSpeed) <= rotationAcceleration) {
                rotationSpeed = 0;
            }
        }
        rotationSpeed = Mathf.Clamp (rotationSpeed, -maxRotationSpeed, maxRotationSpeed);
        rotationY += rotationSpeed;
        rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

        // reset; currently doing this every frame
        transform.position = characterPosition;
        transform.rotation = characterRotation;

        transform.RotateAround( characterPosition + neckOffset, Vector3.right, rotationY);
        //transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);

    }
}

using UnityEngine;

public class Mover : MonoBehaviour {
	public float MoveCoeff;
	public float RotateCoeff;

	Rigidbody _rb;

	void Awake() {
		_rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		var moveDelta = transform.forward * Input.GetAxis("Vertical") * MoveCoeff;
		_rb.MovePosition(transform.position + moveDelta);
		var rotateDelta = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * RotateCoeff, Vector3.up);
		_rb.MoveRotation(transform.rotation * rotateDelta);
	}
}
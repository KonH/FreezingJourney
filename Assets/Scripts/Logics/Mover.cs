using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour {
	public float MoveCoeff;
	public float RotateCoeff;

	GameState _state;
	Rigidbody _rb;

	[Inject]
	public void Init(GameState state) {
		_state = state;
		_rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		if ( !_state.IsPlaying ) {
			return;
		}
		var moveDelta = transform.forward * Input.GetAxis("Vertical") * MoveCoeff;
		_rb.MovePosition(transform.position + moveDelta);
		var rotateDelta = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * RotateCoeff, Vector3.up);
		_rb.MoveRotation(transform.rotation * rotateDelta);
	}
}
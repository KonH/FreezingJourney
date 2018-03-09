using UnityEngine;

public class HeatHolder : MonoBehaviour {
	public float Value;
	public float MaxValue;
	public float StartValue;

	void Start() {
		Value = StartValue;
	}

	public void Add(float count) {
		if ( enabled ) {
			Value = Mathf.Clamp(Value + count, 0, MaxValue);
			CheckValue();
		}
	}

	void CheckValue() {
		if ( Value <= 0 ) {
			enabled = false;
			GetComponent<Mover>().enabled = false;
		}
	}
}

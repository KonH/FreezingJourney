using UnityEngine;

public class HeatDecreaser : MonoBehaviour {
	public float Value;

	HeatHolder _holder;

	void Awake() {
		_holder = GetComponent<HeatHolder>();
	}

	void Update () {
		_holder.Add(Value * Time.deltaTime);
	}
}

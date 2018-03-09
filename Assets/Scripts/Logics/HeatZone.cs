using UnityEngine;

public class HeatZone : MonoBehaviour {
	public float UseSpeed = 1.0f;

	public float Use() {
		return UseSpeed * Time.deltaTime;
	}
}

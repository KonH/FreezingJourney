using UnityEngine;

public class Collectable : MonoBehaviour {
	public void Use() {
		Destroy(gameObject);
	}
}

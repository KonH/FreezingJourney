using UnityEngine;

public class Collector : MonoBehaviour {
	public int CurCount;
	public int WantCount;

	HeatZone _curZone;

	void OnTriggerEnter(Collider other) {
		var item = other.gameObject.GetComponent<Collectable>();
		if ( item ) {
			item.Use();
			CurCount++;
			CheckCount();
		}
	}

	void CheckCount() {
		if ( CurCount >= WantCount ) {
			GetComponent<Mover>().enabled = false;
		}
	}
}

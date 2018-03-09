using UnityEngine;

public class HeatZoneUser : MonoBehaviour {
	HeatHolder _holder;
	HeatZone _curZone;

	void Awake() {
		_holder = GetComponent<HeatHolder>();
	}

	void OnTriggerEnter(Collider other) {
		var zone = other.gameObject.GetComponent<HeatZone>();
		if ( zone ) {
			_curZone = zone;
		}
	}

	void Update() {
		if ( _curZone ) {
			var adding = _curZone.Use();
			_holder.Add(adding);
		}
	}

	void OnTriggerExit(Collider other) {
		var zone = other.gameObject.GetComponent<HeatZone>();
		if ( zone == _curZone ) {
			_curZone = null;
		}
	}
}

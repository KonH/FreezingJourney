using UnityEngine;
using Zenject;

public class HeatZoneUser : MonoBehaviour {
	GameState _state;
	HeatZone _curZone;

	[Inject]
	public void Init(GameState state) {
		_state = state;
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
			_state.AddHeat(adding);
		}
	}

	void OnTriggerExit(Collider other) {
		var zone = other.gameObject.GetComponent<HeatZone>();
		if ( zone == _curZone ) {
			_curZone = null;
		}
	}
}

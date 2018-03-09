using UnityEngine;
using Zenject;

public class Collector : MonoBehaviour {
	GameState _state;

	[Inject]
	public void Init(GameState state) {
		_state = state;
	}

	void OnTriggerEnter(Collider other) {
		var item = other.gameObject.GetComponent<Collectable>();
		if ( item ) {
			item.Use();
			_state.AddItem();
		}
	}
}

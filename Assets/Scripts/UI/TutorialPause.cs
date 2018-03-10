using UnityEngine;
using Zenject;

public class TutorialPause : MonoBehaviour {
	GameState _state;

	[Inject]
	public void Init(GameState state) {
		_state = state;
	}

	void OnEnable() {
		_state.Pause();
	}

	void OnDisable() {
		_state.Unpause();
	}
}

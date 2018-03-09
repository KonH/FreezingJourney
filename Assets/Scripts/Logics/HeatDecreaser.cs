using UnityEngine;
using Zenject;

public class HeatDecreaser : MonoBehaviour {
	public float Value;

	GameState _state;

	[Inject]
	public void Init(GameState state) {
		_state = state;
	}

	void Update () {
		_state.AddHeat(Value * Time.deltaTime);
	}
}

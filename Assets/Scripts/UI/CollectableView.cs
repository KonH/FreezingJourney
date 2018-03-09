using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Text))]
public class CollectableView : MonoBehaviour {
	GameState _state;
	Text _text;

	[Inject]
	public void Init(GameState state) {
		_state = state;
		_text = GetComponent<Text>();
	}

	void Update() {
		_text.text = string.Format("{0}/{1}", _state.Player.CurItems, _state.Player.MaxItems);
	}
}

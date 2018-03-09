using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Text))]
public class CollectableView : MonoBehaviour {
	GameState _state;
	Text _text;
	int _prevCount = -1;

	[Inject]
	public void Init(GameState state) {
		_state = state;
		_text = GetComponent<Text>();
	}

	void Update() {
		var newCount = _state.Player.CurItems;
		if ( newCount != _prevCount ) {
			_text.text = string.Format("{0}/{1}", newCount, _state.Player.MaxItems);
			_prevCount = newCount;
		}
	}
}

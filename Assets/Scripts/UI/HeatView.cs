using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Image))]
public class HeatView : MonoBehaviour {
	GameState _state;
	Image _image;

	[Inject]
	public void Init(GameState state) {
		_state = state;
		_image = GetComponent<Image>();
	}

	void Update () {
		if ( _state.Player.MaxHeat > 0 ) {
			_image.fillAmount = _state.Player.CurHeat / _state.Player.MaxHeat;
		}
	}
}

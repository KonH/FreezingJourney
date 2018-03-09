using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.EventSystem;
using UDBase.UI.Common;
using Zenject;

public class EndStateHandler : MonoBehaviour {
	public List<UIElement> GameUI;
	public UIElement Common;
	public UIElement Win;
	public UIElement Lose;

	IEvent _events;

	[Inject]
	public void Init(IEvent events) {
		_events = events;
	}

	void Start() {
		_events.Subscribe<Game_Win>(this, OnWin);
		_events.Subscribe<Game_Lose>(this, OnLose);
	}

	void OnDestroy() {
		_events.Unsubscribe<Game_Win>(OnWin);
		_events.Unsubscribe<Game_Lose>(OnLose);
	}

	void ShowCommon() {
		foreach ( var elem in GameUI ) {
			elem.Hide();
		}
		Common.Show();
	}

	void OnWin(Game_Win e) {
		ShowCommon();
		Win.Show();
	}

	void OnLose(Game_Lose e) {
		ShowCommon();
		Lose.Show();
	}
}

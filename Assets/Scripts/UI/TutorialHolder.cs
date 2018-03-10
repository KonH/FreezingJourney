using UnityEngine;
using UDBase.UI.Common;
using UDBase.Controllers.EventSystem;
using Zenject;

public class TutorialHolder : MonoBehaviour {
	public UIOverlay GameStarted;
	public UIOverlay HeatZoneEntered;
	public UIOverlay ItemCollected;

	IEvent _events;
	UIManager _ui;

	[Inject]
	public void Init(IEvent events, UIManager ui) {
		_events = events;
		_ui = ui;
		_events.Subscribe<Game_Started>(this, OnGameStarted);
		_events.Subscribe<Game_HeatZoneEntered>(this, OnHeatZoneEntered);
		_events.Subscribe<Game_ItemCollected>(this, OnItemCollected);
	}

	void OnDestroy() {
		_events.Unsubscribe<Game_Started>(OnGameStarted);
		_events.Unsubscribe<Game_HeatZoneEntered>(OnHeatZoneEntered);
		_events.Unsubscribe<Game_ItemCollected>(OnItemCollected);
	}

	void OnGameStarted(Game_Started e) {
		ShowOverlay(GameStarted);
	}

	void OnHeatZoneEntered(Game_HeatZoneEntered e) {
		ShowOverlay(HeatZoneEntered);
	}

	void OnItemCollected(Game_ItemCollected e) {
		ShowOverlay(ItemCollected);
	}

	public void ShowOverlay(UIOverlay overlay) {
		_ui.ShowOverlay(overlay.gameObject, null);
	}
}

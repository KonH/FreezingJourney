using System;
using UnityEngine;
using UDBase.Controllers.EventSystem;

public class GameState {

	[Serializable]
	public class Settings {
		public float StartHeat;
		public float MaxHeat;
		public int MaxItems;
	}

	public enum GameStatus {
		Playing,
		Lose,
		Win,
		Paused
	}

	public class PlayerState {
		public float CurHeat { get; private set; }
		public float MaxHeat { get; private set; }
		public int CurItems { get; private set; }
		public int MaxItems { get; private set; }

		public PlayerState(float curHeat, float maxHeat, int maxItems) {
			CurHeat = curHeat;
			MaxHeat = maxHeat;
			MaxItems = maxItems;
		}

		public void AddHeat(float value) {
			CurHeat = Mathf.Clamp(CurHeat + value, 0, MaxHeat);
		}

		public void AddItem() {
			CurItems++;
		}
	}

	static bool Started;
	static bool HeatZoneEntered;
	static bool ItemCollected;

	public GameStatus Status { get; private set; }
	public PlayerState Player { get; private set; }

	public bool IsPlaying => Status == GameStatus.Playing;

	IEvent _events;

	public GameState(IEvent events, Settings settings) {
		_events = events;
		Player = new PlayerState(settings.StartHeat, settings.MaxHeat, settings.MaxItems);
	}

	public void CheckGameStarted() {
		if ( !Started ) {
			_events.Fire(new Game_Started());
			Started = true;
		}
	}

	public void AddHeat(float value) {
		if ( IsPlaying ) {
			if ( !HeatZoneEntered && (value > 0) ) {
				_events.Fire(new Game_HeatZoneEntered());
				HeatZoneEntered = true;
			}
			Player.AddHeat(value);
			TryUpdateStatus();
		}
	}

	public void AddItem() {
		if ( IsPlaying ) {
			if ( !ItemCollected ) {
				_events.Fire(new Game_ItemCollected());
				ItemCollected = true;
			}
			Player.AddItem();
			TryUpdateStatus();
		}
	}

	void TryUpdateStatus() {
		if ( !IsPlaying ) {
			return;
		}
		if ( Player.CurItems >= Player.MaxItems ) {
			Status = GameStatus.Win;
			_events.Fire(new Game_Win());
		} else if ( Player.CurHeat <= 0 ) {
			Status = GameStatus.Lose;
			_events.Fire(new Game_Lose());
		}
	}

	public void Pause() {
		if ( IsPlaying ) {
			Status = GameStatus.Paused;
		}
	}

	public void Unpause() {
		if ( Status == GameStatus.Paused ) {
			Status = GameStatus.Playing;
		}
	}
}

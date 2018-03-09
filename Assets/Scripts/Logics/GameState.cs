using System;
using UnityEngine;

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
		Win
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

	public GameStatus Status { get; private set; }
	public PlayerState Player { get; private set; }

	public bool IsPlaying => Status == GameStatus.Playing;

	public GameState(Settings settings) {
		Player = new PlayerState(settings.StartHeat, settings.MaxHeat, settings.MaxItems);
	}

	public void AddHeat(float value) {
		if ( IsPlaying ) {
			Player.AddHeat(value);
			TryUpdateStatus();
		}
	}

	public void AddItem() {
		if ( IsPlaying ) {
			Player.AddItem();
			TryUpdateStatus();
		}
	}

	void TryUpdateStatus() {
		if ( Player.CurItems >= Player.MaxItems ) {
			Status = GameStatus.Win;
		} else if ( Player.CurHeat <= 0 ) {
			Status = GameStatus.Lose;
		}
	}
}

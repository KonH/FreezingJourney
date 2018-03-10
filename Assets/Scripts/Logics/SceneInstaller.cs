using UnityEngine;
using UDBase.Installers;

public class SceneInstaller : UDBaseSceneInstaller {
	public GameState.Settings GameSettings;

	public override void InstallBindings() {
		base.InstallBindings();

		GameSettings.MaxItems = GameObject.FindObjectsOfType<Collectable>().Length;

		Container.BindInstance(GameSettings);
		Container.Bind<GameState>().ToSelf().FromNew().AsSingle();

		Invoke("CheckGameStarted", 0.5f);
	}

	void CheckGameStarted() {
		Container.Resolve<GameState>().CheckGameStarted();
	}
}

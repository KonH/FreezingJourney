using UDBase.Installers;

public class SceneInstaller : UDBaseSceneInstaller {
	public GameState.Settings GameSettings;

	public override void InstallBindings() {
		base.InstallBindings();

		Container.BindInstance(GameSettings);
		Container.Bind<GameState>().ToSelf().FromNew().AsSingle();
	}
}

using UDBase.Installers;
using UDBase.Controllers.LogSystem;

public class GameInstaller : UDBaseInstaller {
	public UnityLog.Settings UnityLogSettings;

	public GameState.Settings GameSettings;

	public override void InstallBindings() {
		AddUnityLogger(UnityLogSettings);
		AddEvents();

		Container.BindInstance(GameSettings);
		Container.Bind<GameState>().ToSelf().FromNew().AsSingle();
	}
}

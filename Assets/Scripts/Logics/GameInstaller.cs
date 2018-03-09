using UDBase.Installers;
using UDBase.Controllers.LogSystem;

public class GameInstaller : UDBaseInstaller {
	public UnityLog.Settings UnityLogSettings;

	public override void InstallBindings() {
		AddUnityLogger(UnityLogSettings);
		AddEvents();
		AddDirectSceneLoader();
	}
}

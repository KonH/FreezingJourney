using UDBase.Installers;
using UDBase.Controllers.LogSystem;

public class GameInstaller : UDBaseInstaller {
	public UnityLog.Settings UnityLogSettings;

	public override void InstallBindings() {
		if ( _buildType.IsEditor ) {
			AddUnityLogger(UnityLogSettings);
		} else {
			AddEmptyLogger();
		}
		AddEvents();
		AddDirectSceneLoader();
	}
}

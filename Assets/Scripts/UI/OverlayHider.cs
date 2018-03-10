using UnityEngine;
using UDBase.UI.Common;

[RequireComponent(typeof(UIOverlay))]
public class OverlayHider : MonoBehaviour {
	void Update() {
		if ( Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape) ) {
			var overlay = GetComponent<UIOverlay>();
			var element = GetComponent<UIElement>();
			if ( element.State == UIElement.UIElementState.Shown ) {
				overlay.Close();
			}
		}
	}
}

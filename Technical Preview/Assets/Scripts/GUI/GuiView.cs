using UnityEngine;

public class GuiView : CoreComponent {

	//---------------------------------------------
	// Inspector Variables:
	//---------------------------------------------

	public bool IsVisible;
	public GameObject ViewGameObject;

	//---------------------------------------------
	// Unity Methods:
	//---------------------------------------------

	protected virtual void Awake() {
		ShowOrHide (IsVisible);
	}

	//---------------------------------------------
	// Public Methods:
	//---------------------------------------------

	public void ShowOrHide(bool shouldShow) {
		ViewGameObject.SetActive (shouldShow);
		IsVisible = shouldShow;
	}

	// convenience methods to show or hide view.
	public void Show() {
		ShowOrHide (true);
	}

	public void Hide() {
		ShowOrHide (false);
	}
}

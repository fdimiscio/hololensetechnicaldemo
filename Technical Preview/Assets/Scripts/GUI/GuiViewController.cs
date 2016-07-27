
public class GuiViewController : CoreComponent {

	//---------------------------------------------
	// Inspector Variables:
	//---------------------------------------------

	public bool IsVisible;

	//---------------------------------------------
	// Private Variables:
	//---------------------------------------------

	private GuiView[] views;

	//---------------------------------------------
	// Unity Methods:
	//---------------------------------------------

	protected void Awake() {
		views = this.GetComponentsInChildren<GuiView> ();
		ShowOrHideAllViews (IsVisible);
	}

	//---------------------------------------------
	// Public Methods:
	//---------------------------------------------

	// convenience methods to show or hide view.
	public void ShowAll() {
		ShowOrHideAllViews (true);
	}

	public void HideAll() {
		ShowOrHideAllViews (false);
	}

	//---------------------------------------------
	// Private Methods:
	//---------------------------------------------

	private void ShowOrHideAllViews(bool shouldShow) {
		for (int i = 0; i < views.Length; ++i) {
			views [i].ShowOrHide (shouldShow);
		}
	}
}


public class GuiController : CoreComponent {

	//---------------------------------------------
	// Inspector Variables:
	//---------------------------------------------

	public GuiHologramViewController HologramViewController;

	//---------------------------------------------
	// Event Handlers:
	//---------------------------------------------

	//---------------------------------------------
	// Public Methods:
	//---------------------------------------------

	public void ShowHologramTransformMenu() {
		HologramViewController.ShowAll ();
	}

	public void HideHologramTransformMenu() {
		HologramViewController.HideAll ();
	}
}

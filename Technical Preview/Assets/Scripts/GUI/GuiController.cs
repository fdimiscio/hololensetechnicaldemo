
public class GuiController : CoreComponent {

    //---------------------------------------------
    // Events:
    //---------------------------------------------

    public event Eventhandler MoveButtonSelected;
    public event Eventhandler ResizeButtonSelected;
    public event Eventhandler RotateButtonSelected;

    //---------------------------------------------
    // Inspector Variables:
    //---------------------------------------------

    public GuiHologramViewController HologramViewController;

    //---------------------------------------------
    // Unity Methods:
    //---------------------------------------------

    protected void OnEnable() {
        HologramViewController.MoveButtonSelected += HologramViewController_MoveSelected;
        HologramViewController.ScaleButtonSelected += HologramViewController_ResizeSelected;
        HologramViewController.RotateButtonSelected += HologramViewController_RotateSelected;
    }

    protected void OnDisable() {
        HologramViewController.MoveButtonSelected -= HologramViewController_MoveSelected;
        HologramViewController.ScaleButtonSelected -= HologramViewController_ResizeSelected;
        HologramViewController.RotateButtonSelected -= HologramViewController_RotateSelected;
    }

    //---------------------------------------------
    // Event Handlers:
    //---------------------------------------------

    private void HologramViewController_MoveSelected() {
        InvokeEvent(MoveButtonSelected);
    }

    private void HologramViewController_ResizeSelected() {
        InvokeEvent(ResizeButtonSelected);
    }

    private void HologramViewController_RotateSelected() {
        InvokeEvent(RotateButtonSelected);
    }

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

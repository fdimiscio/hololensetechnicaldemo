
public class GuiHologramViewController : GuiViewController {

    //---------------------------------------------
    // Events:
    //---------------------------------------------

    public event Eventhandler MoveButtonSelected;
    public event Eventhandler ScaleButtonSelected;
    public event Eventhandler RotateButtonSelected;

    //---------------------------------------------
    // Inspector Variables:
    //---------------------------------------------

    public GuiHologramButtonView MoveButton;
    public GuiHologramButtonView ScaleButton;
    public GuiHologramButtonView RotateButton;

    //---------------------------------------------
    // Unity Methods:
    //---------------------------------------------

    protected void OnEnable() {
        MoveButton.Selected += MoveButton_Selected;
        ScaleButton.Selected += ScaleButton_Selected;
        RotateButton.Selected += RotateButton_Selected;
    }

    protected void OnDisable() {
        MoveButton.Selected -= MoveButton_Selected;
        ScaleButton.Selected -= ScaleButton_Selected;
        RotateButton.Selected -= RotateButton_Selected;
    }

    //---------------------------------------------
    // Event Handlers:
    //---------------------------------------------

    private void MoveButton_Selected() {
        InvokeEvent(MoveButtonSelected);
        HideAll();
    }

    private void ScaleButton_Selected() {
        InvokeEvent(ScaleButtonSelected);
        HideAll();
    }

    private void RotateButton_Selected() {
        InvokeEvent(RotateButtonSelected);
        HideAll();
    }
}

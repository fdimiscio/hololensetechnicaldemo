
public class SceneController : CoreComponent {

    //---------------------------------------------
    // Enumerations:
    //---------------------------------------------

    /*public enum Modes {
        None,
        Interactive,
        Examiner
        // will need these states or similar when the the trainer modes are implemented.
    }*/ 

    //---------------------------------------------
    // Inspector Variables:
    //---------------------------------------------

    public GuiController GuiController;
    public InteractiblesController InteractiblesController;

    //---------------------------------------------
    // Unity Methods:
    //---------------------------------------------

    protected void OnEnable() {
        GuiController.MoveButtonSelected += GuiController_MoveButtonSelected;
        GuiController.ResizeButtonSelected += GuiController_ResizeButtonSelected;
        GuiController.RotateButtonSelected += GuiController_RotateButtonSelected;
    }

    protected void OnDisable() {
        GuiController.MoveButtonSelected -= GuiController_MoveButtonSelected;
        GuiController.ResizeButtonSelected -= GuiController_ResizeButtonSelected;
        GuiController.RotateButtonSelected -= GuiController_RotateButtonSelected;
    }

    //---------------------------------------------
    // Event Handlers:
    //---------------------------------------------

    private void GuiController_MoveButtonSelected() {
        InteractiblesController.EnterStateMove();
    }

    private void GuiController_ResizeButtonSelected() {
        InteractiblesController.EnterStateResize();
    }

    private void GuiController_RotateButtonSelected() {
        InteractiblesController.EnterStateRotate();
    }

    private void GuiController_TransformationComplete() {
        // are we doing this in GUI or when things have finished moving? firm up with Franco...
        InteractiblesController.EnterStateInactive();
    }
}

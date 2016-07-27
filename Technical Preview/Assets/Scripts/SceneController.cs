
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

    public enum TransformStates {
        Inactive,
        Moving,
        Rotating,
        Scaling
    }

    //---------------------------------------------
    // Inspector Variables:
    //---------------------------------------------

    public GuiController GuiController;

    //---------------------------------------------
    // Private Variables:
    //---------------------------------------------

    private TransformStates transformState;

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
        EnterTransformState(TransformStates.Moving);
    }

    private void GuiController_ResizeButtonSelected() {
        EnterTransformState(TransformStates.Scaling);
    }

    private void GuiController_RotateButtonSelected() {
        EnterTransformState(TransformStates.Rotating);
    }

    private void GuiController_TransformationComplete() {
        // are we doing this in GUI or when things have finished moving? firm up with Franco...
        EnterTransformState(TransformStates.Inactive);
    }

    //---------------------------------------------
    // State Methods:
    //---------------------------------------------

    private void EnterTransformState(TransformStates newState) {
        // break out if already in the desired state...
        if (transformState == newState) return;
        transformState = newState;

        switch (transformState) {
            case TransformStates.Inactive:

                break;
            case TransformStates.Moving:

                break;
            case TransformStates.Rotating:

                break;
            case TransformStates.Scaling:

                break;
        }
    }
}

using UnityEngine;

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

    // todo: actually set up these GUI Elements.

    private void GuiController_MoveBarValueChanged(Vector3 newPosition) {
        int index = 0; // for now we only have one interactible, so send index 0. todo: get index of interactible we wish to move.
        InteractiblesController.MoveInteractable(newPosition, index);
    }

    private void GuiController_RotateBarValueChanged(float newRotation) {

    }

    private void GuiController_ScaleBarValueChanged(float uniformScale) {

    }
}

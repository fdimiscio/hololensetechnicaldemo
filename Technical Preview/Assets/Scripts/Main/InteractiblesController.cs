﻿using UnityEngine;
using System.Collections;

public class InteractiblesController : MonoBehaviour {

    //---------------------------------------------
    // Enumerations:
    //---------------------------------------------

    public enum TransformStates {
        Inactive,
        Moving,
        Rotating,
        Scaling
    }

    //---------------------------------------------
    // Inspector Variables:
    //---------------------------------------------

    public Interactible[] Interactibles;

    //---------------------------------------------
    // Private Variables:
    //---------------------------------------------

    private TransformStates transformState;

    //---------------------------------------------
    // Public Methods:
    //---------------------------------------------

    public void EnterStateMove() {
        EnterTransformState(TransformStates.Moving);
    }

    public void EnterStateRotate() {
        EnterTransformState(TransformStates.Rotating);
    }

    public void EnterStateResize() {
        EnterTransformState(TransformStates.Scaling);
    }

    public void EnterStateInactive() {
        EnterTransformState(TransformStates.Inactive);
    }

    public void MoveInteractable(Vector3 newPosition, int index) {
        Interactibles[index].MoveInteractible(newPosition);
    }

    public void RotateInteractible(float newRotation, int index) {
        // new y rotation.
    }

    public void ScaleInteractible(float newScale, int index) {
        // new uniform scale.
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

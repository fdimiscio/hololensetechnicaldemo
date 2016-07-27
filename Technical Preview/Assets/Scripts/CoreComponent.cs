using UnityEngine;

public class CoreComponent : MonoBehaviour {

	// Base extension of Monobehaviour with boilerplate methods.

	//---------------------------------------------
	// Delegates:
	//---------------------------------------------

	public delegate void Eventhandler();

    //---------------------------------------------
    // Delegates:
    //---------------------------------------------

    public void InvokeEvent(Eventhandler theEvent) {
        if (theEvent != null) theEvent();
    }
}

using UnityEngine;

public class GuiHologramButtonView : GuiView {

    //---------------------------------------------
    // Events:
    //---------------------------------------------

    public event Eventhandler Selected;

    //---------------------------------------------
    // Inspector Variables:
    //---------------------------------------------

    public TransitionState Transition;
	public Material Material;

	//---------------------------------------------
	// Hololense Methods:
	//---------------------------------------------

	protected void GazeEntered() {
        LeanTween.color(gameObject, Transition.OnEmissionColour, Transition.Duration).setEase(Transition.TransitionType);
	}

	protected void GazeExited() {
        LeanTween.color(gameObject, Transition.OffEmissionColour, Transition.Duration).setEase(Transition.TransitionType);
    }

    protected void OnSelect() {
        InvokeEvent(Selected);
    }

	//---------------------------------------------
	// Unity Methods:
	//---------------------------------------------

	protected override void Awake() {
		SetColour(Transition.OffEmissionColour);
	}

#if UNITY_EDITOR
	// simulate gaze events with mouse in editor.
	protected void OnMouseEnter() {
		GazeEntered ();
	}

	protected void OnMouseExit() {
		GazeExited ();
	}

    protected void OnMouseDown() {
        OnSelect();
    }

#endif

	//---------------------------------------------
	// Private Classes:
	//---------------------------------------------

	private void SetColour(Color colour) {
		Material.SetColor (Transition.Property, colour);
	}

	//---------------------------------------------
	// Inspector Classes:
	//---------------------------------------------

	[System.Serializable]
	public class TransitionState {
		public string Property;
		public Color OffEmissionColour;
		public Color OnEmissionColour;
        public LeanTweenType TransitionType;
		public float Duration;
	}
}

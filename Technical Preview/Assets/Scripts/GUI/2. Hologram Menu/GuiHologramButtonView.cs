using UnityEngine;

public class GuiHologramButtonView : GuiView {

	//---------------------------------------------
	// Inspector Variables:
	//---------------------------------------------

	public TransitionState Transition;
	public Material Material;

	//---------------------------------------------
	// Hololense Methods:
	//---------------------------------------------

	protected void GazeEntered() {
		SetColour(Transition.OnEmissionColour);
	}

	protected void GazeExited() {
		SetColour(Transition.OffEmissionColour);
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
		public float Duration;
	}
}

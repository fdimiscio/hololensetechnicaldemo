using UnityEngine;

/// <summary>
/// The Interactible class flags a Game Object as being "Interactible".
/// Determines what happens when an Interactible is being gazed at.
/// </summary>
public class Interactible : CoreComponent {

    //---------------------------------------------
    // Constants:
    //---------------------------------------------

    private const string Metallic = "_Metallic";

    //---------------------------------------------
    // Public Variables:
    //---------------------------------------------

    [Tooltip("Audio clip to play when interacting with this hologram.")]
    public AudioClip TargetFeedbackSound;

    //---------------------------------------------
    // Private Variables:
    //---------------------------------------------

    private AudioSource audioSource;
    private Material[] defaultMaterials;

    //---------------------------------------------
    // Unity Methods:
    //---------------------------------------------

    protected void Start() {
        defaultMaterials = GetComponent<Renderer>().materials;

        // Add a BoxCollider if the interactible does not contain one.
        Collider collider = GetComponentInChildren<Collider>();
        if (collider == null) {
            gameObject.AddComponent<BoxCollider>();
        }

        EnableAudioHapticFeedback();
    }

#if UNITY_EDITOR
    protected void OnMouseEnter() {
        GazeEntered();
    }

    protected void OnMouseExit() {
        GazeExited();
    }

    protected void OnMouseDown() {
        OnSelect();
    }
#endif

    //---------------------------------------------
    // Hololense Methods:
    //---------------------------------------------

    protected void GazeEntered() {
        for (int i = 0; i < defaultMaterials.Length; i++) {
            defaultMaterials[i].SetFloat(Metallic, .5f);
        }
    }

    protected void GazeExited() {
        for (int i = 0; i < defaultMaterials.Length; i++) {
            defaultMaterials[i].SetFloat(Metallic, 0f);
        }
    }

    protected void OnSelect() {
        for (int i = 0; i < defaultMaterials.Length; i++) {
            defaultMaterials[i].SetFloat(Metallic, 1f);
        }

        // Play the audioSource feedback when we gaze and select a hologram.
        if (audioSource != null && !audioSource.isPlaying) {
            audioSource.Play();
        }

        SendMessage("PerformTagAlong"); // todo: work out what this is sending to, should avoid using SendMessage and use events in the hierarchy instead, much easier to trace and debug.
    }

    //---------------------------------------------
    // Public Methods: DEV
    //---------------------------------------------

    public void MoveInteractible(Vector3 position) {

        // todo: will get rid of all this and simplify, handle the rotation in GUI.

        if (GestureManager.Instance.IsManipulating) {
            /* TODO: DEVELOPER CODING EXERCISE 4.a */

            Vector3 moveVector = Vector3.zero;
            // 4.a: Calculate the moveVector as position - manipulationPreviousPosition.
            moveVector = position - manipulationPreviousPosition;
            // 4.a: Update the manipulationPreviousPosition with the current position.
            manipulationPreviousPosition = position;


            // 4.a: Increment this transform's position by the moveVector.
            //transform.position += moveVector;
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
        }
    }

    public void RotateInteractible(float rotation) {
        transform.localRotation = Quaternion.Euler(0, rotation, 0);
    }

    public void ScaleInteractible(float scale) {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    // todo: organise this...
    public float MovementSpeed = 1.5f;
    private Vector3 manipulationPreviousPosition;

    //---------------------------------------------
    // Private Methods:
    //---------------------------------------------

    private void EnableAudioHapticFeedback() {
        // If this hologram has an audio clip, add an AudioSource with this clip.
        if (TargetFeedbackSound != null) {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            audioSource.clip = TargetFeedbackSound;
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 1;
            audioSource.dopplerLevel = 0;
        }
    }
}
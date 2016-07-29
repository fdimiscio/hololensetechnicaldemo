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

    protected void Start()
    {
        defaultMaterials = GetComponent<Renderer>().materials;

        // Add a BoxCollider if the interactible does not contain one.
        Collider collider = GetComponentInChildren<Collider>();
        if (collider == null)
        {
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
    // Private Methods:
    //---------------------------------------------

    private void EnableAudioHapticFeedback()
    {
        // If this hologram has an audio clip, add an AudioSource with this clip.
        if (TargetFeedbackSound != null)
        {
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
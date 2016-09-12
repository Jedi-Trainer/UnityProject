using UnityEngine;
using System.Collections;

public class BladeToggle : MonoBehaviour {

    //Boolean for trigger
    public bool triggerButtonDown = false;

    //Boolean for lightsaber
    public bool lightsaberOn = false;

    //Trigger
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    //Blade in game
    public GameObject blade;

    public AudioClip[] activationSounds;
    public AudioClip[] deactivationSounds;


    //Reference to controller
    private SteamVR_Controller.Device controller
    {

        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);

        }

    }

    //Child of controller. SteamVR component.
    private SteamVR_TrackedObject trackedObj;

    void Start()
    {

        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }

    //Called every frame.
    void Update()
    {
        //If we couldn't find the controller...
        if (controller == null)
        {

            Debug.Log("Controller not initialized");

            return;

        }

        //If the trigger button was pressed...
        if (triggerButtonDown = controller.GetPressDown(triggerButton))
        {
            //Render the lightsaber (or erase it if already rendered)
            lightsaberOn = !lightsaberOn;

            // Pick a random activation sound
            //UnityEngine.Random.Range()?
            int index = Random.Range(0, activationSounds.Length);
            AudioSource source = blade.GetComponent<AudioSource>();
            source.clip = activationSounds[index];

            // If the lightsaber is deactivated, play the deactivation sound
            index = Random.Range(0, deactivationSounds.Length);
            source = GetComponent<AudioSource>();
            source.clip = deactivationSounds[index];
            if (!lightsaberOn)
            {
                source.Play();
            }

            // Activate the lightsaber
            blade.SetActive(lightsaberOn);
        }
    
    }
}

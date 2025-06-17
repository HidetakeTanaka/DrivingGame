// Plays screeching brake sound when braking at sufficient speed
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BrakeSoundPlayer : MonoBehaviour
{
    public AudioSource brakeScreechSource;
    public AudioClip brakeScreechClip;
    public float speedThreshold = 1.5f; // Equals to about 5.4 km/h

    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        if (brakeScreechSource != null && brakeScreechClip != null)
        {
            brakeScreechSource.clip = brakeScreechClip;
        }
    }

    void Update()
    {
        bool braking = Input.GetKey(KeyCode.Space);
        float speed = CarController.carSpeed * 3.6f; // Convert "m/s" to "km/h"

        if (braking && speed > speedThreshold)
        {
            if (!isPlaying && brakeScreechSource != null && brakeScreechClip != null)
            {
                brakeScreechSource.Play();
                isPlaying = true;
            }
        }
        else
        {
            if (isPlaying && brakeScreechSource != null)
            {
                brakeScreechSource.Stop();
                isPlaying = false;
            }
        }
    }
}

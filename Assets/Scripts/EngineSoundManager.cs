using UnityEngine;

public class EngineSoundManager : MonoBehaviour
{
    [System.Serializable]
    public class EngineLayer
    {
        public string name;
        public AudioSource source;
        public float minSpeed;
        public float maxSpeed;
        public float minPitch = 0.9f;
        public float maxPitch = 1.5f;
    }

    public EngineLayer[] engineLayers;
    public float fadeSpeed = 2f;
    public float pitchSmoothing = 2f;

    private float displayedSpeed;

    void Start()
    {
        foreach (var layer in engineLayers)
        {
            if (layer.source != null)
            {
                layer.source.loop = true;
                layer.source.volume = 0f;
                layer.source.Play();
            }
        }
    }

    void Update()
    {
        float actualSpeed = CarController.carSpeed;
        displayedSpeed = Mathf.Lerp(displayedSpeed, actualSpeed, pitchSmoothing * Time.deltaTime);

        foreach (var layer in engineLayers)
        {
            float t = Mathf.InverseLerp(layer.minSpeed, layer.maxSpeed, displayedSpeed);
            float pitch = Mathf.Lerp(layer.minPitch, layer.maxPitch, t);
            float targetVolume = (displayedSpeed >= layer.minSpeed && displayedSpeed < layer.maxSpeed) ? 1f : 0f;

            if (layer.source != null)
            {
                layer.source.volume = Mathf.Lerp(layer.source.volume, targetVolume, fadeSpeed * Time.deltaTime);
                layer.source.pitch = pitch;
            }
        }
    }
}

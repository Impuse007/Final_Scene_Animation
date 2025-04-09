using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    public float pulseSpeed = 2f;           // How fast it pulses
    public float minIntensity = 0.5f;       // Minimum brightness
    public float maxIntensity = 2f;         // Maximum brightness

    private Light _light;
    private float _timeOffset;

    void Start()
    {
        _light = GetComponent<Light>();
        _timeOffset = Random.Range(0f, 100f); // Desync multiple lights if needed
    }

    void Update()
    {
        float t = (Mathf.Sin((Time.time + _timeOffset) * pulseSpeed) + 1f) / 2f;
        _light.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
    }
}
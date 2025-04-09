using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float minIntensity = 0.2f;
    public float maxIntensity = 1.5f;

    public float flickerSpeed = 0.1f; // How often it updates flicker (in seconds)
    public float chanceToBlinkOff = 0.1f; // Chance per flicker to go fully dark (0–1)

    private Light _light;
    private float _timer;

    void Start()
    {
        _light = GetComponent<Light>();
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            Flicker();
            _timer = flickerSpeed + Random.Range(-flickerSpeed * 0.5f, flickerSpeed * 0.5f); // add some randomness to timing
        }
    }

    void Flicker()
    {
        // Randomly decide if the light should blink off
        if (Random.value < chanceToBlinkOff)
        {
            _light.intensity = 0f;
        }
        else
        {
            _light.intensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}

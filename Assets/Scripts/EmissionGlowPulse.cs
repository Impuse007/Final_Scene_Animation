using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class EmissionGlowPulse : MonoBehaviour
{
    [ColorUsage(true, true)]
    public Color baseEmissionColor = Color.cyan;

    public float pulseSpeed = 2f;       // Speed of the pulse
    public float minEmission = 0.5f;    // Minimum intensity
    public float maxEmission = 3f;      // Maximum intensity

    private Material _material;
    private float _timeOffset;

    void Start()
    {
        _material = GetComponent<Renderer>().material;

        if (!_material.IsKeywordEnabled("_EMISSION"))
            _material.EnableKeyword("_EMISSION");

        // Offset so not all lights pulse in sync
        _timeOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        float emissionStrength = Mathf.Lerp(minEmission, maxEmission,
            (Mathf.Sin((Time.time + _timeOffset) * pulseSpeed) + 1f) / 2f);

        Color finalColor = baseEmissionColor * emissionStrength;
        _material.SetColor("_EmissionColor", finalColor);
    }
}
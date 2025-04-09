using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class EmissionGlowPulse : MonoBehaviour
{
    [ColorUsage(true, true)]
    public Color baseEmissionColor = Color.cyan;

    public float pulseSpeed = 2f;
    public float minEmission = 0.5f;
    public float maxEmission = 3f;

    public Light linkedLight; // Optional: assign in inspector
    public float minLightIntensity = 0.5f;
    public float maxLightIntensity = 3f;

    private Material _material;
    private float _timeOffset;

    void Start()
    {
        _material = GetComponent<Renderer>().material;

        if (!_material.IsKeywordEnabled("_EMISSION"))
            _material.EnableKeyword("_EMISSION");

        _timeOffset = Random.Range(0f, 100f);

        // Safety check
        if (linkedLight == null)
        {
            linkedLight = GetComponentInChildren<Light>();
        }
    }

    void Update()
    {
        float t = (Mathf.Sin((Time.time + _timeOffset) * pulseSpeed) + 1f) / 2f;
        float emissionStrength = Mathf.Lerp(minEmission, maxEmission, t);
        Color finalColor = baseEmissionColor * emissionStrength;

        // Apply to material
        _material.SetColor("_EmissionColor", finalColor);

        // Apply to linked light if assigned
        if (linkedLight != null)
        {
            linkedLight.intensity = Mathf.Lerp(minLightIntensity, maxLightIntensity, t);
            linkedLight.color = baseEmissionColor;
        }
    }
}
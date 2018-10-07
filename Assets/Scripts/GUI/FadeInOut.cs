using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [Tooltip("The target maskable graphic to fade in and out.")]
    public UnityEngine.UI.MaskableGraphic FadeTarget;

    [Tooltip("The total time to complete a fade out and in cycle.")]
    public float FadeTime = 1.0f;

    [Tooltip("Whether the initial graphic starts transparent.")]
    public bool StartTransparent = false;

    private float _baseAlpha = 0.0f;
    private float _elapsedTime = 0.0f;

    private void Start()
    {
        if (this.FadeTarget == null)
        {
            Debug.LogError("FadeTarget cannot be null.");
            this.enabled = false;
        }
        else
        {
            this._baseAlpha = this.FadeTarget.color.a;
            if(this.StartTransparent)
            {
                this.FadeTarget.color = new Color(this.FadeTarget.color.r, this.FadeTarget.color.g, this.FadeTarget.color.b, 0f);
            }
        }
    }

    private void Update()
    {
        this._elapsedTime += Time.deltaTime;

        // Clamp elapsed time between 0 and fade time
        if (this._elapsedTime >= this.FadeTime)
            this._elapsedTime -= this.FadeTime;

        Color fadedColour = this.FadeTarget.color;

        float alphaModifier = (_elapsedTime / FadeTime) * 2.0f; // Results in a range 0 -> 2
        if (alphaModifier > 1.0f)
            alphaModifier = 2.0f - alphaModifier;


        fadedColour.a = _baseAlpha * alphaModifier;
        FadeTarget.color = fadedColour;
    }
}
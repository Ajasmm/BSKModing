using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;

[Serializable]
public class EngineSoundClip
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] float minRPM, maxRPM;
    [SerializeField] float minPitch, rootPitchRPM;
    [SerializeField] float rpmFadeIn, rpmFadeOut;
    [SerializeField] AnimationCurve accelerationVolume;

    float volumeFade, pitch, acceVolume;

    public void Update(float rpm, float acceleration, float masterVolume)
    {
        if (rpm < minRPM || rpm > maxRPM)
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
            return;
        }
        else if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (rpm < minRPM + rpmFadeIn)
        {
            volumeFade = ((rpm - minRPM) / (rpmFadeIn));
        }
        else if (rpm > maxRPM - rpmFadeOut)
        {
            volumeFade = (maxRPM - rpm) / (rpmFadeOut);
        }
        else
        {
            volumeFade = 1;
        }

        pitch = (rpm / rootPitchRPM) * (1 - minPitch);
        pitch = minPitch + pitch;

        acceVolume = accelerationVolume.Evaluate(acceleration);

        audioSource.pitch = pitch;
        audioSource.volume = volumeFade * acceVolume * masterVolume;

        if (!audioSource.isPlaying)
            audioSource.Play();
    }
}

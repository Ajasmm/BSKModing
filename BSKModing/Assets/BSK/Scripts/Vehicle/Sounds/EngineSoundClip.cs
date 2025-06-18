using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EngineSoundClip
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] float minRPM, maxRPM;
    [SerializeField] float minPitch, rootPitchRPM;
    [SerializeField] float rpmFadeIn, rpmFadeOut;
    [SerializeField] AnimationCurve accelerationVolume;

}

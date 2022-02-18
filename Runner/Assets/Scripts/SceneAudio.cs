using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudio : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private float backgroundFloat, soundEffectsFloat;

    [SerializeField] private AudioSource backgroundAudio;
    [SerializeField] private AudioSource[] soundEffectsAudio;

    private void Awake() => ContinueSettings();

    public void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

        backgroundAudio.volume = backgroundFloat;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }
}

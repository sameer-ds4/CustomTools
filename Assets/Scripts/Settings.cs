using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Settings : MonoBehaviour
{
    public Slider soundController;
    public Slider musicController;

    public delegate void ChangeVolume(float vol);
    public static event ChangeVolume ChangeMusicVolume;
    public static event ChangeVolume ChangeSoundVolume;

    public delegate void StartDefaults();
    public static event StartDefaults DefaultSettings;

    private void Awake()
    {
    }

    private void OnEnable()
    {
        DefaultSettings += SlidersUpdate;
    }

    private void OnDisable()
    {
        DefaultSettings -= SlidersUpdate;
    }

    private void Start()
    {
        DefaultSettings?.Invoke();

        DOVirtual.DelayedCall(3, () =>
        {
            //Tweening.TweenPunch(testObject, 2, Vector3.one * 6);
            //Tweening.AlphaFadeOut(testObject, 1.4f);
            //Tweening.TweenOut(testObject, 1.3f);
            //Tweening.AlphaFadeOut(testObject, 1.3f);
        });
    }


    public void SoundUpdate()
    {
        soundController.onValueChanged.AddListener((v) => ChangeSoundVolume?.Invoke(v));
    }

    public void MusicUpdate()
    {
        musicController.onValueChanged.AddListener((v) => ChangeMusicVolume?.Invoke(v));
    }

    private void SlidersUpdate()
    {
        soundController.value = SaveDataHandler.Instance.saveData.soundVol;
        musicController.value = SaveDataHandler.Instance.saveData.musicVol;
    }
}

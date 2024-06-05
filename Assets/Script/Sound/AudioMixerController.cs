using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicMasterSlider;
    [SerializeField] private Slider musicBGMSlider;
    [SerializeField] private Slider musicSFXSlider;

    //슬라이더 MinValue 0.001 사운드 볼륨은 Log10 단위로 되어있기 때문에

    private void Awake()
    {   //마스타 슬라이더의 값이 변경될 떄 리스너를 통해서 함수에 값을 전달한다.
        musicMasterSlider.onValueChanged.AddListener(SetMasterVolume);
        //BGM 슬라이더의 값이 변경될 떄 리스너를 통해서 함수에 값을 전달한다.
        musicBGMSlider.onValueChanged.AddListener(SetBGMVolume);
        //SFX 슬라이더의 값이 변경될 떄 리스너를 통해서 함수에 값을 전달한다.
        musicSFXSlider.onValueChanged.AddListener(SetSFXVolume);

    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}

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

    //�����̴� MinValue 0.001 ���� ������ Log10 ������ �Ǿ��ֱ� ������

    private void Awake()
    {   //����Ÿ �����̴��� ���� ����� �� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicMasterSlider.onValueChanged.AddListener(SetMasterVolume);
        //BGM �����̴��� ���� ����� �� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicBGMSlider.onValueChanged.AddListener(SetBGMVolume);
        //SFX �����̴��� ���� ����� �� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
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

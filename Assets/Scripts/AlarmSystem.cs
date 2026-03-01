using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 0.1f;

    private float _targetVolume;
    private float _maxVolume = 1;
    private float _minVolume = 0;
    private Coroutine _fadeCoroutine;

    private void Awake()
    {
        _audioSource.volume = _minVolume;
    }

    public void TriggerEnter(bool isEnter)
    {
        if (isEnter)
        {
            _audioSource.Play();
            _audioSource.volume = _minVolume;
            _targetVolume = _maxVolume;
        }
        else
        {
            _targetVolume = _minVolume;
        }

        StartFade();
    }

    private void StartFade()
    {
        if (_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _fadeCoroutine = StartCoroutine(FadeVolume());
    }

    private IEnumerator FadeVolume()
    {
        while (!Mathf.Approximately(_audioSource.volume, _targetVolume))
        {
            _audioSource.volume = Mathf.MoveTowards(
                _audioSource.volume,
                _targetVolume,
                _fadeSpeed * Time.deltaTime);

            yield return null;
        }

        if (_audioSource.volume <= _minVolume)
            _audioSource.Stop();

        _fadeCoroutine = null;
    }
}
using System;
using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Trigger _trigger;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 0.1f;

    private bool _isInside;
    private float _targetVolume;
    private float _maxVolume = 1;
    private float _minVolume = 0;
    private bool _isCanPlayAudio;

    private void Awake()
    {
        _audioSource.volume = _minVolume;
    }

    private void Update()
    {
        if (_isCanPlayAudio)
        {
            float currentVolume = _audioSource.volume;
            currentVolume = Mathf.MoveTowards(currentVolume, _targetVolume, _fadeSpeed * Time.deltaTime);
            _audioSource.volume = currentVolume;

            if (currentVolume <= _minVolume)
            {
                _audioSource.Stop();
                _isCanPlayAudio = false;
            }
        }
    }

    private void OnEnable()
    {
        _trigger.TriggerEnter += TriggerEnter;
    }

    private void OnDisable()
    {
        _trigger.TriggerEnter -= TriggerEnter;
    }

    private void TriggerEnter()
    {
        _isInside = !_isInside;

        if (_isInside)
        {
            _audioSource.Play();
            _audioSource.volume = _minVolume;
            _targetVolume = _maxVolume;
            _isCanPlayAudio = true;
        }
        else
        {
            _targetVolume = _minVolume;
        }
    }
}
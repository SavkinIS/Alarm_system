using System;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Detector detector;
    [SerializeField] private AlarmSystem _alarmSystem;

    private bool _thiefIsInside = false;

    private void OnEnable()
    {
        detector.TriggerEnter += TriggerEnter;
    }

    private void OnDisable()
    {
        detector.TriggerEnter -= TriggerEnter;
    }

    private void TriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(typeof(Thief), out var thief))
        {
            _thiefIsInside = !_thiefIsInside;
            _alarmSystem.TriggerEnter(_thiefIsInside);
        }
    }
}
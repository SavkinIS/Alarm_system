using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
    public event Action TriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter?.Invoke();
    }
}
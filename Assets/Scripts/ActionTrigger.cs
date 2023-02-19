using System;
using UnityEngine;

public class ActionTrigger : MonoBehaviour
{
    public event Action<Collider> OnTriggerEntered;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered?.Invoke(other);
    }
}

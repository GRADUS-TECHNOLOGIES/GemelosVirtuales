using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    public float speed = 1.5f;

    public enum ConveyorState
    {
        STOPPED,
        FORWARD,
        BACKWARD
    }

    public ConveyorState currentState = ConveyorState.STOPPED;

    private Vector3 moveDirection = Vector3.forward;

    private List<Rigidbody> objectsOnBelt = new List<Rigidbody>();

    void FixedUpdate()
    {
        if (currentState == ConveyorState.STOPPED) return;

        moveDirection = (currentState == ConveyorState.FORWARD)
            ? transform.forward
            : -transform.forward;

        foreach (Rigidbody obj in objectsOnBelt)
        {
            if (obj != null)
            {
                obj.MovePosition(obj.position + moveDirection * speed * Time.fixedDeltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null && !objectsOnBelt.Contains(rb))
        {
            objectsOnBelt.Add(rb);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null && objectsOnBelt.Contains(rb))
        {
            objectsOnBelt.Remove(rb);
        }
    }

    public void StartBelt() => currentState = ConveyorState.FORWARD;

    public void StopBelt() => currentState = ConveyorState.STOPPED;

    public void ReverseBelt() => currentState = ConveyorState.BACKWARD;

    public string GetState() => currentState.ToString();
}


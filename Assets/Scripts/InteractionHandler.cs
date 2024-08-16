using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] private float raycastRange;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private LayerMask detectionLayers;
    private RaycastHit hit;

    private void Update()
    {
        Rayo();
    }

    private void Rayo()
    {
        if(Physics.Raycast(raycastOrigin.position,raycastOrigin.forward, out hit, raycastRange, detectionLayers))
        {
            Debug.Log(hit.collider.name);
            if(Input.GetKeyDown(KeyCode.E)) 
            { 
                // Esta linea va a activar culaquiera que sea el objeto al que este apuntando y sea un interactuable
                hit.collider.GetComponent<IInteractable>().Interact();
                Debug.Log(hit.collider.name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawRay(raycastOrigin.position, raycastOrigin.forward * raycastRange);
    }

}

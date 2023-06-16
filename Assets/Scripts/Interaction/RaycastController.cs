using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastController : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 5.0f;

    [SerializeField]
    //The layer that will determine what the raycast will hit
    LayerMask layerMask;
    //The UI text component that will display the name of the interactable hit
    public TextMeshProUGUI interactionInfo;

    public bool IsGrounded()
    {
        Debug.Log(Physics.Raycast(transform.position, -Vector3.up //-transform.up
            , raycastDistance, layerMask));
        return Physics.Raycast(transform.position, -Vector3.up //transform.up
            , raycastDistance, layerMask);
    }

    // Update is called once per frame
    private void Update()
    {
        interactionInfo.text = "";
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, layerMask);
        Debug.Log($"Raycast hit {hit.collider.gameObject.name}");
        if (hit.collider.gameObject.GetComponent<Interactable>() != null)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Interacted");
                hit.collider.gameObject.GetComponent<Interactable>().Interact();
            }
            interactionInfo.text = hit.collider.gameObject.GetComponent<Interactable>().id; 
        }
        else interactionInfo.text = "";



        //TODO: Raycast
        //1. Perform a raycast originating from the gameobject's position towards its forward direction.
        //   Make sure that the raycast will only hit the layer specified in the layermask
        //2. Check if the object hits any Interactable. If it does, show the interactionInfo and set its text
        //   to the id of the Interactable hit. If it doesn't hit any Interactable, simply disable the text
        //3. Make sure to interact with the Interactable only when the mouse button is pressed.
    }
}
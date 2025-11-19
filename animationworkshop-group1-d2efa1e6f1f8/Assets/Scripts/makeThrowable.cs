using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class makeThrowable : MonoBehaviour
{
    [SerializeField] private Rigidbody Phone;
    XRGrabInteractable grab;

    private void Awake()
    {
        // resolve components at runtime (safe to call GetComponent here)
        if (Phone == null) Phone = GetComponent<Rigidbody>();          // fallback
        if (Phone != null) grab = Phone.GetComponent<XRGrabInteractable>();
        if (Phone == null) Debug.LogError("Phone Rigidbody not assigned or found.");
        if (grab == null) Debug.LogWarning("XRGrabInteractable not found on phone object.");
    }
    public void Throwable()
    {
        //XRGrabInteractable grab = Phone.GetComponent<XRGrabInteractable>();
        if (grab != null && grab.interactorsSelecting.Count > 0)
        {
            Phone.useGravity = true;
            Phone.isKinematic = false;
        }
        
    }

}

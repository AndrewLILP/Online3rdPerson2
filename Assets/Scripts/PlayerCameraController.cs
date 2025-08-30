using UnityEngine;
using Unity.Netcode;
public class PlayerCameraController : NetworkBehaviour
{
    public GameObject playerCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera.transform.parent = null;
        // Detach the camera from any parent object
        if (IsOwner)
        {
            playerCamera.SetActive(true);
            //Camera.main.enabled = false; // Disable the main camera if it exists
        }
        else
        {
            playerCamera.SetActive(false); // Disable the camera for non-owners
        }
    }

}

using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;



public class TankController : NetworkBehaviour
{
    /// <summary>
    /// Movement Speed
    /// </summary>
    public float Speed = 5;
    public float rotationSpeed = 200;

    void Update()
    {
        // IsOwner will also work in a distributed-authoritative scenario as the owner 
        // has the Authority to update the object.
        if (!IsOwner || !IsSpawned) return;

        var multiplier = Speed * Time.deltaTime;

            // New input system backends are enabled.
            if (Keyboard.current.aKey.isPressed)
            {
            transform.Rotate(0, (-rotationSpeed * Time.deltaTime), 0);
            //transform.position += new Vector3(-multiplier, 0, 0);
            }
            else if (Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(0, (rotationSpeed * Time.deltaTime), 0);
            //transform.position += new Vector3(multiplier, 0, 0);
            }
            else if (Keyboard.current.wKey.isPressed)
            {
                transform.position += transform.forward * multiplier;
            }
            else if (Keyboard.current.sKey.isPressed)
            {
                transform.position += transform.forward * -multiplier;
            }
    }
}

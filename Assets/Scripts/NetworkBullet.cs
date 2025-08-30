using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class NetworkBullet : NetworkBehaviour
{
    public Transform muzzle;
    public GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 20f;



    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        if (Keyboard.current.spaceKey.isPressed)
        {
            ShootServerRPC();
        }
    }

    [ServerRpc]
    void ShootServerRPC()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = muzzle.forward * bulletSpeed;

        bullet.GetComponent<NetworkObject>().Spawn(true);
        UpdateBulletClientRPC(bullet.GetComponent<NetworkObject>().NetworkObjectId, bullet.GetComponent<Rigidbody>().linearVelocity);
    }

    [ClientRpc]
    void UpdateBulletClientRPC(ulong bulletID, Vector3 velocity)
    {
        if (NetworkManager.Singleton.SpawnManager.SpawnedObjects.TryGetValue(bulletID, out NetworkObject networkObj))
        {
            Rigidbody rb = networkObj.GetComponent<Rigidbody>();
            rb.linearVelocity = velocity;
        }
    }
}

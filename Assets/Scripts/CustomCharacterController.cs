using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;
using StarterAssets; // Assuming you have a StarterAssets package for character controls


public class CustomCharacterController : NetworkBehaviour
{
    [SerializeField] private PlayerInput m_PlayerInput; // Reference to the PlayerInput component
    [SerializeField] private StarterAssetsInputs m_StarterAssetsInputs; // Reference to the StarterAssetsInputs component
    [SerializeField] private ThirdPersonController m_ThirdPersonController;
    [SerializeField] private Animator m_Animator; // Reference to the Animator component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        m_PlayerInput.enabled = false;
        m_StarterAssetsInputs.enabled = false;
        m_ThirdPersonController.enabled = false;
        m_Animator.enabled = false; // Disable Animator to prevent it from running before the player is ready
    }
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsOwner)
        {
            m_PlayerInput.enabled = true;
            m_StarterAssetsInputs.enabled = true;
            m_ThirdPersonController.enabled = true;
            m_Animator.enabled = true; // Enable Animator when the player is ready
        }
    }

}

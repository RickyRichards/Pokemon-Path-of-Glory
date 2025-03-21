using UnityEngine;
using Cinemachine;

public class CamOrbit : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    private CinemachineOrbitalTransposer orbital;
    private CinemachineCollider camCollider;

    [Header("Rotation Settings")]
    public float rotationSpeed = 100f;
    public bool isTurning = false;

    [Header("Zoom Settings")]
    public float zoomSpeed = 2f;
    public float minZoom = 4f;
    public float maxZoom = 10f;

    private void Awake()
    {
        if (vCam == null)
            vCam = GetComponent<CinemachineVirtualCamera>();

        if (vCam != null)
        {
            orbital = vCam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
            camCollider = vCam.GetComponent<CinemachineCollider>(); // Get Cinemachine Collider
        }


    }

    private void Start()
    {
       if (camCollider != null)
        {
            camCollider.m_AvoidObstacles = true;  // Enable collision detection
            camCollider.m_CollideAgainst = LayerMask.GetMask("Obstacle"); // Walls Layer
            camCollider.m_Strategy = CinemachineCollider.ResolutionStrategy.PullCameraForward; // Pull Camera Instead of Clipping

            // 🔹 Adjust these values to fine-tune behavior:
            camCollider.m_Damping = 0.5f;  // Smooth transition when avoiding obstacles
            camCollider.m_MinimumOcclusionTime = 0.15f; // Time before reacting to occlusion
            camCollider.m_DistanceLimit = 0.3f; // Prevents it from jumping too far forward
        }
        else
        {
            Debug.LogWarning("CinemachineCollider not found! Make sure it's added to the Virtual Camera.");
        }
    }

    private void Update()
    {
        // ✅ Force Distance Limit to 0 Every Frame
        if (camCollider != null && camCollider.m_DistanceLimit != 0f)
        {
            camCollider.m_DistanceLimit = 0f; // Set this to your preferred value
        }
        HandleRotation();
        HandleZoom();
    }

    private void HandleRotation()
    {
        float orbitVal = 0f;

        // Rotate when holding E (right) or Q (left)
        if (Input.GetKey(KeyCode.E)) orbitVal = 1f;
        if (Input.GetKey(KeyCode.Q)) orbitVal = -1f;

        if (orbital != null)
        {
            if (orbitVal != 0)
            {
                isTurning = true;
                orbital.m_XAxis.m_InputAxisValue = orbitVal * rotationSpeed * Time.deltaTime;
            }
            else
            {
                isTurning = false;
                orbital.m_XAxis.m_InputAxisValue = 0; // Stops rotation immediately when key is released
            }
        }
    }

    private void HandleZoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0f)
        {
            CinemachineFramingTransposer framing = vCam.GetCinemachineComponent<CinemachineFramingTransposer>();
            if (framing != null)
            {
                float newDistance = framing.m_CameraDistance - (scrollInput * zoomSpeed);
                framing.m_CameraDistance = Mathf.Clamp(newDistance, minZoom, maxZoom);
            }
        }
    }
}

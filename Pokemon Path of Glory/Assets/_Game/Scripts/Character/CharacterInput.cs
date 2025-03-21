using UnityEngine;
using UnityEngine.EventSystems; // Needed to detect UI clicks

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private MouseInput mouseInput;
    private CharacterMove move;
    private bool inMenu;

    private void Awake()
    {
        inMenu = false; // Changed to false so movement works by default
        move = GetComponent<CharacterMove>();
        mouseInput = Camera.main.GetComponent<MouseInput>();
    }

    private void Update()
    {
        if (!inMenu && Input.GetMouseButtonDown(0))
        {
            // Prevent movement if clicking UI
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

            move.SetDestination(mouseInput.mousePos);
        }
    }
}

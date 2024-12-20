using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] MouseInput mouseInput;
    CharacterMove move;
    private void Awake() {
        move = GetComponent<CharacterMove>();
        mouseInput = Camera.main.GetComponent<MouseInput>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
        move.SetDestination(mouseInput.mousePos);
        }
    }
}

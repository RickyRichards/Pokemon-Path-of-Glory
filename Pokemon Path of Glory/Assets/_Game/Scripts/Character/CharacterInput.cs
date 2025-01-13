using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] MouseInput mouseInput;
    CharacterMove move;
    public bool inMenu;
    private void Awake() {
        inMenu = true;
        move = GetComponent<CharacterMove>();
        mouseInput = Camera.main.GetComponent<MouseInput>();
    }

    private void Update() {
        if(inMenu == false){
            if(Input.GetMouseButtonDown(0)){
               move.SetDestination(mouseInput.mousePos);
            }
        }
    }
}

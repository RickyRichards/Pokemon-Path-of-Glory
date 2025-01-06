using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [HideInInspector]
    public Vector3 mousePos;
    void Update(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, float.MaxValue)){
            mousePos = hit.point;
        }
    }
}

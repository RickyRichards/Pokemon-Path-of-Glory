using UnityEngine;

public class GridControl : MonoBehaviour
{
    [SerializeField] GridMap targetGrid;
    [SerializeField] LayerMask terrainLayer;
    

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, float.MaxValue, terrainLayer)){
                Vector2Int gridPos = targetGrid.GetGridPosition(hit.point);
                GridObject gridObject = targetGrid.GetPlacedObject(gridPos);
                if(gridObject == null){
                    Debug.Log("x= " + gridPos.x + " y= " + gridPos.y + " is emptyt");
                }
                else{
                    Debug.Log("x= " + gridPos.x + " y= " + gridPos.y + gridObject.GetComponent<Character>().Name);
                }
            }
        }
    }

}

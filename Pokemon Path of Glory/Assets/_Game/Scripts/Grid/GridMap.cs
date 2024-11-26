using System;
using Unity.Mathematics;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    Node[,] grid;

    [SerializeField] int width = 25;
    [SerializeField] int length = 25;
    [SerializeField] float cellSize = 1f;
    [SerializeField] LayerMask obstacleLayer;

    private void Awake() {
        GenerateGrid();
        
    }
    public bool CheckBoundry(Vector2Int posOnGrid){
        if(posOnGrid.x < 0 || posOnGrid.x >= length){
            return false;
        }
         if(posOnGrid.y < 0 || posOnGrid.y >= width){
            return false;
        }
        return true;
    }

    private void GenerateGrid()
    {
        grid = new Node[length, width];

        for (int y = 0; y < width; y++)
        {
            for (int x = 0; x < length; x++)
            {
                grid[x, y] = new Node();
            }
        }
        CheckPassabelTerrain();
    }

    private void CheckPassabelTerrain()
    {
        for (int y = 0; y < width; y++)
        {
            for (int x = 0; x < length; x++)
            {
                Vector3 worldPos = GetWorldPos(x, y);
                bool passable = !Physics.CheckBox(worldPos, Vector3.one / 2 * cellSize, quaternion.identity, obstacleLayer);
                grid[x,y] = new Node();
                grid[x,y].passable = passable;
            }
        }
    }

    private void OnDrawGizmos() {
        if (grid == null) {return; }
        for (int y = 0; y < width; y++)
        {
            for (int x = 0; x < length; x++)
            {
                Vector3 pos = GetWorldPos(x, y);
                Gizmos.color = grid[x, y].passable ? Color.white : Color.red;
                Gizmos.DrawCube(pos, Vector3.one / 4);
            }
        }
    }

    private Vector3 GetWorldPos(int x, int y)
    {
        return new Vector3(transform.position.x + (x * cellSize), 0, transform.position.z + (y * cellSize));
    }

    public Vector2Int GetGridPosition(Vector3 worldPositoin)
    {
        worldPositoin -= transform.position;
        Vector2Int positionOnGrid = new Vector2Int((int)(worldPositoin.x / cellSize), (int)(worldPositoin.z / cellSize));
        return positionOnGrid;
    }

    public void PlaceObject(Vector2Int positionOnGrid, GridObject gridObject)
    {
        if(CheckBoundry(positionOnGrid) == true){
            grid[positionOnGrid.x, positionOnGrid.y].gridObject = gridObject ;
        }
        else{
            Debug.Log("object not in boundry");
        }
    }

    public GridObject GetPlacedObject(Vector2Int gridPos)
    {
        if(CheckBoundry(gridPos) == true){
            GridObject gridObject = grid[gridPos.x, gridPos.y].gridObject;
            return gridObject;
        }
        return null;
    }
}

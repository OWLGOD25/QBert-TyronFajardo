using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTileMapMovement : MonoBehaviour
{
    public Tilemap tilemap;

    public TileBase blueTile;
    public TileBase yellowTile;

    private Vector3Int currentCell;

    void Start()
    {
        // Find the tile the player starts on
        currentCell = tilemap.WorldToCell(transform.position);

        SnapToTile();
        ChangeTile();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            Move(-1, 1);   // top left
        }

        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            Move(1, 1);    // top right
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Move(-1, -1);  // bottom left
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Move(1, -1);   // bottom right
        }
    }

    void Move(int x, int y)
    {
        Vector3Int nextCell = currentCell + new Vector3Int(x, y, 0);

        // Check if there is a tile there
        if (tilemap.HasTile(nextCell))
        {
            currentCell = nextCell;

            SnapToTile();
            ChangeTile();
        }
        else
        {
            Debug.Log("Player fell off pyramid");
        }
    }

    void SnapToTile()
    {
        transform.position = tilemap.GetCellCenterWorld(currentCell);
    }

    void ChangeTile()
    {
        if (tilemap.GetTile(currentCell) == blueTile)
        {
            tilemap.SetTile(currentCell, yellowTile);
        }
    }
}

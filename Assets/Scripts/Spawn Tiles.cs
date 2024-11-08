using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour
{
    [SerializeField] private CreateNumbers createNumbers;
    
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject emptyTilePrefab;

    [SerializeField] private Transform tilesParent;
    [SerializeField] private Transform emptyPlayTilesParent;
    [SerializeField] private Transform emptyPlacementTilesParent;

    [HideInInspector] public List<string> winPosition;
    [HideInInspector] public List<GameObject> tiles;

    public int boardDimension;
    
    private void Start()
    {
        Spawn(2.5f, true, emptyTilePrefab, "Placement_Empty_Tile_", emptyPlacementTilesParent); //placement board
        Spawn(-17.5f, true, emptyTilePrefab, "Play_Empty_Tile_", emptyPlayTilesParent); //play board
        GameStart();
    }

    public void GameStart()
    {
        tiles.Clear();
        winPosition.Clear();
        
        Spawn(-17.5f, false, tilePrefab, "Tile_", tilesParent);
    }

    private void Spawn(float offset, bool isEmpty, GameObject tile, string name, Transform parent)
    {
        float spacing = -0.25f * boardDimension + 1.75f;
        float newScale = (14f - (boardDimension - 1) * spacing) / boardDimension;

        float startingXPos = offset + (newScale / 2f + 0.5f);
        float startingYPos = 7.5f - (newScale / 2f + 0.5f);

        tile.transform.localScale = new Vector3(newScale, newScale, tile.transform.localScale.z);

        for (int i = 0; i < boardDimension; i++)
        {
            for (int j = 0; j < boardDimension; j++)
            {
                float newXPos = startingXPos + i * (newScale + spacing);
                float newYPos = startingYPos - j * (newScale + spacing);

                Vector3 newPos = new(newXPos, newYPos, 0);

                GameObject currentTile = Instantiate(tile, newPos, tile.transform.rotation, parent);
                
                currentTile.name = name + (i * boardDimension + j);
                if (currentTile.name.Contains("Play"))
                {
                    currentTile.AddComponent<EmptyTile>();
                }
                if (!isEmpty)
                {
                    tiles.Add(currentTile);
                    winPosition.Add(currentTile.name);
                }
            }
        }

        if (!isEmpty) createNumbers.MakeNumbers();
    }
}
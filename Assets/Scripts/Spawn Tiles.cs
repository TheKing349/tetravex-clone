using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour
{
    [SerializeField] private CreateNumbers createNumbers;
    [SerializeField] private GameObject tilePrefab;

    [HideInInspector] public List<GameObject> tiles;

    public int boardDimension;
    
    private void Start()
    {
        //flipped these
        Spawn(2.5f, true, new GameObject());
        Spawn(-17.5f, false, tilePrefab);
    }

    private void Spawn(float offset, bool isEmpty, GameObject tile)
    {
        float spacing = -0.25f * boardDimension + 1.75f;
        float newScale = (14f - (boardDimension - 1) * spacing) / boardDimension;

        float startingXPos = offset + (newScale / 2f + 0.5f);
        float startingYPos = 7.5f - (newScale / 2f + 0.5f);

        tilePrefab.transform.localScale = new Vector3(newScale, newScale, tilePrefab.transform.localScale.z);

        for (int i = 0; i < boardDimension; i++)
        {
            for (int j = 0; j < boardDimension; j++)
            {
                float newXPos = startingXPos + i * (newScale + spacing);
                float newYPos = startingYPos - j * (newScale + spacing);

                Vector3 newPos = new(newXPos, newYPos, 0);

                GameObject currentTile = Instantiate(tile, newPos, tile.transform.rotation);

                if (isEmpty)
                {
                    currentTile.name = "Empty_Tile_" + (i * boardDimension + j);
                    //got rid of SetActive(false) -- made GO.Find() not work
                }
                else
                {
                    currentTile.name = "Tile_" + (i * boardDimension + j);
                    tiles.Add(currentTile);
                }
            }
        }

        if (!isEmpty) createNumbers.MakeNumbers();
    }
}
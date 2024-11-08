using UnityEngine;

public class RandomizeTiles : MonoBehaviour
{
    [SerializeField] private SpawnTiles spawnTiles;

    public void Randomize()
    {
        for (int i = 0; i < spawnTiles.boardDimension; i++)
        {
            for (int j = 0; j < spawnTiles.boardDimension; j++)
            {
                int index = Random.Range(0, spawnTiles.tiles.Count);
                GameObject randomTile = spawnTiles.tiles[index];
                
                MoveTile(randomTile, i * spawnTiles.boardDimension + j);
                
                spawnTiles.tiles.RemoveAt(index);
            }
        }
    }

    private static void MoveTile(GameObject tile, int index)
    {
        GameObject emptyTile = GameObject.Find("Placement_Empty_Tile_" + index);
        tile.transform.position = emptyTile.transform.position;
    }
}

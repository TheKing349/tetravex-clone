using UnityEngine;
using UnityEngine.Rendering.UI;

public class WinLogic : MonoBehaviour
{
    [SerializeField] private SpawnTiles spawnTiles;
    [SerializeField] private ClearTiles clearTiles;

    // ReSharper disable Unity.PerformanceAnalysis
    public void CheckWin()
    {
        bool hasWon = true;
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in tiles)
        {
            TileColliderLogic tileColliderLogic = tile.GetComponent<TileColliderLogic>();
            if (!tileColliderLogic.isCorrectPosition)
            {
                hasWon = false;
                break;
            }
        }

        if (hasWon) clearTiles.Clear();
    }
}
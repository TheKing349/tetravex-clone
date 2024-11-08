using System.Collections;
using UnityEngine;

public class ClearTiles : MonoBehaviour
{
    [SerializeField] private SpawnTiles spawnTiles;
    
    [SerializeField] private Transform tilesParent;
    
    public void Clear()
    {
        for (int i = tilesParent.childCount - 1; i >= 0; i--)
        {
            Destroy(tilesParent.GetChild(i).gameObject);
        }
        
        //Destroy needs to wait a frame to remove it from memory
        StartCoroutine(CallGameStartAfterClear());
    }

    private IEnumerator CallGameStartAfterClear()
    {
        yield return null; // Wait for one frame
        spawnTiles.GameStart();
    }
}
using UnityEngine;

public class SpawnTiles : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;

    [SerializeField] private int boardDimension;
    
    private void Start()
    {
        Spawn();
    }
    
    private void Spawn()
    {
        float spacing = -0.25f * boardDimension + 1.75f;
        float newScale = (14f - (boardDimension - 1) * spacing) / boardDimension;

        float startingXPos = -17.5f + (newScale / 2f + 0.5f);
        float startingYPos = 7.5f - (newScale / 2f + 0.5f);

        tilePrefab.transform.localScale = new Vector3(newScale, newScale, tilePrefab.transform.localScale.z);
        
        for (int i = 0; i < boardDimension; i++)
        {
            for (int j = 0; j < boardDimension; j++)
            {
                float newXPos = startingXPos + i * (newScale + spacing);
                float newYPos = startingYPos - j * (newScale + spacing);
                
                Vector3 newPos = new(newXPos, newYPos, 0);
                
                Instantiate(tilePrefab, newPos, tilePrefab.transform.rotation);
            }
        }
    }
}
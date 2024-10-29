using UnityEngine;
using TMPro;

public class CreateNumbers : MonoBehaviour
{
    [SerializeField] private SpawnTiles spawnTiles;

    [SerializeField] private RandomizeTiles randomizeTiles;
    
    public void MakeNumbers()
    {
        for (int i = 0; i < spawnTiles.boardDimension; i++)
        {
            for (int j = 0; j < spawnTiles.boardDimension; j++)
            {
                int index = i * spawnTiles.boardDimension + j;
                
                GameObject currentTile = GameObject.Find("Tile_" + index);
                
                TMP_Text topText = currentTile.transform.Find("Top/Canvas/Text").GetComponent<TMP_Text>();
                TMP_Text bottomText = currentTile.transform.Find("Bottom/Canvas/Text").GetComponent<TMP_Text>();
                TMP_Text leftText = currentTile.transform.Find("Left/Canvas/Text").GetComponent<TMP_Text>();
                TMP_Text rightText = currentTile.transform.Find("Right/Canvas/Text").GetComponent<TMP_Text>();

                topText.text = Random.Range(1, 9).ToString();
                bottomText.text = Random.Range(1, 9).ToString();
                leftText.text = Random.Range(1, 9).ToString();
                rightText.text = Random.Range(1, 9).ToString();
                
                //generate left link
                if (i != 0)
                {
                    int previousSideIndex = (i - 1) * spawnTiles.boardDimension + j;
                    GameObject previousSideTile = GameObject.Find("Tile_" + previousSideIndex);
                    string previousRightText =
                        previousSideTile.transform.Find("Right/Canvas/Text").GetComponent<TMP_Text>().text;
                    
                    leftText.text = previousRightText;
                }

                //generate top link
                if (j != 0)
                {
                    int previousTopIndex = i * spawnTiles.boardDimension + (j - 1);
                    GameObject previousTopTile = GameObject.Find("Tile_" + previousTopIndex);
                    string previousBottomText =
                        previousTopTile.transform.Find("Bottom/Canvas/Text").GetComponent<TMP_Text>().text;
                    
                    topText.text = previousBottomText;
                }
            }
        }

        randomizeTiles.Randomize();
    }
}
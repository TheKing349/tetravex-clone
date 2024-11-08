using UnityEngine;
using TMPro;

public class ValidPlacementLogic : MonoBehaviour
{
    [SerializeField] private SpawnTiles spawnTiles;
    [SerializeField] private TileMovement tileMovement;

    public void Check(Transform currentTile)
    {
        bool isValidMove = true;
        
        string currentTopNumber = currentTile.transform.Find("Top/Canvas/Text").GetComponent<TMP_Text>().text;
        string currentBottomNumber = currentTile.transform.Find("Bottom/Canvas/Text").GetComponent<TMP_Text>().text;
        string currentLeftNumber = currentTile.transform.Find("Left/Canvas/Text").GetComponent<TMP_Text>().text;
        string currentRightNumber = currentTile.transform.Find("Right/Canvas/Text").GetComponent<TMP_Text>().text;
        
        TileColliderLogic tileColliderLogic = currentTile.GetComponent<TileColliderLogic>();
        int emptyTileInt = Utilities.GetIntFromName(tileColliderLogic.emptyTile.name);

        GameObject bottomEmptyTile = null;
        //if in bottom-most position, DO NOT check bottom tile
        if ((emptyTileInt + 1) % spawnTiles.boardDimension != 0) bottomEmptyTile = GameObject.Find("Play_Empty_Tile_" + (emptyTileInt + 1));
        
        GameObject topEmptyTile = null;
        //if in top-most position, DO NOT check top tile
        if (emptyTileInt % spawnTiles.boardDimension != 0) topEmptyTile = GameObject.Find("Play_Empty_Tile_" + (emptyTileInt - 1));
        
        GameObject leftEmptyTile = GameObject.Find("Play_Empty_Tile_" + (emptyTileInt - spawnTiles.boardDimension));
        GameObject rightEmptyTile = GameObject.Find("Play_Empty_Tile_" + (emptyTileInt + spawnTiles.boardDimension));
        
        string bottomTileText = "";
        if (bottomEmptyTile)
        {
            GameObject bottomTile = bottomEmptyTile.GetComponent<EmptyTile>().tile;
            if (bottomTile) bottomTileText = bottomTile.transform.Find("Top/Canvas/Text").GetComponent<TMP_Text>().text; //find top number in bottom tile
        }

        string topTileText = "";
        if (topEmptyTile)
        {
            GameObject topTile = topEmptyTile.GetComponent<EmptyTile>().tile;
            if (topTile) topTileText = topTile.transform.Find("Bottom/Canvas/Text").GetComponent<TMP_Text>().text; //find bottom number in top tile
        }

        string leftTileText = "";
        if (leftEmptyTile)
        {
            GameObject leftTile = leftEmptyTile.GetComponent<EmptyTile>().tile;
            if (leftTile) leftTileText = leftTile.transform.Find("Right/Canvas/Text").GetComponent<TMP_Text>().text; //find right number in left tile
        }

        string rightTileText = "";
        if (rightEmptyTile)
        {
            GameObject rightTile = rightEmptyTile.GetComponent<EmptyTile>().tile;
            if (rightTile) rightTileText = rightTile.transform.Find("Left/Canvas/Text").GetComponent<TMP_Text>().text; //find left number in right tile
        }

        if (topTileText != "" && currentTopNumber != topTileText)
        {
            isValidMove = false;
        }

        if (bottomTileText != "" && currentBottomNumber != bottomTileText)
        {
            isValidMove = false;
        }

        if (rightTileText != "" && currentRightNumber != rightTileText)
        {
            isValidMove = false;
        }

        if (leftTileText != "" && currentLeftNumber != leftTileText)
        {
            isValidMove = false;
        }

        if (!isValidMove)
        {
            tileMovement.RevertMove();
        }
    }
}
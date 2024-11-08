using System.Collections;
using UnityEngine;

public class TileColliderLogic : MonoBehaviour
{
    [SerializeField] private WinLogic winLogic;
    [SerializeField] private ValidPlacementLogic validPlacementLogic;
    [SerializeField] private TileMovement tileMovement;

    [HideInInspector] public GameObject emptyTile;
    [HideInInspector] public bool isCorrectPosition;

    private void Awake()
    {
        winLogic = FindFirstObjectByType<WinLogic>();
        validPlacementLogic = FindFirstObjectByType<ValidPlacementLogic>();
        tileMovement = FindFirstObjectByType<TileMovement>();
    }

    private void OnTriggerStay2D(Collider2D collisionEmptyTile)
    {
        emptyTile = collisionEmptyTile.gameObject;
        
        EmptyTile emptyTileScript = collisionEmptyTile.GetComponent<EmptyTile>();
        if (emptyTileScript) emptyTileScript.tile = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collisionEmptyTile)
    {
        emptyTile = collisionEmptyTile.gameObject;
        
        EmptyTile emptyTileScript = collisionEmptyTile.GetComponent<EmptyTile>();
        if (emptyTileScript) emptyTileScript.tile = gameObject;
        
        if (collisionEmptyTile.name.Contains("Placement")) return;
        
        int tileInt = Utilities.GetIntFromName(name);
        int emptyTileInt = Utilities.GetIntFromName(collisionEmptyTile.name);
        
        if (tileInt == emptyTileInt)
        {
            isCorrectPosition = true;
            winLogic.CheckWin();
        }
        else
        {
            isCorrectPosition = false;
        }
        
        if (!collisionEmptyTile.name.Contains("Placement"))
        {
            StartCoroutine(PlacementLogic());
        }
    }

    private IEnumerator PlacementLogic()
    {
        yield return new WaitUntil(() => tileMovement.isFinishedMoving);
        
        validPlacementLogic.Check(transform);
    }
    
    private void OnTriggerExit2D(Collider2D collisionEmptyTile)
    {
        EmptyTile emptyTileScript = collisionEmptyTile.GetComponent<EmptyTile>();
        if (emptyTileScript) emptyTileScript.tile = null;
        
        emptyTile = null;
    }
}
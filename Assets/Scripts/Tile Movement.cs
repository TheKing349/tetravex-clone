using UnityEngine;
using UnityEngine.Serialization;

public class TileMovement : MonoBehaviour
{
    [SerializeField] private ValidPlacementLogic validPlacementLogic;
    
    private Transform currentTile;
    private Transform clickedTile;
    
    private Transform originalCurrentTile;
    private Transform originalClickedTile;

    private Vector3 originalCurrentTilePosition;
    private Vector3 originalClickedTilePosition;

    [HideInInspector] public bool isFinishedMoving;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            
            if (hit.collider)
            {
                clickedTile = hit.collider.transform;
                Transform highlightObject = clickedTile.transform.Find("Highlight");
                if(highlightObject) highlightObject.gameObject.SetActive(true);
            }
            Move();
        }
    }

    private void Move()
    {
        isFinishedMoving = false;
        if (currentTile)
        {
            originalCurrentTile = currentTile;
            originalCurrentTilePosition = currentTile.transform.position;
        }

        if (clickedTile)
        {
            originalClickedTile = clickedTile;
            originalClickedTilePosition = clickedTile.transform.position;
        }
        
        if (clickedTile && !clickedTile.name.Contains("Empty") && !currentTile)
        {
            currentTile = clickedTile;
        }
        //swap tile positions
        else if (clickedTile && currentTile && clickedTile != currentTile && !clickedTile.name.Contains("Empty"))
        {
            Transform highlightObject = currentTile.transform.Find("Highlight");
            if(highlightObject) highlightObject.gameObject.SetActive(false);
            
            highlightObject = clickedTile.transform.Find("Highlight");
            if(highlightObject) highlightObject.gameObject.SetActive(false);
            
            (currentTile.position, clickedTile.position) = (clickedTile.position, currentTile.position);
            
            clickedTile = null;
            currentTile = null;
        }
        //drop tile
        else if (currentTile && clickedTile == currentTile)
        {
            Transform highlightObject = currentTile.transform.Find("Highlight");
            if(highlightObject) highlightObject.gameObject.SetActive(false);
            
            clickedTile = null;
            currentTile = null;
        }
        //place tile
        else if (currentTile)
        {
            Transform highlightObject = currentTile.transform.Find("Highlight");
            if(highlightObject) highlightObject.gameObject.SetActive(false);
            
            currentTile.position = clickedTile.position;
            
            clickedTile = null;
            currentTile = null;
        }

        isFinishedMoving = true;
    }

    public void RevertMove()
    {
        originalCurrentTile.position = originalCurrentTilePosition;
        originalClickedTile.position = originalClickedTilePosition;
    }
}
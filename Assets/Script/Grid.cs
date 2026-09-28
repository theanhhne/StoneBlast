using UnityEngine;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    public int columns = 8;
    public int rows = 8;
    public float squaresGap = 0.1f;
    public GameObject gridSquarePrefab;
    public Vector2 startPosition = Vector2.zero;
    public float squareScale = 0.5f;
    public float everySquareOffset = 0.5f;
    private int squareIndex = 0;
    private Vector2 _offset = Vector2.zero;
    private List<GameObject> gridSquares = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnGridSquares();
    SetGridSquaresPosition();
    }
    private void SpawnGridSquares()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                GameObject newSquare = Instantiate(gridSquarePrefab) as GameObject; 
                gridSquares.Add(newSquare);

                newSquare.transform.SetParent(this.transform);
                newSquare.transform.localScale = new Vector3(squareScale, squareScale, 1f);
                squareIndex++;
            }
        }
    }
    // Update is called once per frame
    private void SetGridSquaresPosition()
    {
       var squareRect = gridSquares[0].GetComponent<RectTransform>();
            float squareWidth = squareRect.rect.width * squareScale;
            float squareHeight = squareRect.rect.height * squareScale;
            float cellSize = squareWidth + squaresGap; 
            int columnNumber = 0;
            int rowNumber = 0;
            foreach (GameObject square in gridSquares)
            {
                float posX = startPosition.x + (columnNumber * cellSize) + _offset.x;
                float posY = startPosition.y - (rowNumber * cellSize) + _offset.y;
                square.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);
                square.GetComponent<RectTransform>().localPosition = new Vector3(posX, posY, 0f);
                columnNumber++;
                if (columnNumber >= columns)
                {
                    columnNumber = 0;
                    rowNumber++;
                }
            }
        }
    void Update()
    {
        
    }
}

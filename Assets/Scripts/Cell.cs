using System.Collections.Generic;
using UnityEngine;

public abstract class Cell : MonoBehaviour
{
    public bool IsActive = false;

    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Color ActiveColor;
    [SerializeField] protected Color UnactiveColor;

    protected List<Cell> neighbours = new List<Cell>();
    protected bool newState;

    public abstract void CheckNeighbours();
    public abstract void CellBehaviour();

    public void UpdateState()
    {
        IsActive = newState;
        CellBehaviour();
    }

    public void ReceiveNeighbour(Cell neighbour)
    {
        neighbours.Add(neighbour);
    }
}

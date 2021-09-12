using UnityEngine;

public class TrialError : Cell
{
    [Header("Type Specific:")]
    [SerializeField] private int needAlive;
    [SerializeField] private int needDead;

    public override void CheckNeighbours()
    {
        int aliveNeighbours = 0;

        foreach(Cell neighbour in neighbours)
        {
            if(neighbour.IsActive)
            {
                aliveNeighbours++;
            }
        }

        if(aliveNeighbours >= needAlive) // Live on to the next generation
        {
            IsActive = true;
        }
        else if(aliveNeighbours >= needDead)
        {
            IsActive = false;
        }
    }

    public override void CellBehaviour()
    {
        if(IsActive)
        {
            spriteRenderer.color = activeColor;
        }
        else
        {
            spriteRenderer.color = unactiveColor;
        }
    }
}

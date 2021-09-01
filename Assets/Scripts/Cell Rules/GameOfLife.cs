using UnityEngine;

public class GameOfLife : Cell
{
    [Header("Type Specific:")]
    [SerializeField] private Color blendColor;
    [SerializeField] private float minOpacity;
    [SerializeField] private float opacityPerCycle;
    [SerializeField] private bool RainbowBlend;
    [SerializeField] private bool alphaBlend;

    private int generationsAlive;
    private Color rainbow;

    private void Start()
    {
        if(RainbowBlend)
        {
            rainbow = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
    }

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

        if(aliveNeighbours > 1 && aliveNeighbours < 4 && IsActive) // Live on to the next generation
        {
            newState = true;
        }
        else if(aliveNeighbours == 3 && !IsActive) // Reproduction
        {
            newState = true;
        }
        else // Dead by over/under population
        {
            newState = false;
        }
    }

    public override void CellBehaviour()
    {
        if(IsActive)
        {
            generationsAlive++;
            float alpha = generationsAlive * opacityPerCycle;
            Mathf.Clamp(alpha, minOpacity, 1f);

            Color blend;

            if(RainbowBlend)
            {
                rainbow = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                blend = (1f - alpha) * rainbow + alpha * ActiveColor;
            }
            else
            {
                blend = (1f - alpha) * blendColor + alpha * ActiveColor;
            }

            if(alphaBlend)
            {
                blend.a = alpha;
            }

            spriteRenderer.color = blend;
        }
        else
        {
            spriteRenderer.color = UnactiveColor;
            generationsAlive = 0;
        }
    }
}

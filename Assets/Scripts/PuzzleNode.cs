using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PuzzleNode
{
    public int positionInGridX;
    public int positionInGridY;
    public int number;

    public PuzzleNode(int positionInGridX, int positionInGridY, int number)
    {
        this.positionInGridX = positionInGridX;
        this.positionInGridY = positionInGridY;
        this.number = number;
    }
}


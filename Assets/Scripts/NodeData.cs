public class NodeData
{
    private int positionInGridX; // column
    private int positionInGridY; // row
    private int number;

    public int PositionInGridX { get => positionInGridX; }
    public int PositionInGridY { get => positionInGridY; }
    public int Number { get => number; }

    public NodeData(int positionInGridX, int positionInGridY, int number)
    {
        this.positionInGridX = positionInGridX;
        this.positionInGridY = positionInGridY;
        this.number = number;
    }

    // TODO move all them to nodecontroller?
    public bool IsNodeLeftOfCoordinate(int column, int row)
    {
        return PositionInGridX == column && PositionInGridY == row - 1;
    }

    public bool IsNodeAboveCoordinate(int column, int row)
    {
        return PositionInGridX == column - 1 && PositionInGridY == row;
    }

    public bool IsNodeLeftAndAboveCoordinate(int column, int row)
    {
        return PositionInGridX == column - 1 && PositionInGridY == row - 1;
    }

    public bool IsAtCoordinate(int x, int y)
    {
        return y == PositionInGridY && x == PositionInGridX;
    }
}

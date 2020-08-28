public class Path
{
    public Path leftChild;

    public Path rightChild;

    public Colors Colors;

    public override string ToString()
    {
        return $"{this.Colors}, " +
            $"LeftChild({((this.leftChild != null) ? true : false)}), " +
            $"RightChild({((this.rightChild != null) ? true : false)})";
    }
}

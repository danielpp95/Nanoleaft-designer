public class CMYK
{
    public int C;
    public int M;
    public int Y;
    public int K;

    public CMYK(int c, int m, int y, int k)
    {
        this.C = c;
        this.M = m;
        this.Y = y;
        this.K = k;
    }

    public override string ToString()
    {
        return $"CMYK({this.C}, {this.M}, {this.Y}, {this.K})";
    }
}

namespace ProjectTriany
{
public class Triany
{
    public int A { get; set; }

    public int B { get; set; }

    public int C { get; set; }

    public override string ToString()
    {
        return string.Format("[{0},{1},{2}]", A, B, C);
    }
}
}
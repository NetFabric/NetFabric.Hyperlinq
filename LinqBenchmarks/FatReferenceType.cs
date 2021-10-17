namespace LinqBenchmarks;

public class FatReferenceType
{
    private int field1;
    private int field2;
    private int field3;
    private int field4;

    public FatReferenceType()
        => field1 = 2 * (field2 = 3 * (field3 = 4 * (field4 = GetHashCode())));

    public FatReferenceType(int c) : this() => field1 = c;
}
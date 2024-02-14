## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.28.2](https://www.nuget.org/packages/StructLinq/0.28.2)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3996/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.100-preview.1.24101.2
  [Host]     : .NET 6.0.26 (6.0.2623.60508), X64 RyuJIT AVX2
  Job-THTHEP : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  Job-OQLBIM : .NET 9.0.0 (9.0.24.8009), X64 RyuJIT AVX2


```
| Method                   | Runtime  | Duplicates | Count | Mean        | Error     | StdDev    | Median      | Ratio         | RatioSD | Gen0    | Allocated | Alloc Ratio     |
|------------------------- |--------- |----------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|--------:|----------:|----------------:|
| ForLoop                  | .NET 8.0 | 4          | 100   | 12,705.7 ns | 250.92 ns | 518.19 ns | 12,540.1 ns |      baseline |         | 12.8937 |   26976 B |                 |
| ForeachLoop              | .NET 8.0 | 4          | 100   | 12,772.3 ns | 254.65 ns | 411.21 ns | 12,615.7 ns |  1.01x slower |   0.05x | 12.8937 |   26976 B |     1.000x more |
| Linq                     | .NET 8.0 | 4          | 100   | 14,185.4 ns | 175.97 ns | 164.61 ns | 14,131.1 ns |  1.12x slower |   0.06x | 12.8174 |   26912 B |     1.002x less |
| LinqFaster               | .NET 8.0 | 4          | 100   |    907.7 ns |  16.81 ns |  32.78 ns |    893.8 ns | 14.02x faster |   0.62x |  0.0114 |      24 B | 1,124.000x less |
| LinqFasterer             | .NET 8.0 | 4          | 100   | 16,413.4 ns | 239.07 ns | 211.93 ns | 16,338.1 ns |  1.29x slower |   0.07x | 34.8816 |   73168 B |     2.712x more |
| LinqAF                   | .NET 8.0 | 4          | 100   | 34,384.5 ns | 359.37 ns | 318.57 ns | 34,255.5 ns |  2.70x slower |   0.14x | 21.8506 |   45856 B |     1.700x more |
| StructLinq               | .NET 8.0 | 4          | 100   | 11,407.5 ns | 205.01 ns | 171.19 ns | 11,326.9 ns |  1.12x faster |   0.06x |  0.0305 |      64 B |   421.500x less |
| StructLinq_ValueDelegate | .NET 8.0 | 4          | 100   |  3,359.6 ns |  65.90 ns | 118.83 ns |  3,318.3 ns |  3.78x faster |   0.20x |       - |         - |              NA |
| Hyperlinq                | .NET 8.0 | 4          | 100   | 11,645.3 ns | 180.26 ns | 140.73 ns | 11,638.2 ns |  1.10x faster |   0.06x |       - |         - |              NA |
|                          |          |            |       |             |           |           |             |               |         |         |           |                 |
| ForLoop                  | .NET 9.0 | 4          | 100   | 12,720.1 ns | 253.33 ns | 680.57 ns | 12,365.6 ns |      baseline |         | 12.8937 |   26976 B |                 |
| ForeachLoop              | .NET 9.0 | 4          | 100   | 12,445.4 ns | 243.52 ns | 445.28 ns | 12,260.2 ns |  1.03x faster |   0.08x | 12.8937 |   26976 B |     1.000x more |
| Linq                     | .NET 9.0 | 4          | 100   | 14,130.6 ns | 282.41 ns | 763.50 ns | 13,780.1 ns |  1.11x slower |   0.07x | 12.8174 |   26912 B |     1.002x less |
| LinqFaster               | .NET 9.0 | 4          | 100   |    880.6 ns |   5.63 ns |   6.26 ns |    879.4 ns | 14.38x faster |   0.63x |  0.0114 |      24 B | 1,124.000x less |
| LinqFasterer             | .NET 9.0 | 4          | 100   | 15,679.6 ns | 294.04 ns | 275.04 ns | 15,614.5 ns |  1.23x slower |   0.06x | 34.8816 |   73168 B |     2.712x more |
| LinqAF                   | .NET 9.0 | 4          | 100   | 32,906.2 ns | 625.20 ns | 554.23 ns | 32,759.0 ns |  2.58x slower |   0.14x | 21.8506 |   45784 B |     1.697x more |
| StructLinq               | .NET 9.0 | 4          | 100   | 11,258.2 ns | 114.59 ns |  95.69 ns | 11,220.0 ns |  1.14x faster |   0.06x |  0.0305 |      64 B |   421.500x less |
| StructLinq_ValueDelegate | .NET 9.0 | 4          | 100   |  3,353.4 ns |  44.34 ns |  41.48 ns |  3,356.1 ns |  3.81x faster |   0.18x |       - |         - |              NA |
| Hyperlinq                | .NET 9.0 | 4          | 100   | 11,316.0 ns | 209.85 ns | 344.79 ns | 11,152.2 ns |  1.12x faster |   0.05x |       - |         - |              NA |

## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3516/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-rc.1.23463.5
  [Host]     : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-VLSRZF : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-CRYVOQ : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2


```
|                   Method |  Runtime | Count |        Mean |     Error |    StdDev |      Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |------------:|----------:|----------:|------------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |   210.87 ns |  2.831 ns |  2.780 ns |   209.76 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |   324.36 ns |  5.782 ns |  4.514 ns |   322.55 ns | 1.53x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 |   925.75 ns | 15.853 ns | 19.469 ns |   917.73 ns | 4.40x slower |   0.13x | 0.0458 |      96 B |          NA |
|               LinqFaster | .NET 6.0 |   100 |   399.83 ns |  1.804 ns |  1.409 ns |   399.36 ns | 1.89x slower |   0.03x |      - |         - |          NA |
|             LinqFasterer | .NET 6.0 |   100 |   586.05 ns |  7.543 ns |  8.384 ns |   587.69 ns | 2.79x slower |   0.04x | 3.0670 |    6424 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 1,001.34 ns | 19.171 ns | 42.879 ns | 1,005.89 ns | 4.56x slower |   0.20x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 |   203.57 ns |  2.116 ns |  1.652 ns |   203.44 ns | 1.04x faster |   0.02x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |    84.88 ns |  0.222 ns |  0.173 ns |    84.87 ns | 2.49x faster |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 |   454.25 ns |  5.827 ns |  5.166 ns |   452.24 ns | 2.15x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 |   303.13 ns |  1.144 ns |  0.893 ns |   302.89 ns | 1.43x slower |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 1,224.27 ns | 16.280 ns | 18.748 ns | 1,219.22 ns | 5.83x slower |   0.11x | 0.5836 |    1224 B |          NA |
|                          |          |       |             |           |           |             |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |    63.92 ns |  0.661 ns |  0.516 ns |    63.80 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |   135.89 ns |  2.038 ns |  1.591 ns |   135.56 ns | 2.13x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 |   326.38 ns |  3.129 ns |  2.613 ns |   325.79 ns | 5.11x slower |   0.04x | 0.0458 |      96 B |          NA |
|               LinqFaster | .NET 8.0 |   100 |   137.36 ns |  2.747 ns |  2.435 ns |   136.34 ns | 2.14x slower |   0.03x |      - |         - |          NA |
|             LinqFasterer | .NET 8.0 |   100 |   531.87 ns | 10.151 ns | 13.551 ns |   527.30 ns | 8.30x slower |   0.26x | 3.0670 |    6424 B |          NA |
|                   LinqAF | .NET 8.0 |   100 |   409.76 ns |  5.413 ns |  4.520 ns |   407.76 ns | 6.41x slower |   0.09x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |   179.33 ns |  2.967 ns |  2.478 ns |   178.85 ns | 2.81x slower |   0.05x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |    49.46 ns |  1.010 ns |  1.542 ns |    48.66 ns | 1.29x faster |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |   122.00 ns |  0.643 ns |  0.570 ns |   121.94 ns | 1.91x slower |   0.02x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |    41.16 ns |  0.592 ns |  0.494 ns |    41.00 ns | 1.55x faster |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 |   420.73 ns |  6.837 ns |  6.395 ns |   418.79 ns | 6.58x slower |   0.14x | 0.5660 |    1184 B |          NA |

## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                   Method |  Runtime | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 | 1,643.52 ns | 28.303 ns | 23.635 ns | 1,634.02 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 | 1,746.28 ns | 34.708 ns | 37.137 ns | 1,727.98 ns |  1.06x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 3,151.78 ns | 62.828 ns | 97.816 ns | 3,090.20 ns |  1.92x slower |   0.05x | 0.0877 |     184 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 2,805.32 ns | 22.574 ns | 18.850 ns | 2,800.65 ns |  1.71x slower |   0.03x | 3.0861 |    6456 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 3,033.58 ns | 57.484 ns | 59.031 ns | 3,023.87 ns |  1.85x slower |   0.05x | 6.1531 |   12880 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 2,734.40 ns | 21.791 ns | 18.197 ns | 2,730.66 ns |  1.66x slower |   0.03x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 1,773.21 ns | 34.422 ns | 36.832 ns | 1,752.83 ns |  1.08x slower |   0.03x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 2,322.56 ns |  4.142 ns |  3.234 ns | 2,323.27 ns |  1.41x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 1,878.14 ns | 35.582 ns | 33.283 ns | 1,862.87 ns |  1.14x slower |   0.03x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 1,614.80 ns | 20.566 ns | 17.173 ns | 1,606.48 ns |  1.02x faster |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 3,425.80 ns | 66.461 ns | 93.169 ns | 3,396.95 ns |  2.09x slower |   0.07x | 7.7820 |   16304 B |          NA |
|                          |          |       |             |           |           |             |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   120.70 ns |  0.568 ns |  0.504 ns |   120.64 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |   156.32 ns |  0.898 ns |  0.750 ns |   156.26 ns |  1.30x slower |   0.01x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 | 1,142.70 ns |  9.080 ns |  7.582 ns | 1,140.35 ns |  9.47x slower |   0.07x | 0.0877 |     184 B |          NA |
|               LinqFaster | .NET 8.0 |   100 |   952.80 ns |  8.074 ns |  7.552 ns |   948.48 ns |  7.89x slower |   0.07x | 3.0861 |    6456 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 1,320.85 ns | 19.586 ns | 15.291 ns | 1,317.16 ns | 10.94x slower |   0.14x | 6.1531 |   12880 B |          NA |
|                   LinqAF | .NET 8.0 |   100 | 1,152.51 ns |  8.639 ns |  7.214 ns | 1,148.69 ns |  9.55x slower |   0.08x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |   249.54 ns |  3.333 ns |  4.780 ns |   248.27 ns |  2.08x slower |   0.05x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   113.66 ns |  2.275 ns |  3.037 ns |   112.48 ns |  1.06x faster |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |   317.76 ns |  5.554 ns |  4.336 ns |   316.36 ns |  2.63x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |    99.70 ns |  2.035 ns |  3.670 ns |    97.94 ns |  1.19x faster |   0.05x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 | 1,554.45 ns | 13.657 ns | 11.404 ns | 1,552.53 ns | 12.88x slower |   0.09x | 7.7820 |   16304 B |          NA |

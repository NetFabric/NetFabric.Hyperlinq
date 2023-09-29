## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|                   Method |  Runtime | Count |        Mean |     Error |     StdDev |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |------------:|----------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |   444.17 ns |  5.491 ns |   4.287 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |   542.80 ns | 10.890 ns |  10.696 ns | 1.22x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 1,061.25 ns | 20.777 ns |  21.336 ns | 2.40x slower |   0.06x | 0.0496 |     104 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 1,784.26 ns | 43.118 ns | 125.093 ns | 4.08x slower |   0.44x | 4.7264 |    9904 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 2,102.97 ns | 34.538 ns |  26.965 ns | 4.74x slower |   0.08x | 3.0174 |    6328 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 1,142.47 ns | 22.779 ns |  26.232 ns | 2.59x slower |   0.08x |      - |         - |          NA |
|                 SpanLinq | .NET 6.0 |   100 |   765.75 ns | 14.764 ns |  22.099 ns | 1.73x slower |   0.06x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 |   649.18 ns |  5.712 ns |   4.770 ns | 1.46x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |   547.99 ns |  2.950 ns |   2.760 ns | 1.23x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 1,043.62 ns |  2.608 ns |   2.312 ns | 2.35x slower |   0.03x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 |   836.54 ns | 15.338 ns |  18.258 ns | 1.90x slower |   0.05x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 1,671.13 ns | 28.829 ns |  29.605 ns | 3.76x slower |   0.08x | 3.0670 |    6424 B |          NA |
|                          |          |       |             |           |            |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   111.71 ns |  2.212 ns |   3.756 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |    71.23 ns |  0.917 ns |   0.716 ns | 1.56x faster |   0.04x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 |   660.91 ns | 12.844 ns |  10.028 ns | 5.95x slower |   0.16x | 0.0496 |     104 B |          NA |
|               LinqFaster | .NET 8.0 |   100 |   840.94 ns |  5.882 ns |   4.592 ns | 7.58x slower |   0.16x | 4.7274 |    9904 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 |   968.33 ns | 12.862 ns |  12.031 ns | 8.60x slower |   0.40x | 3.0193 |    6328 B |          NA |
|                   LinqAF | .NET 8.0 |   100 |   328.66 ns |  2.756 ns |   2.152 ns | 2.96x slower |   0.07x |      - |         - |          NA |
|                 SpanLinq | .NET 8.0 |   100 |   234.18 ns |  2.918 ns |   2.437 ns | 2.10x slower |   0.06x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |   219.66 ns |  1.241 ns |   1.161 ns | 1.95x slower |   0.08x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |    96.37 ns |  0.660 ns |   0.618 ns | 1.17x faster |   0.05x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |   290.01 ns |  3.272 ns |   2.732 ns | 2.60x slower |   0.08x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   117.68 ns |  0.560 ns |   0.497 ns | 1.05x slower |   0.04x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 |   678.39 ns | 13.306 ns |  17.763 ns | 6.07x slower |   0.21x | 3.0670 |    6424 B |          NA |

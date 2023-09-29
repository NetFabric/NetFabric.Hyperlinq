## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                   Method |  Runtime | Skip | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 | 1000 |   100 |  2,334.4 ns |  44.64 ns |  49.61 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 6.0 | 1000 |   100 |  2,611.4 ns |  43.38 ns |  48.22 ns |  1.12x slower |   0.02x | 0.1526 |     320 B |          NA |
|               LinqFaster | .NET 6.0 | 1000 |   100 |  3,919.5 ns |  85.44 ns | 242.37 ns |  1.77x slower |   0.07x | 9.2010 |   19272 B |          NA |
|             LinqFasterer | .NET 6.0 | 1000 |   100 |  3,188.1 ns |  62.60 ns |  55.50 ns |  1.37x slower |   0.01x | 6.1531 |   12880 B |          NA |
|                   LinqAF | .NET 6.0 | 1000 |   100 | 16,771.4 ns | 309.65 ns | 289.65 ns |  7.18x slower |   0.24x |      - |         - |          NA |
|                 SpanLinq | .NET 6.0 | 1000 |   100 |  2,145.0 ns |  18.26 ns |  14.26 ns |  1.09x faster |   0.03x |      - |         - |          NA |
|               StructLinq | .NET 6.0 | 1000 |   100 |  1,802.8 ns |  29.64 ns |  24.75 ns |  1.29x faster |   0.03x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 | 1000 |   100 |  1,759.3 ns |  17.53 ns |  14.64 ns |  1.33x faster |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 | 1000 |   100 |  1,881.6 ns |  14.42 ns |  11.26 ns |  1.24x faster |   0.03x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 | 1000 |   100 |  1,714.2 ns |  25.07 ns |  23.45 ns |  1.36x faster |   0.04x |      - |         - |          NA |
|                          |          |      |       |             |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8.0 | 1000 |   100 |    121.7 ns |   1.44 ns |   1.21 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 8.0 | 1000 |   100 |  1,284.9 ns |  15.53 ns |  12.97 ns | 10.56x slower |   0.16x | 0.1526 |     320 B |          NA |
|               LinqFaster | .NET 8.0 | 1000 |   100 |  1,590.0 ns |  27.85 ns |  45.76 ns | 13.26x slower |   0.40x | 9.2010 |   19272 B |          NA |
|             LinqFasterer | .NET 8.0 | 1000 |   100 |  1,539.3 ns |  29.63 ns |  26.26 ns | 12.67x slower |   0.21x | 6.1531 |   12880 B |          NA |
|                   LinqAF | .NET 8.0 | 1000 |   100 |  2,404.5 ns |  39.64 ns |  40.71 ns | 19.80x slower |   0.36x |      - |         - |          NA |
|                 SpanLinq | .NET 8.0 | 1000 |   100 |    191.6 ns |   3.25 ns |   3.04 ns |  1.58x slower |   0.03x |      - |         - |          NA |
|               StructLinq | .NET 8.0 | 1000 |   100 |    295.3 ns |   4.75 ns |   4.45 ns |  2.43x slower |   0.03x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    113.5 ns |   1.56 ns |   1.38 ns |  1.07x faster |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 | 1000 |   100 |    298.7 ns |   3.35 ns |   3.13 ns |  2.45x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    102.9 ns |   2.08 ns |   2.85 ns |  1.18x faster |   0.04x |      - |         - |          NA |

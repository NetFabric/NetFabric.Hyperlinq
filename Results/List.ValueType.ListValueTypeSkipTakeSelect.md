## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-preview.5.23303.2
  [Host] : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 6 : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 8 : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2


```
|                   Method |    Job |  Runtime | Skip | Count |        Mean |     Error |      StdDev |      Median |         Ratio | RatioSD |    Gen0 |    Gen1 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |----- |------ |------------:|----------:|------------:|------------:|--------------:|--------:|--------:|--------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 | 1000 |   100 |  2,380.2 ns |   8.87 ns |     7.41 ns |  2,382.0 ns |      baseline |         |       - |       - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 | 1000 |   100 |  2,561.8 ns |  32.81 ns |    25.61 ns |  2,551.8 ns |  1.08x slower |   0.01x |  0.1526 |       - |     320 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 | 1000 |   100 |  6,581.0 ns | 101.47 ns |    94.91 ns |  6,550.4 ns |  2.77x slower |   0.04x |  9.2545 |       - |   19368 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 | 1000 |   100 |  7,710.1 ns | 120.46 ns |   106.79 ns |  7,705.7 ns |  3.24x slower |   0.05x | 38.4521 |       - |   83304 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 | 1000 |   100 |  9,914.7 ns | 190.85 ns |   267.54 ns |  9,817.7 ns |  4.13x slower |   0.09x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |   100 | 19,556.4 ns | 483.12 ns | 1,346.75 ns | 18,849.3 ns |  8.23x slower |   0.68x | 49.9878 | 16.6626 |  137863 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 | 1000 |   100 | 20,060.4 ns | 278.58 ns |   433.72 ns | 19,896.1 ns |  8.47x slower |   0.25x |  0.5493 |       - |    1176 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 | 1000 |   100 |  1,811.3 ns |  33.97 ns |    40.44 ns |  1,792.1 ns |  1.31x faster |   0.03x |  0.0572 |       - |     120 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |  1,703.1 ns |  32.82 ns |    27.41 ns |  1,698.0 ns |  1.40x faster |   0.02x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 |  1,914.3 ns |   6.74 ns |     5.63 ns |  1,913.5 ns |  1.24x faster |   0.01x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |  1,768.0 ns |  28.22 ns |    28.98 ns |  1,756.2 ns |  1.34x faster |   0.02x |       - |       - |         - |          NA |
|                          |        |          |      |       |             |           |             |             |               |         |         |         |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 | 1000 |   100 |    810.0 ns |   4.53 ns |     3.54 ns |    808.6 ns |      baseline |         |       - |       - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 | 1000 |   100 |  1,899.5 ns |  37.14 ns |    42.77 ns |  1,883.4 ns |  2.32x slower |   0.03x |  0.1526 |       - |     320 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 | 1000 |   100 |  3,691.8 ns |  88.22 ns |   258.75 ns |  3,553.2 ns |  4.65x slower |   0.38x |  9.2583 |       - |   19368 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 | 1000 |   100 |  7,485.5 ns | 135.06 ns |   269.73 ns |  7,366.4 ns |  9.45x slower |   0.43x | 38.4521 |       - |   83304 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 | 1000 |   100 |  7,063.8 ns | 106.43 ns |   126.69 ns |  6,991.7 ns |  8.74x slower |   0.16x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 | 1000 |   100 | 21,478.2 ns | 221.97 ns |   173.30 ns | 21,385.8 ns | 26.52x slower |   0.25x | 60.5774 | 15.1367 |  137884 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 | 1000 |   100 | 15,269.8 ns | 136.98 ns |   114.38 ns | 15,222.0 ns | 18.84x slower |   0.17x |  0.5493 |       - |    1176 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 | 1000 |   100 |  1,683.4 ns |  22.71 ns |    18.96 ns |  1,677.8 ns |  2.08x slower |   0.02x |  0.0572 |       - |     120 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |    792.8 ns |  15.91 ns |    31.40 ns |    800.2 ns |  1.02x slower |   0.03x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 |  1,595.4 ns |  23.62 ns |    19.73 ns |  1,588.8 ns |  1.97x slower |   0.02x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |    859.6 ns |  16.13 ns |    15.08 ns |    852.3 ns |  1.06x slower |   0.02x |       - |       - |         - |          NA |

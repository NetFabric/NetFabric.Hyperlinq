## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                   Method |    Job |  Runtime | Count |        Mean |     Error |      StdDev |      Median |         Ratio | RatioSD |    Gen0 |    Gen1 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |------------:|----------:|------------:|------------:|--------------:|--------:|--------:|--------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |  1,705.1 ns |  30.32 ns |    31.13 ns |  1,690.9 ns |      baseline |         |       - |       - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |  1,767.4 ns |  31.35 ns |    36.10 ns |  1,755.2 ns |  1.04x slower |   0.03x |       - |       - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |  2,545.1 ns |  20.78 ns |    16.23 ns |  2,541.3 ns |  1.50x slower |   0.03x |  0.0877 |       - |     184 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |  2,937.8 ns |  55.30 ns |    51.73 ns |  2,936.7 ns |  1.72x slower |   0.05x |  3.0823 |       - |    6456 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |  3,041.7 ns |  30.01 ns |    23.43 ns |  3,039.3 ns |  1.79x slower |   0.03x |  6.1531 |       - |   12880 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |  2,802.3 ns |  38.63 ns |    36.13 ns |  2,793.5 ns |  1.64x slower |   0.04x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 |  9,833.6 ns | 136.19 ns |   113.72 ns |  9,828.7 ns |  5.78x slower |   0.15x | 57.1747 | 15.6403 |  137866 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 10,587.9 ns |  76.97 ns |    60.10 ns | 10,581.9 ns |  6.23x slower |   0.11x |  0.3967 |       - |     848 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |  1,820.2 ns |  36.27 ns |    54.29 ns |  1,785.9 ns |  1.07x slower |   0.05x |  0.0191 |       - |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |  1,738.2 ns |  12.68 ns |    10.59 ns |  1,735.4 ns |  1.02x slower |   0.02x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |  1,927.2 ns |  35.96 ns |    36.93 ns |  1,909.3 ns |  1.13x slower |   0.03x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |  1,643.1 ns |  23.54 ns |    19.65 ns |  1,637.0 ns |  1.04x faster |   0.02x |       - |       - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 |  3,546.5 ns |  77.61 ns |   225.17 ns |  3,421.5 ns |  2.07x slower |   0.17x |  7.7820 |       - |   16304 B |          NA |
|                          |        |          |       |             |           |             |             |               |         |         |         |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |    837.9 ns |  14.60 ns |    12.19 ns |    831.5 ns |      baseline |         |       - |       - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |    901.4 ns |   6.81 ns |     6.04 ns |    900.8 ns |  1.08x slower |   0.02x |       - |       - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |  1,917.9 ns |  20.31 ns |    15.86 ns |  1,911.2 ns |  2.29x slower |   0.03x |  0.0877 |       - |     184 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |  2,453.0 ns |  35.71 ns |    27.88 ns |  2,442.9 ns |  2.93x slower |   0.03x |  3.0861 |       - |    6456 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |  2,712.5 ns |  31.63 ns |    26.42 ns |  2,714.4 ns |  3.24x slower |   0.05x |  6.1531 |       - |   12880 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |  2,126.7 ns |  37.18 ns |    42.82 ns |  2,110.7 ns |  2.55x slower |   0.08x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 14,289.1 ns | 489.84 ns | 1,421.13 ns | 13,573.6 ns | 19.53x slower |   1.66x | 60.5316 | 15.1520 |  137884 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 10,096.6 ns | 199.44 ns |   504.02 ns |  9,862.3 ns | 12.25x slower |   0.59x |  0.3967 |       - |     848 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |  1,726.6 ns |  33.76 ns |    33.15 ns |  1,713.0 ns |  2.07x slower |   0.06x |  0.0191 |       - |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |    756.1 ns |  10.88 ns |     9.08 ns |    752.9 ns |  1.11x faster |   0.01x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |  1,650.6 ns |  32.44 ns |    30.35 ns |  1,639.9 ns |  1.97x slower |   0.03x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |    856.7 ns |  16.48 ns |    16.92 ns |    847.5 ns |  1.03x slower |   0.03x |       - |       - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |  3,051.9 ns |  49.06 ns |    38.30 ns |  3,042.9 ns |  3.64x slower |   0.09x |  7.7820 |       - |   16304 B |          NA |

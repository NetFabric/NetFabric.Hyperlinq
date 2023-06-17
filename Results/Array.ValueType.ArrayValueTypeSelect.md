## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                   Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |    Gen0 |    Gen1 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|--------:|--------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |  1,562.2 ns |  21.57 ns |  18.01 ns |  1,555.5 ns |      baseline |         |       - |       - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |  1,644.6 ns |  32.73 ns |  30.62 ns |  1,629.2 ns |  1.05x slower |   0.03x |       - |       - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |  2,190.4 ns |  25.11 ns |  19.61 ns |  2,183.6 ns |  1.40x slower |   0.02x |  0.0496 |       - |     104 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |  2,366.0 ns |  38.75 ns |  50.39 ns |  2,346.9 ns |  1.53x slower |   0.04x |  3.0670 |       - |    6424 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |  3,305.6 ns |  38.40 ns |  32.06 ns |  3,307.2 ns |  2.12x slower |   0.03x |  3.0823 |       - |    6456 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |  2,675.4 ns |  44.81 ns |  39.72 ns |  2,663.3 ns |  1.71x slower |   0.04x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 |  9,256.4 ns | 165.77 ns | 248.11 ns |  9,199.1 ns |  5.93x slower |   0.20x | 50.0031 | 16.6626 |  137767 B |          NA |
|                 SpanLinq | .NET 6 | .NET 6.0 |   100 |  2,141.6 ns |   8.12 ns |   7.20 ns |  2,141.5 ns |  1.37x slower |   0.02x |       - |       - |         - |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 11,579.8 ns | 218.09 ns | 251.15 ns | 11,515.0 ns |  7.47x slower |   0.21x |  0.3815 |       - |     824 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |  1,792.3 ns |  31.70 ns |  29.65 ns |  1,782.1 ns |  1.15x slower |   0.02x |  0.0153 |       - |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |  1,743.3 ns |  30.44 ns |  42.68 ns |  1,720.2 ns |  1.12x slower |   0.04x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |  1,896.7 ns |   7.37 ns |   5.76 ns |  1,897.5 ns |  1.21x slower |   0.02x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |  1,749.3 ns |  11.40 ns |   8.90 ns |  1,749.8 ns |  1.12x slower |   0.01x |       - |       - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 |  2,387.9 ns |  11.59 ns |   9.68 ns |  2,387.7 ns |  1.53x slower |   0.02x |  3.0670 |       - |    6424 B |          NA |
|                          |        |          |       |             |           |           |             |               |         |         |         |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |    761.9 ns |  14.71 ns |  20.13 ns |    754.1 ns |      baseline |         |       - |       - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |    814.8 ns |  16.25 ns |  37.00 ns |    816.2 ns |  1.11x slower |   0.04x |       - |       - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |  1,789.3 ns |  17.20 ns |  13.43 ns |  1,784.3 ns |  2.32x slower |   0.07x |  0.0496 |       - |     104 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |  2,172.2 ns |  39.28 ns |  48.24 ns |  2,156.3 ns |  2.85x slower |   0.07x |  3.0670 |       - |    6424 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |  2,243.8 ns |  34.28 ns |  30.39 ns |  2,233.9 ns |  2.92x slower |   0.09x |  3.0861 |       - |    6456 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |  1,926.5 ns |   5.85 ns |   5.47 ns |  1,925.0 ns |  2.51x slower |   0.07x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 |  9,515.0 ns | 125.77 ns | 105.02 ns |  9,483.7 ns | 12.35x slower |   0.40x | 64.4836 |  0.0305 |  137754 B |          NA |
|                 SpanLinq | .NET 8 | .NET 8.0 |   100 |  1,820.4 ns |   6.22 ns |   5.82 ns |  1,818.5 ns |  2.37x slower |   0.06x |       - |       - |         - |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 |  9,622.2 ns |  62.79 ns |  49.02 ns |  9,624.2 ns | 12.46x slower |   0.36x |  0.3815 |       - |     824 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |  1,710.7 ns |  33.71 ns |  70.37 ns |  1,686.9 ns |  2.29x slower |   0.12x |  0.0153 |       - |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |    806.5 ns |  14.08 ns |  18.30 ns |    796.4 ns |  1.06x slower |   0.02x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |  1,530.1 ns |  28.06 ns |  34.46 ns |  1,510.8 ns |  2.01x slower |   0.07x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |    849.6 ns |  11.91 ns |  10.56 ns |    845.3 ns |  1.10x slower |   0.03x |       - |       - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |  2,101.1 ns |  21.02 ns |  17.56 ns |  2,097.9 ns |  2.73x slower |   0.07x |  3.0670 |       - |    6424 B |          NA |

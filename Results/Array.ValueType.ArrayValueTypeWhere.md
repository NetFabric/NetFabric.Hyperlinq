## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|                   Method |    Job |  Runtime | Count |       Mean |     Error |   StdDev |     Median |         Ratio | RatioSD |    Gen0 |    Gen1 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|----------:|---------:|-----------:|--------------:|--------:|--------:|--------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |   450.7 ns |   7.90 ns |  8.11 ns |   448.1 ns |      baseline |         |       - |       - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   539.5 ns |   3.46 ns |  3.07 ns |   538.3 ns |  1.19x slower |   0.02x |       - |       - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,032.7 ns |   8.67 ns |  6.77 ns | 1,031.8 ns |  2.28x slower |   0.05x |  0.0496 |       - |     104 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 1,339.0 ns |  25.71 ns | 72.08 ns | 1,304.0 ns |  2.97x slower |   0.14x |  4.7264 |       - |    9904 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 2,037.9 ns |  24.84 ns | 20.74 ns | 2,032.1 ns |  4.51x slower |   0.11x |  3.0174 |       - |    6328 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 1,125.0 ns |  17.06 ns | 15.96 ns | 1,120.4 ns |  2.49x slower |   0.06x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 7,655.7 ns |  87.55 ns | 81.90 ns | 7,657.2 ns | 16.96x slower |   0.38x | 52.0782 | 10.4065 |  134824 B |          NA |
|                 SpanLinq | .NET 6 | .NET 6.0 |   100 |   748.3 ns |  10.62 ns | 11.80 ns |   744.4 ns |  1.66x slower |   0.03x |       - |       - |         - |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,934.6 ns |  12.91 ns | 10.78 ns | 1,933.2 ns |  4.28x slower |   0.09x |  0.3929 |       - |     824 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   618.8 ns |   5.46 ns |  4.56 ns |   617.8 ns |  1.37x slower |   0.03x |  0.0153 |       - |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   541.7 ns |   2.61 ns |  2.44 ns |   541.3 ns |  1.20x slower |   0.02x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 1,416.0 ns |  27.89 ns | 36.26 ns | 1,398.8 ns |  3.16x slower |   0.06x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   849.8 ns |  16.64 ns | 19.16 ns |   841.2 ns |  1.88x slower |   0.05x |       - |       - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 2,303.9 ns |  43.54 ns | 93.74 ns | 2,252.3 ns |  5.08x slower |   0.19x |  3.0670 |       - |    6424 B |          NA |
|                          |        |          |       |            |           |          |            |               |         |         |         |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |   421.5 ns |   5.92 ns |  6.07 ns |   419.1 ns |      baseline |         |       - |       - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   483.8 ns |   1.96 ns |  1.74 ns |   483.9 ns |  1.15x slower |   0.02x |       - |       - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   631.5 ns |   3.14 ns |  2.79 ns |   631.6 ns |  1.50x slower |   0.03x |  0.0496 |       - |     104 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 | 1,191.7 ns |  23.70 ns | 35.47 ns | 1,186.3 ns |  2.87x slower |   0.10x |  4.7264 |       - |    9904 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 1,481.0 ns |  28.13 ns | 68.47 ns | 1,460.0 ns |  3.61x slower |   0.16x |  3.0193 |       - |    6328 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   626.9 ns |   5.42 ns |  4.23 ns |   626.0 ns |  1.48x slower |   0.03x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 6,864.4 ns | 108.25 ns | 84.52 ns | 6,831.9 ns | 16.25x slower |   0.28x | 62.4237 |  0.0610 |  134810 B |          NA |
|                 SpanLinq | .NET 8 | .NET 8.0 |   100 |   591.9 ns |   5.29 ns |  4.69 ns |   591.1 ns |  1.40x slower |   0.02x |       - |       - |         - |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,571.9 ns |  13.44 ns | 13.20 ns | 1,569.8 ns |  3.73x slower |   0.07x |  0.3929 |       - |     824 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   513.3 ns |   4.64 ns |  3.62 ns |   512.1 ns |  1.21x slower |   0.02x |  0.0153 |       - |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   504.3 ns |   7.97 ns |  6.65 ns |   502.0 ns |  1.19x slower |   0.02x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   567.6 ns |   4.33 ns |  3.38 ns |   566.4 ns |  1.34x slower |   0.02x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   545.7 ns |   3.55 ns |  2.97 ns |   545.4 ns |  1.29x slower |   0.02x |       - |       - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 1,464.1 ns |  28.31 ns | 33.70 ns | 1,453.0 ns |  3.48x slower |   0.11x |  3.0670 |       - |    6424 B |          NA |

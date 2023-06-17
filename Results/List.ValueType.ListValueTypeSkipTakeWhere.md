## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|                  ForLoop | .NET 6 | .NET 6.0 | 1000 |   100 |    535.0 ns |   5.78 ns |     5.12 ns |    533.1 ns |      baseline |         |       - |       - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 | 1000 |   100 |  1,923.8 ns |  11.99 ns |    10.02 ns |  1,922.3 ns |  3.60x slower |   0.04x |  0.1526 |       - |     320 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 | 1000 |   100 |  4,357.7 ns |  86.64 ns |   234.24 ns |  4,233.8 ns |  8.19x slower |   0.51x | 10.0250 |       - |   21000 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 | 1000 |   100 |  6,667.2 ns | 132.98 ns |   368.47 ns |  6,472.5 ns | 12.34x slower |   0.46x | 37.0331 |       - |   80168 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 | 1000 |   100 | 10,394.4 ns | 162.78 ns |   152.27 ns | 10,349.8 ns | 19.45x slower |   0.32x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |   100 | 15,629.3 ns | 307.58 ns |   836.80 ns | 15,358.3 ns | 29.37x slower |   1.58x | 62.4390 |  0.0305 |  134733 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 | 1000 |   100 |  9,985.4 ns | 133.67 ns |   118.50 ns |  9,945.8 ns | 18.66x slower |   0.32x |  0.5493 |       - |    1176 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 | 1000 |   100 |    888.9 ns |  13.70 ns |    13.46 ns |    884.1 ns |  1.66x slower |   0.03x |  0.0572 |       - |     120 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |    879.6 ns |   8.15 ns |     6.36 ns |    877.9 ns |  1.64x slower |   0.02x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 |  1,054.9 ns |  14.70 ns |    19.11 ns |  1,047.9 ns |  1.98x slower |   0.05x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |  1,853.0 ns |  36.23 ns |    35.59 ns |  1,837.9 ns |  3.46x slower |   0.09x |       - |       - |         - |          NA |
|                          |        |          |      |       |             |           |             |             |               |         |         |         |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 | 1000 |   100 |    463.0 ns |   4.60 ns |     3.59 ns |    462.0 ns |      baseline |         |       - |       - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 | 1000 |   100 |    977.5 ns |  18.58 ns |    24.81 ns |    966.7 ns |  2.12x slower |   0.07x |  0.1526 |       - |     320 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 | 1000 |   100 |  2,636.7 ns |  52.65 ns |   146.77 ns |  2,587.3 ns |  5.81x slower |   0.28x | 10.0250 |       - |   21000 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 | 1000 |   100 |  5,949.8 ns | 116.91 ns |   195.32 ns |  5,863.2 ns | 12.91x slower |   0.44x | 37.7350 |       - |   80168 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 | 1000 |   100 |  5,193.4 ns |  96.18 ns |   211.13 ns |  5,114.2 ns | 11.47x slower |   0.46x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 | 1000 |   100 | 21,076.9 ns | 406.19 ns | 1,084.22 ns | 21,005.5 ns | 44.73x slower |   2.80x | 58.4106 | 15.0757 |  134747 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 | 1000 |   100 |  7,113.7 ns |  62.56 ns |    52.24 ns |  7,096.4 ns | 15.35x slower |   0.18x |  0.5493 |       - |    1176 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 | 1000 |   100 |    504.1 ns |   4.49 ns |     3.75 ns |    503.2 ns |  1.09x slower |   0.01x |  0.0572 |       - |     120 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |    473.7 ns |   1.77 ns |     1.38 ns |    473.7 ns |  1.02x slower |   0.01x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 |    521.9 ns |  10.17 ns |     9.52 ns |    517.1 ns |  1.13x slower |   0.02x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |    554.2 ns |   4.65 ns |     3.63 ns |    553.2 ns |  1.20x slower |   0.01x |       - |       - |         - |          NA |

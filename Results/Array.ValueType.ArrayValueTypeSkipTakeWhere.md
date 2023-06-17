## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|                  ForLoop | .NET 6 | .NET 6.0 | 1000 |   100 |    441.3 ns |   7.72 ns |     6.85 ns |    438.8 ns |      baseline |         |       - |       - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 | 1000 |   100 |  2,041.6 ns |  11.91 ns |    11.14 ns |  2,039.9 ns |  4.63x slower |   0.08x |  0.1526 |       - |     320 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 | 1000 |   100 |  2,059.7 ns |  24.67 ns |    23.08 ns |  2,061.3 ns |  4.67x slower |   0.10x | 10.7803 |       - |   22560 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 | 1000 |   100 |  1,754.9 ns |  34.39 ns |    33.78 ns |  1,747.4 ns |  3.99x slower |   0.10x |  4.6501 |       - |    9744 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 | 1000 |   100 |  7,072.2 ns | 139.72 ns |   312.51 ns |  7,029.3 ns | 15.43x slower |   0.73x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |   100 |  9,399.0 ns | 181.37 ns |   208.86 ns |  9,295.9 ns | 21.30x slower |   0.30x | 50.0031 | 12.4969 |  134631 B |          NA |
|                 SpanLinq | .NET 6 | .NET 6.0 | 1000 |   100 |    711.9 ns |   5.74 ns |     6.37 ns |    709.9 ns |  1.61x slower |   0.03x |       - |       - |         - |          NA |
|                  Streams | .NET 6 | .NET 6.0 | 1000 |   100 |  8,649.6 ns | 154.56 ns |   120.67 ns |  8,594.1 ns | 19.57x slower |   0.46x |  0.5493 |       - |    1152 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 | 1000 |   100 |    628.4 ns |   2.10 ns |     1.75 ns |    628.0 ns |  1.42x slower |   0.02x |  0.0458 |       - |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |    516.9 ns |   2.47 ns |     2.19 ns |    517.0 ns |  1.17x slower |   0.02x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 |  1,052.0 ns |  20.64 ns |    45.30 ns |  1,030.9 ns |  2.40x slower |   0.13x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |    815.7 ns |   5.76 ns |     4.81 ns |    815.8 ns |  1.85x slower |   0.03x |       - |       - |         - |          NA |
|                          |        |          |      |       |             |           |             |             |               |         |         |         |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 | 1000 |   100 |    410.8 ns |   2.11 ns |     1.65 ns |    410.2 ns |      baseline |         |       - |       - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 | 1000 |   100 |  1,185.7 ns |  16.65 ns |    20.45 ns |  1,181.9 ns |  2.90x slower |   0.07x |  0.1526 |       - |     320 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 | 1000 |   100 |  2,028.8 ns |  27.12 ns |    22.64 ns |  2,030.4 ns |  4.94x slower |   0.06x | 10.7803 |       - |   22560 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 | 1000 |   100 |  1,375.8 ns |  26.89 ns |    68.44 ns |  1,343.4 ns |  3.49x slower |   0.21x |  4.6501 |       - |    9744 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 | 1000 |   100 |  2,977.2 ns |  23.56 ns |    20.88 ns |  2,976.3 ns |  7.24x slower |   0.05x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 | 1000 |   100 | 12,651.1 ns | 573.18 ns | 1,559.39 ns | 13,325.9 ns | 31.76x slower |   3.31x | 50.9033 | 16.1743 |  134652 B |          NA |
|                 SpanLinq | .NET 8 | .NET 8.0 | 1000 |   100 |    549.0 ns |   2.75 ns |     2.30 ns |    548.6 ns |  1.34x slower |   0.01x |       - |       - |         - |          NA |
|                  Streams | .NET 8 | .NET 8.0 | 1000 |   100 |  6,928.6 ns |  62.23 ns |    58.21 ns |  6,904.6 ns | 16.90x slower |   0.14x |  0.5493 |       - |    1152 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 | 1000 |   100 |    511.4 ns |   1.99 ns |     1.66 ns |    511.0 ns |  1.25x slower |   0.00x |  0.0458 |       - |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |    484.9 ns |   6.54 ns |     5.79 ns |    482.6 ns |  1.18x slower |   0.01x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 |    522.0 ns |   6.43 ns |     5.02 ns |    520.4 ns |  1.27x slower |   0.01x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |    537.3 ns |   3.08 ns |     2.40 ns |    537.5 ns |  1.31x slower |   0.01x |       - |       - |         - |          NA |

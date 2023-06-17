## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                   Method |    Job |  Runtime | Count |       Mean |    Error |    StdDev |     Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|---------:|----------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   753.4 ns | 14.23 ns |  22.98 ns |   745.2 ns |     baseline |         | 0.7877 |    1648 B |             |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,129.7 ns | 16.29 ns |  13.60 ns | 1,127.5 ns | 1.50x slower |   0.05x | 0.6256 |    1312 B |  1.26x less |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 1,418.7 ns | 10.77 ns |  11.97 ns | 1,417.2 ns | 1.89x slower |   0.06x | 0.7725 |    1616 B |  1.02x less |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,546.8 ns | 30.92 ns |  36.81 ns | 1,536.9 ns | 2.06x slower |   0.07x | 4.2362 |    8874 B |  5.38x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,720.8 ns | 39.15 ns | 111.06 ns | 1,664.5 ns | 2.28x slower |   0.11x | 1.0319 |    2160 B |  1.31x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 1,158.3 ns | 21.19 ns |  17.69 ns | 1,154.4 ns | 1.54x slower |   0.06x | 0.2632 |     552 B |  2.99x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   817.1 ns | 12.00 ns |  10.64 ns |   813.0 ns | 1.09x slower |   0.04x | 0.2213 |     464 B |  3.55x less |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 1,126.1 ns | 22.16 ns |  35.15 ns | 1,111.6 ns | 1.50x slower |   0.07x | 0.2213 |     464 B |  3.55x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   889.8 ns | 23.91 ns |  70.51 ns |   848.6 ns | 1.17x slower |   0.08x | 0.2213 |     464 B |  3.55x less |
|                          |        |          |       |            |          |           |            |              |         |        |           |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   403.6 ns | 10.00 ns |  28.86 ns |   389.8 ns |     baseline |         | 0.7877 |    1648 B |             |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   548.8 ns | 10.95 ns |  24.94 ns |   537.6 ns | 1.36x slower |   0.11x | 0.6266 |    1312 B |  1.26x less |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   622.6 ns | 11.93 ns |   9.32 ns |   617.3 ns | 1.55x slower |   0.11x | 0.7725 |    1616 B |  1.02x less |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,431.1 ns | 43.97 ns | 126.17 ns | 1,372.2 ns | 3.57x slower |   0.44x | 4.2362 |    8873 B |  5.38x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,397.2 ns | 26.88 ns |  20.98 ns | 1,394.7 ns | 3.48x slower |   0.23x | 1.0319 |    2160 B |  1.31x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   586.6 ns | 11.45 ns |  29.96 ns |   572.2 ns | 1.46x slower |   0.13x | 0.2632 |     552 B |  2.99x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   557.8 ns | 11.22 ns |  19.36 ns |   548.5 ns | 1.39x slower |   0.12x | 0.2213 |     464 B |  3.55x less |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   640.0 ns | 10.22 ns |   8.54 ns |   635.7 ns | 1.60x slower |   0.09x | 0.2213 |     464 B |  3.55x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   569.6 ns |  4.51 ns |   3.77 ns |   568.8 ns | 1.43x slower |   0.09x | 0.2213 |     464 B |  3.55x less |

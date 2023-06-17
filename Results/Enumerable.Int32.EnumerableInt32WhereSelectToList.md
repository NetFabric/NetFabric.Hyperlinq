## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|                   Method |    Job |  Runtime | Count |       Mean |    Error |   StdDev |     Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|---------:|---------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   700.7 ns | 12.74 ns | 26.03 ns |   689.0 ns |     baseline |         | 0.5846 |    1224 B |             |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,050.0 ns |  9.43 ns |  7.87 ns | 1,052.1 ns | 1.47x slower |   0.07x | 0.6409 |    1344 B |  1.10x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 1,413.9 ns | 25.90 ns | 29.82 ns | 1,401.1 ns | 2.01x slower |   0.08x | 0.5836 |    1224 B |  1.00x more |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,569.4 ns | 20.25 ns | 15.81 ns | 1,565.4 ns | 2.19x slower |   0.11x | 4.4537 |    9330 B |  7.62x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 2,085.8 ns | 32.13 ns | 35.72 ns | 2,076.2 ns | 2.96x slower |   0.10x | 0.8430 |    1768 B |  1.44x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 1,170.9 ns | 13.11 ns | 10.94 ns | 1,166.0 ns | 1.64x slower |   0.08x | 0.2785 |     584 B |  2.10x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   877.0 ns | 21.22 ns | 61.22 ns |   845.0 ns | 1.25x slower |   0.07x | 0.2365 |     496 B |  2.47x less |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 1,146.1 ns |  7.72 ns |  6.84 ns | 1,144.3 ns | 1.61x slower |   0.07x | 0.2365 |     496 B |  2.47x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   872.7 ns | 19.55 ns | 55.14 ns |   842.2 ns | 1.26x slower |   0.09x | 0.2365 |     496 B |  2.47x less |
|                          |        |          |       |            |          |          |            |              |         |        |           |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   388.0 ns | 14.05 ns | 40.33 ns |   363.8 ns |     baseline |         | 0.5851 |    1224 B |             |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   623.8 ns | 11.96 ns | 12.80 ns |   617.4 ns | 1.65x slower |   0.13x | 0.6418 |    1344 B |  1.10x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   586.7 ns | 11.56 ns | 15.43 ns |   577.9 ns | 1.58x slower |   0.11x | 0.5846 |    1224 B |  1.00x more |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,399.2 ns | 21.94 ns | 28.53 ns | 1,394.5 ns | 3.76x slower |   0.25x | 4.4537 |    9329 B |  7.62x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,687.1 ns | 19.68 ns | 15.36 ns | 1,688.2 ns | 4.42x slower |   0.36x | 0.8430 |    1768 B |  1.44x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   610.7 ns |  4.01 ns |  3.13 ns |   610.7 ns | 1.60x slower |   0.14x | 0.2785 |     584 B |  2.10x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   547.2 ns |  6.40 ns |  5.99 ns |   544.6 ns | 1.44x slower |   0.11x | 0.2365 |     496 B |  2.47x less |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   651.7 ns |  4.58 ns |  3.58 ns |   651.1 ns | 1.71x slower |   0.14x | 0.2365 |     496 B |  2.47x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   578.1 ns | 11.31 ns | 14.31 ns |   572.6 ns | 1.55x slower |   0.09x | 0.2365 |     496 B |  2.47x less |

## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                   Method |    Job |  Runtime | Count |       Mean |     Error |    StdDev |     Median |        Ratio | RatioSD |    Gen0 |    Gen1 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|----------:|----------:|-----------:|-------------:|--------:|--------:|--------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 | 1,542.3 ns |  28.92 ns |  22.58 ns | 1,542.8 ns |     baseline |         |  5.5237 |       - |   11.3 KB |             |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 1,658.0 ns |  39.68 ns | 114.49 ns | 1,605.6 ns | 1.12x slower |   0.10x |  5.5237 |       - |   11.3 KB |  1.00x more |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,735.9 ns |  37.97 ns | 107.09 ns | 1,687.9 ns | 1.14x slower |   0.07x |  4.0035 |       - |   8.19 KB |  1.38x less |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 1,922.2 ns |  57.33 ns | 169.03 ns | 1,833.0 ns | 1.28x slower |   0.14x |  5.5237 |       - |   11.3 KB |  1.00x more |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 1,905.5 ns |  44.85 ns | 129.39 ns | 1,843.2 ns | 1.22x slower |   0.10x |  6.3953 |       - |  13.07 KB |  1.16x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 3,270.3 ns |  80.59 ns | 232.51 ns | 3,161.3 ns | 2.13x slower |   0.15x |  5.5084 |       - |  11.27 KB |  1.00x less |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 8,042.9 ns | 150.81 ns | 117.74 ns | 8,014.4 ns | 5.22x slower |   0.12x | 52.0782 | 10.4065 | 131.73 KB | 11.66x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 7,644.2 ns | 241.00 ns | 710.60 ns | 7,259.1 ns | 5.07x slower |   0.58x |  5.7678 |       - |   11.8 KB |  1.04x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 1,414.0 ns |  27.38 ns |  22.86 ns | 1,413.1 ns | 1.09x faster |   0.03x |  1.7090 |       - |    3.5 KB |  3.23x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1,086.4 ns |  21.77 ns |  52.59 ns | 1,069.3 ns | 1.37x faster |   0.10x |  1.6575 |       - |    3.4 KB |  3.32x less |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 1,716.6 ns |  33.02 ns |  92.06 ns | 1,677.6 ns | 1.12x slower |   0.07x |  1.6575 |       - |    3.4 KB |  3.32x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1,352.9 ns |  26.97 ns |  75.63 ns | 1,312.0 ns | 1.16x faster |   0.05x |  1.6575 |       - |    3.4 KB |  3.32x less |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 1,827.5 ns |  39.31 ns | 110.22 ns | 1,772.5 ns | 1.23x slower |   0.09x |  5.5237 |       - |   11.3 KB |  1.00x more |
|                          |        |          |       |            |           |           |            |              |         |         |         |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 | 1,342.9 ns |  26.75 ns |  67.61 ns | 1,317.8 ns |     baseline |         |  5.5237 |       - |   11.3 KB |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 | 1,488.9 ns |  35.11 ns | 100.18 ns | 1,443.5 ns | 1.11x slower |   0.10x |  5.5237 |       - |   11.3 KB |  1.00x more |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 1,243.4 ns |  21.49 ns |  40.37 ns | 1,232.2 ns | 1.09x faster |   0.07x |  4.0035 |       - |   8.19 KB |  1.38x less |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 | 1,398.6 ns |  11.60 ns |  12.89 ns | 1,395.9 ns | 1.04x slower |   0.04x |  5.5237 |       - |   11.3 KB |  1.00x more |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 1,592.2 ns |  23.94 ns |  25.62 ns | 1,584.9 ns | 1.18x slower |   0.05x |  6.3953 |       - |  13.07 KB |  1.16x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 1,900.4 ns |  15.72 ns |  13.93 ns | 1,896.3 ns | 1.41x slower |   0.06x |  5.5084 |       - |  11.27 KB |  1.00x less |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 8,236.2 ns | 153.60 ns | 136.16 ns | 8,192.4 ns | 6.09x slower |   0.25x | 52.0782 | 10.4065 | 131.71 KB | 11.66x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 6,757.2 ns |  40.90 ns |  36.25 ns | 6,744.4 ns | 5.00x slower |   0.20x |  5.7678 |       - |   11.8 KB |  1.04x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 1,097.6 ns |   9.74 ns |   8.14 ns | 1,097.4 ns | 1.24x faster |   0.05x |  1.7109 |       - |    3.5 KB |  3.23x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   950.3 ns |   7.13 ns |   5.57 ns |   949.7 ns | 1.43x faster |   0.06x |  1.6575 |       - |    3.4 KB |  3.32x less |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   991.7 ns |  19.79 ns |  16.52 ns |   987.2 ns | 1.37x faster |   0.07x |  1.6575 |       - |    3.4 KB |  3.32x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 1,010.7 ns |   5.59 ns |   4.37 ns | 1,009.4 ns | 1.35x faster |   0.06x |  1.6575 |       - |    3.4 KB |  3.32x less |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 1,420.0 ns |  27.97 ns |  21.84 ns | 1,417.7 ns | 1.05x slower |   0.04x |  5.5237 |       - |   11.3 KB |  1.00x more |

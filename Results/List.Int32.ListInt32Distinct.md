## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|                   Method |    Job |  Runtime | Duplicates | Count |       Mean |     Error |    StdDev |     Median |        Ratio | RatioSD |   Gen0 | Allocated |   Alloc Ratio |
|------------------------- |------- |--------- |----------- |------ |-----------:|----------:|----------:|-----------:|-------------:|--------:|-------:|----------:|--------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |          4 |   100 | 3,115.4 ns |  48.00 ns |  55.28 ns | 3,096.9 ns |     baseline |         | 2.8610 |    6000 B |               |
|              ForeachLoop | .NET 6 | .NET 6.0 |          4 |   100 | 3,079.0 ns |  30.75 ns |  30.20 ns | 3,071.2 ns | 1.01x faster |   0.02x | 2.8648 |    6000 B |   1.000x more |
|                     Linq | .NET 6 | .NET 6.0 |          4 |   100 | 5,454.2 ns |  68.91 ns |  53.80 ns | 5,441.8 ns | 1.75x slower |   0.03x | 2.8610 |    6000 B |   1.000x more |
|               LinqFaster | .NET 6 | .NET 6.0 |          4 |   100 |   763.7 ns |  17.25 ns |  49.49 ns |   736.7 ns | 4.08x faster |   0.26x |      - |         - |            NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |          4 |   100 | 4,759.3 ns |  91.57 ns | 101.78 ns | 4,723.8 ns | 1.53x slower |   0.04x | 5.2032 |   10896 B |   1.816x more |
|                   LinqAF | .NET 6 | .NET 6.0 |          4 |   100 | 8,060.5 ns |  51.10 ns |  45.30 ns | 8,061.0 ns | 2.58x slower |   0.06x | 5.9204 |   12400 B |   2.067x more |
|               StructLinq | .NET 6 | .NET 6.0 |          4 |   100 | 3,447.9 ns |  38.70 ns |  34.31 ns | 3,439.8 ns | 1.10x slower |   0.02x | 0.0153 |      32 B | 187.500x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |          4 |   100 | 3,406.7 ns |  44.19 ns |  43.40 ns | 3,397.5 ns | 1.09x slower |   0.02x |      - |         - |            NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |          4 |   100 | 3,417.7 ns |  67.60 ns |  52.78 ns | 3,401.6 ns | 1.09x slower |   0.03x |      - |         - |            NA |
|                          |        |          |            |       |            |           |           |            |              |         |        |           |               |
|                  ForLoop | .NET 8 | .NET 8.0 |          4 |   100 | 3,388.5 ns |  83.85 ns | 240.59 ns | 3,263.0 ns |     baseline |         | 2.8648 |    6000 B |               |
|              ForeachLoop | .NET 8 | .NET 8.0 |          4 |   100 | 3,199.4 ns |  62.84 ns |  74.80 ns | 3,166.1 ns | 1.07x faster |   0.09x | 2.8648 |    6000 B |   1.000x more |
|                     Linq | .NET 8 | .NET 8.0 |          4 |   100 | 3,869.4 ns |  66.33 ns |  58.80 ns | 3,847.3 ns | 1.15x slower |   0.08x | 2.8610 |    6000 B |   1.000x more |
|               LinqFaster | .NET 8 | .NET 8.0 |          4 |   100 |   545.0 ns |   4.28 ns |   3.79 ns |   545.1 ns | 6.22x faster |   0.42x |      - |         - |            NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |          4 |   100 | 3,874.2 ns |  44.90 ns |  37.49 ns | 3,857.4 ns | 1.14x slower |   0.07x | 5.2032 |   10896 B |   1.816x more |
|                   LinqAF | .NET 8 | .NET 8.0 |          4 |   100 | 6,266.5 ns | 102.76 ns | 118.34 ns | 6,221.5 ns | 1.84x slower |   0.14x | 5.9280 |   12400 B |   2.067x more |
|               StructLinq | .NET 8 | .NET 8.0 |          4 |   100 | 2,577.9 ns |  21.75 ns |  19.28 ns | 2,574.2 ns | 1.31x faster |   0.09x | 0.0153 |      32 B | 187.500x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |          4 |   100 | 2,696.6 ns |  52.94 ns | 109.32 ns | 2,629.0 ns | 1.27x faster |   0.11x |      - |         - |            NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |          4 |   100 | 2,669.2 ns |  53.26 ns | 139.38 ns | 2,601.2 ns | 1.28x faster |   0.11x |      - |         - |            NA |

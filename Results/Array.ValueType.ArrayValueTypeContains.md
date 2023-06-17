## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|                   Method |    Job |  Runtime | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 | 437.93 ns | 2.873 ns |  2.688 ns | 438.47 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 448.51 ns | 5.384 ns |  5.529 ns | 446.44 ns | 1.03x slower |   0.01x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 220.74 ns | 1.566 ns |  1.307 ns | 220.45 ns | 1.98x faster |   0.02x |      - |         - |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 229.34 ns | 4.626 ns | 11.084 ns | 223.55 ns | 1.90x faster |   0.10x |      - |         - |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 227.99 ns | 4.580 ns | 11.321 ns | 222.40 ns | 1.92x faster |   0.09x |      - |         - |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 224.79 ns | 4.094 ns |  4.714 ns | 222.88 ns | 1.94x faster |   0.04x |      - |         - |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 435.16 ns | 4.857 ns |  4.544 ns | 433.49 ns | 1.01x faster |   0.01x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 376.43 ns | 7.320 ns |  8.990 ns | 373.17 ns | 1.16x faster |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 208.27 ns | 2.847 ns |  2.377 ns | 207.62 ns | 2.10x faster |   0.03x | 0.0153 |      32 B |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 490.22 ns | 8.626 ns |  7.203 ns | 487.84 ns | 1.12x slower |   0.02x | 0.0305 |      64 B |          NA |
|                          |        |          |       |           |          |           |           |              |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 | 189.47 ns | 2.446 ns |  2.288 ns | 188.62 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 | 198.25 ns | 3.900 ns |  7.326 ns | 195.24 ns | 1.04x slower |   0.04x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |  53.52 ns | 0.242 ns |  0.215 ns |  53.46 ns | 3.54x faster |   0.05x |      - |         - |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |  50.68 ns | 0.516 ns |  0.431 ns |  50.45 ns | 3.74x faster |   0.06x |      - |         - |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |  52.90 ns | 1.089 ns |  1.417 ns |  52.34 ns | 3.61x faster |   0.10x |      - |         - |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |  57.26 ns | 1.099 ns |  2.953 ns |  55.61 ns | 3.27x faster |   0.20x |      - |         - |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 297.53 ns | 1.728 ns |  1.443 ns | 297.19 ns | 1.57x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 236.60 ns | 1.331 ns |  1.245 ns | 236.34 ns | 1.25x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |  61.13 ns | 0.484 ns |  0.429 ns |  61.03 ns | 3.10x faster |   0.05x | 0.0153 |      32 B |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 286.55 ns | 4.973 ns |  4.152 ns | 285.83 ns | 1.51x slower |   0.03x | 0.0305 |      64 B |          NA |

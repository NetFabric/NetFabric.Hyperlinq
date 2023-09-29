## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3516/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-rc.1.23463.5
  [Host]     : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-VLSRZF : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-CRYVOQ : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2


```
|                   Method |  Runtime | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 | 578.42 ns |  5.453 ns |  4.554 ns | 576.75 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 | 691.06 ns | 13.733 ns | 24.764 ns | 679.97 ns | 1.20x slower |   0.04x |      - |         - |          NA |
|              List_Exists | .NET 6.0 |   100 | 583.74 ns |  3.586 ns |  2.994 ns | 582.25 ns | 1.01x slower |   0.01x | 0.0305 |      64 B |          NA |
|                     Linq | .NET 6.0 |   100 | 195.75 ns |  1.401 ns |  1.242 ns | 195.20 ns | 2.95x faster |   0.03x |      - |         - |          NA |
|               LinqFaster | .NET 6.0 |   100 | 194.21 ns |  2.136 ns |  1.784 ns | 193.83 ns | 2.98x faster |   0.04x |      - |         - |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 572.23 ns |  9.244 ns | 11.691 ns | 572.02 ns | 1.02x faster |   0.02x | 3.0670 |    6424 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 195.64 ns |  2.182 ns |  1.935 ns | 195.52 ns | 2.96x faster |   0.03x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 402.88 ns |  2.383 ns |  1.990 ns | 402.46 ns | 1.44x faster |   0.01x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 431.16 ns |  8.608 ns | 16.585 ns | 423.20 ns | 1.32x faster |   0.07x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 206.87 ns |  2.526 ns |  2.109 ns | 206.16 ns | 2.80x faster |   0.03x | 0.0153 |      32 B |          NA |
|                  Faslinq | .NET 6.0 |   100 | 560.96 ns | 10.732 ns |  8.962 ns | 558.62 ns | 1.03x faster |   0.02x | 0.0305 |      64 B |          NA |
|                          |          |       |           |           |           |           |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 | 240.33 ns |  4.788 ns |  3.999 ns | 239.62 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 | 353.53 ns |  2.413 ns |  2.015 ns | 352.77 ns | 1.47x slower |   0.02x |      - |         - |          NA |
|              List_Exists | .NET 8.0 |   100 | 418.93 ns |  4.958 ns |  4.870 ns | 417.45 ns | 1.75x slower |   0.04x | 0.0305 |      64 B |          NA |
|                     Linq | .NET 8.0 |   100 |  50.62 ns |  0.202 ns |  0.198 ns |  50.60 ns | 4.75x faster |   0.08x |      - |         - |          NA |
|               LinqFaster | .NET 8.0 |   100 |  52.31 ns |  0.768 ns |  0.754 ns |  51.99 ns | 4.59x faster |   0.11x |      - |         - |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 444.31 ns |  4.072 ns |  3.401 ns | 442.72 ns | 1.85x slower |   0.03x | 3.0670 |    6424 B |          NA |
|                   LinqAF | .NET 8.0 |   100 |  51.22 ns |  0.818 ns |  0.639 ns |  50.93 ns | 4.69x faster |   0.11x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 | 279.52 ns |  5.592 ns |  5.492 ns | 277.47 ns | 1.17x slower |   0.03x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 | 257.60 ns |  7.301 ns | 19.234 ns | 267.84 ns | 1.01x faster |   0.07x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |  61.25 ns |  1.027 ns |  0.802 ns |  61.01 ns | 3.93x faster |   0.09x | 0.0153 |      32 B |          NA |
|                  Faslinq | .NET 8.0 |   100 | 337.70 ns |  4.301 ns |  3.591 ns | 336.48 ns | 1.41x slower |   0.02x | 0.0305 |      64 B |          NA |

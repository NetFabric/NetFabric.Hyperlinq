## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                   Method |  Runtime | Skip | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 | 1000 |   100 |    59.58 ns |  0.462 ns |  0.386 ns |    59.46 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 6.0 | 1000 |   100 | 1,015.63 ns |  9.788 ns |  7.642 ns | 1,015.47 ns | 17.05x slower |   0.20x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 6.0 | 1000 |   100 |   382.87 ns |  5.221 ns |  4.076 ns |   382.82 ns |  6.43x slower |   0.09x | 0.6080 |    1272 B |          NA |
|             LinqFasterer | .NET 6.0 | 1000 |   100 |   756.65 ns | 19.308 ns | 56.323 ns |   727.35 ns | 12.82x slower |   1.02x | 0.4206 |     880 B |          NA |
|                   LinqAF | .NET 6.0 | 1000 |   100 | 2,539.60 ns | 46.525 ns | 88.518 ns | 2,494.15 ns | 43.29x slower |   1.83x |      - |         - |          NA |
|                 SpanLinq | .NET 6.0 | 1000 |   100 |   256.15 ns |  1.695 ns |  1.586 ns |   255.65 ns |  4.30x slower |   0.03x |      - |         - |          NA |
|               StructLinq | .NET 6.0 | 1000 |   100 |   247.45 ns |  4.668 ns |  4.138 ns |   245.77 ns |  4.14x slower |   0.07x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   162.66 ns |  0.526 ns |  0.411 ns |   162.63 ns |  2.73x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 | 1000 |   100 |   247.46 ns |  1.542 ns |  1.367 ns |   246.98 ns |  4.15x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   200.24 ns |  3.167 ns |  2.645 ns |   199.27 ns |  3.36x slower |   0.05x |      - |         - |          NA |
|                          |          |      |       |             |           |           |             |               |         |        |           |             |
|                  ForLoop | .NET 8.0 | 1000 |   100 |    57.26 ns |  0.388 ns |  0.303 ns |    57.29 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 8.0 | 1000 |   100 |   599.52 ns | 10.298 ns |  8.040 ns |   598.39 ns | 10.47x slower |   0.16x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 8.0 | 1000 |   100 |   248.17 ns |  4.980 ns | 12.216 ns |   244.37 ns |  4.41x slower |   0.20x | 0.6080 |    1272 B |          NA |
|             LinqFasterer | .NET 8.0 | 1000 |   100 |   448.43 ns |  8.446 ns | 13.396 ns |   448.24 ns |  7.67x slower |   0.27x | 0.4206 |     880 B |          NA |
|                   LinqAF | .NET 8.0 | 1000 |   100 |   920.22 ns |  9.781 ns |  8.168 ns |   918.44 ns | 16.08x slower |   0.20x |      - |         - |          NA |
|                 SpanLinq | .NET 8.0 | 1000 |   100 |   137.81 ns |  2.628 ns |  2.699 ns |   136.66 ns |  2.41x slower |   0.05x |      - |         - |          NA |
|               StructLinq | .NET 8.0 | 1000 |   100 |   115.89 ns |  2.333 ns |  2.069 ns |   115.47 ns |  2.02x slower |   0.04x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    60.91 ns |  0.406 ns |  0.360 ns |    60.90 ns |  1.06x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 | 1000 |   100 |   137.29 ns |  0.492 ns |  0.436 ns |   137.28 ns |  2.40x slower |   0.01x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    50.29 ns |  0.122 ns |  0.102 ns |    50.29 ns |  1.14x faster |   0.01x |      - |         - |          NA |

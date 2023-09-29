## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|                  ForLoop | .NET 6.0 | 1000 |   100 |    93.97 ns |  1.393 ns |  2.128 ns |    92.96 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 6.0 | 1000 |   100 | 1,585.56 ns | 24.061 ns | 20.092 ns | 1,579.24 ns | 16.77x slower |   0.38x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 6.0 | 1000 |   100 |   351.84 ns |  6.166 ns | 11.880 ns |   349.19 ns |  3.75x slower |   0.16x | 0.7191 |    1504 B |          NA |
|             LinqFasterer | .NET 6.0 | 1000 |   100 |   584.19 ns |  4.277 ns |  3.791 ns |   582.51 ns |  6.19x slower |   0.18x | 0.3281 |     688 B |          NA |
|                   LinqAF | .NET 6.0 | 1000 |   100 | 2,831.29 ns | 32.180 ns | 25.124 ns | 2,821.90 ns | 29.91x slower |   0.81x |      - |         - |          NA |
|                 SpanLinq | .NET 6.0 | 1000 |   100 |   306.40 ns |  5.425 ns |  4.235 ns |   306.20 ns |  3.24x slower |   0.08x |      - |         - |          NA |
|               StructLinq | .NET 6.0 | 1000 |   100 |   281.60 ns |  5.650 ns | 13.317 ns |   279.33 ns |  2.99x slower |   0.18x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   163.26 ns |  3.154 ns |  2.634 ns |   162.75 ns |  1.73x slower |   0.06x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 | 1000 |   100 |   465.41 ns |  7.212 ns |  5.630 ns |   465.56 ns |  4.92x slower |   0.13x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   218.71 ns |  2.481 ns |  2.200 ns |   217.73 ns |  2.32x slower |   0.06x |      - |         - |          NA |
|                          |          |      |       |             |           |           |             |               |         |        |           |             |
|                  ForLoop | .NET 8.0 | 1000 |   100 |    93.83 ns |  1.801 ns |  2.696 ns |    92.62 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 8.0 | 1000 |   100 |   806.65 ns | 12.421 ns |  9.698 ns |   804.22 ns |  8.53x slower |   0.32x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 8.0 | 1000 |   100 |   215.54 ns |  4.314 ns | 11.365 ns |   210.90 ns |  2.30x slower |   0.13x | 0.7191 |    1504 B |          NA |
|             LinqFasterer | .NET 8.0 | 1000 |   100 |   235.10 ns |  2.951 ns |  2.304 ns |   235.31 ns |  2.49x slower |   0.09x | 0.3285 |     688 B |          NA |
|                   LinqAF | .NET 8.0 | 1000 |   100 |   948.47 ns |  6.182 ns |  5.480 ns |   947.78 ns | 10.07x slower |   0.32x |      - |         - |          NA |
|                 SpanLinq | .NET 8.0 | 1000 |   100 |   186.37 ns |  2.964 ns |  2.475 ns |   185.38 ns |  1.98x slower |   0.08x |      - |         - |          NA |
|               StructLinq | .NET 8.0 | 1000 |   100 |   136.16 ns |  2.745 ns |  4.587 ns |   134.71 ns |  1.45x slower |   0.06x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    83.93 ns |  1.284 ns |  1.072 ns |    83.55 ns |  1.13x faster |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 | 1000 |   100 |   159.01 ns |  0.539 ns |  0.478 ns |   158.94 ns |  1.69x slower |   0.05x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    75.53 ns |  1.503 ns |  1.333 ns |    75.18 ns |  1.25x faster |   0.04x |      - |         - |          NA |

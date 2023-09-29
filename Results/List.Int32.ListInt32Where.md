## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|                  ForLoop | .NET 6.0 |   100 | 128.57 ns |  0.668 ns |  0.592 ns | 128.42 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 | 181.30 ns |  2.798 ns |  2.184 ns | 180.36 ns | 1.41x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 573.86 ns | 10.858 ns |  8.477 ns | 571.22 ns | 4.46x slower |   0.07x | 0.0343 |      72 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 445.65 ns |  5.131 ns |  4.006 ns | 444.21 ns | 3.47x slower |   0.02x | 0.3095 |     648 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 528.39 ns |  9.044 ns | 11.107 ns | 523.88 ns | 4.14x slower |   0.10x | 0.3328 |     696 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 885.84 ns | 17.404 ns | 29.078 ns | 878.96 ns | 6.99x slower |   0.23x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 294.93 ns |  4.718 ns |  5.617 ns | 295.59 ns | 2.30x slower |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 168.50 ns |  1.375 ns |  1.148 ns | 167.99 ns | 1.31x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 489.66 ns |  9.666 ns | 17.676 ns | 480.23 ns | 3.83x slower |   0.15x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 203.12 ns |  2.393 ns |  1.868 ns | 202.19 ns | 1.58x slower |   0.01x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 442.21 ns |  8.249 ns | 10.131 ns | 438.80 ns | 3.46x slower |   0.09x | 0.3095 |     648 B |          NA |
|                          |          |       |           |           |           |           |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  84.14 ns |  1.021 ns |  0.852 ns |  83.67 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 | 113.93 ns |  0.847 ns |  0.708 ns | 113.71 ns | 1.35x slower |   0.01x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 | 256.13 ns |  1.427 ns |  1.114 ns | 255.96 ns | 3.05x slower |   0.04x | 0.0343 |      72 B |          NA |
|               LinqFaster | .NET 8.0 |   100 | 316.68 ns |  6.082 ns |  7.909 ns | 314.68 ns | 3.74x slower |   0.10x | 0.3095 |     648 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 279.40 ns |  4.973 ns |  4.409 ns | 279.77 ns | 3.33x slower |   0.07x | 0.3328 |     696 B |          NA |
|                   LinqAF | .NET 8.0 |   100 | 146.99 ns |  1.166 ns |  1.034 ns | 146.66 ns | 1.75x slower |   0.02x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 | 138.81 ns |  1.232 ns |  0.962 ns | 138.59 ns | 1.65x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  66.32 ns |  1.311 ns |  1.658 ns |  65.58 ns | 1.27x faster |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 | 106.57 ns |  1.830 ns |  2.034 ns | 105.75 ns | 1.27x slower |   0.02x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |  81.19 ns |  0.659 ns |  0.515 ns |  81.09 ns | 1.04x faster |   0.01x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 | 391.39 ns |  7.324 ns | 16.680 ns | 383.08 ns | 4.67x slower |   0.19x | 0.3095 |     648 B |          NA |

## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|                   Method |  Runtime | Count |        Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |------------:|----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |   129.32 ns |  2.573 ns |  2.407 ns | 128.68 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |   124.28 ns |  2.412 ns |  2.681 ns | 123.44 ns | 1.04x faster |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 |   833.32 ns | 10.814 ns |  9.030 ns | 831.43 ns | 6.43x slower |   0.17x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 6.0 |   100 |   497.84 ns |  9.702 ns | 10.381 ns | 494.56 ns | 3.86x slower |   0.11x | 0.3090 |     648 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 |   706.49 ns | 13.979 ns | 21.347 ns | 698.90 ns | 5.42x slower |   0.17x | 0.4473 |     936 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 1,000.10 ns |  4.016 ns |  3.354 ns | 999.26 ns | 7.72x slower |   0.15x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 |   332.28 ns |  3.516 ns |  3.117 ns | 331.41 ns | 2.57x slower |   0.05x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |   182.92 ns |  3.001 ns |  3.572 ns | 181.03 ns | 1.42x slower |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 |   332.27 ns |  1.366 ns |  1.678 ns | 332.20 ns | 2.57x slower |   0.05x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 |   211.52 ns |  3.979 ns |  3.722 ns | 210.10 ns | 1.64x slower |   0.05x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 |   537.38 ns | 10.744 ns | 19.374 ns | 528.64 ns | 4.20x slower |   0.11x | 0.3090 |     648 B |          NA |
|                          |          |       |             |           |           |           |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   115.69 ns |  1.118 ns |  0.933 ns | 115.36 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |    78.45 ns |  0.480 ns |  0.401 ns |  78.43 ns | 1.47x faster |   0.01x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 |   294.84 ns |  4.899 ns |  3.825 ns | 293.33 ns | 2.55x slower |   0.04x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 8.0 |   100 |   321.85 ns |  3.279 ns |  3.221 ns | 321.10 ns | 2.79x slower |   0.04x | 0.3095 |     648 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 |   326.30 ns |  4.128 ns |  3.223 ns | 325.39 ns | 2.82x slower |   0.04x | 0.4473 |     936 B |          NA |
|                   LinqAF | .NET 8.0 |   100 |   203.71 ns |  4.045 ns |  3.585 ns | 202.54 ns | 1.76x slower |   0.03x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |   193.79 ns |  2.078 ns |  1.623 ns | 193.98 ns | 1.67x slower |   0.02x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |    94.82 ns |  1.614 ns |  1.348 ns |  94.29 ns | 1.22x faster |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |   135.56 ns |  1.521 ns |  1.422 ns | 135.15 ns | 1.17x slower |   0.02x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |    85.93 ns |  1.760 ns |  2.026 ns |  85.07 ns | 1.35x faster |   0.03x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 |   370.79 ns |  6.185 ns |  5.165 ns | 369.78 ns | 3.21x slower |   0.05x | 0.3095 |     648 B |          NA |

## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|                   Method |  Runtime | Duplicates | Count |     Mean |     Error |    StdDev |   Median |        Ratio | RatioSD |   Gen0 | Allocated |   Alloc Ratio |
|------------------------- |--------- |----------- |------ |---------:|----------:|----------:|---------:|-------------:|--------:|-------:|----------:|--------------:|
|                  ForLoop | .NET 6.0 |          4 |   100 | 2.875 μs | 0.0535 μs | 0.0595 μs | 2.860 μs |     baseline |         | 2.8648 |    6000 B |               |
|              ForeachLoop | .NET 6.0 |          4 |   100 | 2.858 μs | 0.0269 μs | 0.0210 μs | 2.866 μs | 1.01x faster |   0.03x | 2.8648 |    6000 B |   1.000x more |
|                     Linq | .NET 6.0 |          4 |   100 | 4.523 μs | 0.0455 μs | 0.0380 μs | 4.525 μs | 1.56x slower |   0.04x | 2.8610 |    5992 B |   1.001x less |
|             LinqFasterer | .NET 6.0 |          4 |   100 | 4.583 μs | 0.0366 μs | 0.0305 μs | 4.585 μs | 1.59x slower |   0.04x | 4.4174 |    9272 B |   1.545x more |
|                   LinqAF | .NET 6.0 |          4 |   100 | 7.261 μs | 0.1439 μs | 0.2197 μs | 7.195 μs | 2.53x slower |   0.11x | 5.9280 |   12400 B |   2.067x more |
|               StructLinq | .NET 6.0 |          4 |   100 | 3.334 μs | 0.0529 μs | 0.0566 μs | 3.325 μs | 1.16x slower |   0.03x | 0.0153 |      32 B | 187.500x less |
| StructLinq_ValueDelegate | .NET 6.0 |          4 |   100 | 3.344 μs | 0.0617 μs | 0.0577 μs | 3.327 μs | 1.16x slower |   0.03x |      - |         - |            NA |
|                Hyperlinq | .NET 6.0 |          4 |   100 | 3.341 μs | 0.0541 μs | 0.0452 μs | 3.333 μs | 1.16x slower |   0.03x |      - |         - |            NA |
|                          |          |            |       |          |           |           |          |              |         |        |           |               |
|                  ForLoop | .NET 8.0 |          4 |   100 | 3.009 μs | 0.0602 μs | 0.1100 μs | 2.959 μs |     baseline |         | 2.8648 |    6000 B |               |
|              ForeachLoop | .NET 8.0 |          4 |   100 | 3.010 μs | 0.0595 μs | 0.0908 μs | 2.968 μs | 1.00x faster |   0.05x | 2.8648 |    6000 B |   1.000x more |
|                     Linq | .NET 8.0 |          4 |   100 | 3.678 μs | 0.0494 μs | 0.0549 μs | 3.667 μs | 1.22x slower |   0.06x | 2.8610 |    5992 B |   1.001x less |
|             LinqFasterer | .NET 8.0 |          4 |   100 | 3.642 μs | 0.0687 μs | 0.0642 μs | 3.612 μs | 1.20x slower |   0.06x | 4.4174 |    9272 B |   1.545x more |
|                   LinqAF | .NET 8.0 |          4 |   100 | 5.734 μs | 0.0731 μs | 0.0783 μs | 5.710 μs | 1.90x slower |   0.07x | 5.9280 |   12400 B |   2.067x more |
|               StructLinq | .NET 8.0 |          4 |   100 | 2.639 μs | 0.0506 μs | 0.0448 μs | 2.630 μs | 1.16x faster |   0.06x | 0.0153 |      32 B | 187.500x less |
| StructLinq_ValueDelegate | .NET 8.0 |          4 |   100 | 2.602 μs | 0.0234 μs | 0.0195 μs | 2.601 μs | 1.18x faster |   0.06x |      - |         - |            NA |
|                Hyperlinq | .NET 8.0 |          4 |   100 | 2.518 μs | 0.0384 μs | 0.0427 μs | 2.509 μs | 1.20x faster |   0.05x |      - |         - |            NA |

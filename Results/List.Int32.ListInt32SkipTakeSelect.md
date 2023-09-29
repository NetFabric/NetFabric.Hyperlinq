## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                  ForLoop | .NET 6.0 | 1000 |   100 |    70.27 ns |  0.361 ns |  0.301 ns |    70.29 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 6.0 | 1000 |   100 |   942.17 ns |  4.076 ns |  3.403 ns |   943.17 ns | 13.41x slower |   0.07x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 6.0 | 1000 |   100 |   801.42 ns | 15.919 ns | 28.297 ns |   789.30 ns | 11.49x slower |   0.44x | 0.6533 |    1368 B |          NA |
|             LinqFasterer | .NET 6.0 | 1000 |   100 |   949.81 ns | 18.537 ns | 29.934 ns |   945.29 ns | 13.35x slower |   0.59x | 2.5311 |    5304 B |          NA |
|                   LinqAF | .NET 6.0 | 1000 |   100 | 3,597.29 ns | 25.747 ns | 22.824 ns | 3,594.90 ns | 51.21x slower |   0.41x |      - |         - |          NA |
|               StructLinq | .NET 6.0 | 1000 |   100 |   261.42 ns |  2.332 ns |  2.068 ns |   260.87 ns |  3.72x slower |   0.02x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   163.86 ns |  1.753 ns |  1.369 ns |   163.47 ns |  2.33x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 | 1000 |   100 |   223.48 ns |  1.268 ns |  1.124 ns |   222.93 ns |  3.18x slower |   0.02x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   203.02 ns |  3.912 ns |  4.804 ns |   203.84 ns |  2.87x slower |   0.07x |      - |         - |          NA |
|                          |          |      |       |             |           |           |             |               |         |        |           |             |
|                  ForLoop | .NET 8.0 | 1000 |   100 |    69.46 ns |  0.403 ns |  0.358 ns |    69.32 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 8.0 | 1000 |   100 |   389.91 ns |  7.593 ns |  8.439 ns |   386.43 ns |  5.64x slower |   0.14x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 8.0 | 1000 |   100 |   739.37 ns | 13.908 ns | 11.614 ns |   735.07 ns | 10.64x slower |   0.17x | 0.6533 |    1368 B |          NA |
|             LinqFasterer | .NET 8.0 | 1000 |   100 |   630.11 ns | 12.432 ns | 13.302 ns |   629.73 ns |  9.12x slower |   0.19x | 2.5311 |    5304 B |          NA |
|                   LinqAF | .NET 8.0 | 1000 |   100 | 2,814.08 ns | 24.259 ns | 20.257 ns | 2,805.92 ns | 40.50x slower |   0.32x |      - |         - |          NA |
|               StructLinq | .NET 8.0 | 1000 |   100 |   112.76 ns |  1.242 ns |  1.101 ns |   112.80 ns |  1.62x slower |   0.02x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    60.37 ns |  0.312 ns |  0.260 ns |    60.32 ns |  1.15x faster |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 | 1000 |   100 |    70.20 ns |  0.567 ns |  0.473 ns |    70.11 ns |  1.01x slower |   0.01x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    50.81 ns |  1.040 ns |  1.650 ns |    50.00 ns |  1.37x faster |   0.05x |      - |         - |          NA |

## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

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
|                  ForLoop | .NET 6.0 | 1000 |   100 |    83.34 ns |  1.324 ns |  1.359 ns |    82.74 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 6.0 | 1000 |   100 | 1,231.22 ns | 18.542 ns | 14.476 ns | 1,231.34 ns | 14.75x slower |   0.35x | 0.0839 |     176 B |          NA |
|             LinqFasterer | .NET 6.0 | 1000 |   100 | 1,021.07 ns | 20.386 ns | 54.765 ns |   995.25 ns | 12.69x slower |   0.67x | 2.5444 |    5328 B |          NA |
|               StructLinq | .NET 6.0 | 1000 |   100 |   272.78 ns |  5.339 ns |  5.712 ns |   270.88 ns |  3.28x slower |   0.09x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   163.58 ns |  0.626 ns |  0.523 ns |   163.44 ns |  1.96x slower |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 | 1000 |   100 |   233.02 ns |  2.644 ns |  2.473 ns |   232.71 ns |  2.79x slower |   0.05x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   192.27 ns |  1.141 ns |  0.891 ns |   191.95 ns |  2.30x slower |   0.04x |      - |         - |          NA |
|                          |          |      |       |             |           |           |             |               |         |        |           |             |
|                  ForLoop | .NET 8.0 | 1000 |   100 |    57.20 ns |  0.663 ns |  0.517 ns |    57.07 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 8.0 | 1000 |   100 |   378.40 ns |  7.588 ns | 20.385 ns |   374.61 ns |  6.30x slower |   0.40x | 0.0839 |     176 B |          NA |
|             LinqFasterer | .NET 8.0 | 1000 |   100 |   699.51 ns | 15.533 ns | 43.811 ns |   700.90 ns | 11.71x slower |   0.54x | 2.5444 |    5328 B |          NA |
|               StructLinq | .NET 8.0 | 1000 |   100 |   217.21 ns |  4.353 ns |  8.176 ns |   213.11 ns |  3.78x slower |   0.15x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    86.94 ns |  1.733 ns |  1.447 ns |    86.27 ns |  1.51x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 | 1000 |   100 |    70.31 ns |  1.344 ns |  1.493 ns |    69.95 ns |  1.23x slower |   0.03x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    49.47 ns |  0.220 ns |  0.244 ns |    49.42 ns |  1.16x faster |   0.01x |      - |         - |          NA |

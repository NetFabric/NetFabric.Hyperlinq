## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|                   Method |  Runtime | Count |       Mean |     Error |    StdDev |     Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |-----------:|----------:|----------:|-----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |   885.7 ns |  17.21 ns |  16.90 ns |   877.2 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |   958.7 ns |   2.76 ns |   2.58 ns |   958.2 ns |  1.08x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 1,699.8 ns |  54.40 ns | 160.39 ns | 1,609.0 ns |  1.90x slower |   0.24x | 0.1030 |     216 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 2,408.6 ns | 174.82 ns | 515.47 ns | 2,176.8 ns |  2.82x slower |   0.43x | 4.7264 |    9904 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 3,543.4 ns |  53.44 ns |  49.98 ns | 3,550.2 ns |  4.00x slower |   0.08x | 6.0196 |   12624 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 1,953.8 ns |  27.15 ns |  22.67 ns | 1,949.9 ns |  2.20x slower |   0.04x |      - |         - |          NA |
|                 SpanLinq | .NET 6.0 |   100 | 1,957.2 ns |  31.97 ns |  31.40 ns | 1,947.1 ns |  2.21x slower |   0.06x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 1,180.3 ns |  10.94 ns |   8.54 ns | 1,177.8 ns |  1.33x slower |   0.03x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |   991.0 ns |   5.44 ns |   4.55 ns |   991.5 ns |  1.12x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 1,444.0 ns |  10.10 ns |   8.43 ns | 1,441.2 ns |  1.63x slower |   0.03x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 1,274.4 ns |  25.32 ns |  31.10 ns | 1,259.2 ns |  1.44x slower |   0.05x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 2,278.1 ns |  28.22 ns |  28.97 ns | 2,269.7 ns |  2.57x slower |   0.05x | 3.0670 |    6424 B |          NA |
|                          |          |       |            |           |           |            |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   111.7 ns |   2.23 ns |   4.03 ns |   109.8 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |   130.3 ns |   0.75 ns |   0.62 ns |   130.5 ns |  1.17x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 |   674.0 ns |  13.00 ns |  15.47 ns |   668.7 ns |  5.98x slower |   0.30x | 0.1030 |     216 B |          NA |
|               LinqFaster | .NET 8.0 |   100 |   977.2 ns |  20.94 ns |  60.08 ns |   963.7 ns |  8.82x slower |   0.67x | 4.7274 |    9904 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 1,640.7 ns |  35.92 ns | 103.07 ns | 1,587.9 ns | 15.02x slower |   0.73x | 6.0234 |   12624 B |          NA |
|                   LinqAF | .NET 8.0 |   100 |   321.1 ns |   4.41 ns |   3.68 ns |   319.9 ns |  2.89x slower |   0.06x |      - |         - |          NA |
|                 SpanLinq | .NET 8.0 |   100 |   238.8 ns |   1.33 ns |   1.24 ns |   239.3 ns |  2.15x slower |   0.05x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |   346.0 ns |   4.73 ns |   3.69 ns |   346.1 ns |  3.11x slower |   0.10x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   107.1 ns |   1.89 ns |   3.20 ns |   105.9 ns |  1.05x faster |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |   403.4 ns |   7.59 ns |   6.73 ns |   403.6 ns |  3.63x slower |   0.11x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   110.4 ns |   1.84 ns |   1.44 ns |   110.7 ns |  1.01x faster |   0.03x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 |   682.7 ns |  12.09 ns |  20.54 ns |   675.6 ns |  6.11x slower |   0.31x | 3.0670 |    6424 B |          NA |

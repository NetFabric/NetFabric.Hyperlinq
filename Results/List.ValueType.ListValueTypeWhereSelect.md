## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|                   Method |  Runtime | Count |       Mean |    Error |    StdDev |     Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |-----------:|---------:|----------:|-----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |   945.2 ns |  4.52 ns |   4.00 ns |   944.5 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 | 1,049.8 ns |  7.22 ns |   6.76 ns | 1,047.2 ns |  1.11x slower |   0.01x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 1,778.3 ns | 33.14 ns |  34.03 ns | 1,766.8 ns |  1.88x slower |   0.04x | 0.1793 |     376 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 2,182.4 ns | 31.92 ns |  26.66 ns | 2,176.4 ns |  2.31x slower |   0.03x | 3.8605 |    8088 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 2,421.6 ns | 27.45 ns |  25.68 ns | 2,420.9 ns |  2.56x slower |   0.03x | 6.4087 |   13416 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 2,616.5 ns | 53.59 ns | 156.33 ns | 2,534.1 ns |  2.94x slower |   0.09x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 1,194.5 ns | 15.07 ns |  18.50 ns | 1,190.3 ns |  1.27x slower |   0.02x | 0.0343 |      72 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 1,369.2 ns |  4.84 ns |   3.78 ns | 1,368.5 ns |  1.45x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 1,434.2 ns | 28.35 ns |  31.51 ns | 1,418.0 ns |  1.52x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 1,567.3 ns |  4.66 ns |   3.64 ns | 1,568.3 ns |  1.66x slower |   0.01x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 2,230.6 ns | 32.52 ns |  36.14 ns | 2,232.3 ns |  2.37x slower |   0.04x | 3.8605 |    8088 B |          NA |
|                          |          |       |            |          |           |            |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   145.1 ns |  0.98 ns |   0.77 ns |   145.2 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |   214.0 ns |  3.92 ns |   7.91 ns |   210.4 ns |  1.49x slower |   0.06x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 |   842.1 ns | 16.56 ns |  33.46 ns |   840.5 ns |  5.92x slower |   0.22x | 0.1793 |     376 B |          NA |
|               LinqFaster | .NET 8.0 |   100 | 1,134.6 ns |  8.85 ns |   6.91 ns | 1,135.2 ns |  7.82x slower |   0.06x | 3.8605 |    8088 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 1,447.1 ns | 24.62 ns |  29.31 ns | 1,443.8 ns | 10.02x slower |   0.23x | 6.4087 |   13416 B |          NA |
|                   LinqAF | .NET 8.0 |   100 |   465.9 ns |  8.99 ns |  21.37 ns |   455.1 ns |  3.22x slower |   0.16x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |   363.7 ns |  7.28 ns |  13.13 ns |   360.1 ns |  2.48x slower |   0.09x | 0.0343 |      72 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   111.1 ns |  1.97 ns |   1.75 ns |   110.5 ns |  1.30x faster |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |   391.9 ns |  7.07 ns |   9.68 ns |   389.2 ns |  2.69x slower |   0.09x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   126.6 ns |  0.69 ns |   0.61 ns |   126.7 ns |  1.15x faster |   0.01x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 | 1,044.0 ns | 10.84 ns |   9.61 ns | 1,043.8 ns |  7.19x slower |   0.09x | 3.8605 |    8088 B |          NA |

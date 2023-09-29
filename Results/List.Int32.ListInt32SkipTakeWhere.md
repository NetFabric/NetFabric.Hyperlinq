## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|                  ForLoop | .NET 6.0 | 1000 |   100 |   114.67 ns |  1.251 ns |  0.977 ns |   114.38 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 6.0 | 1000 |   100 | 1,481.38 ns | 27.522 ns | 53.679 ns | 1,455.99 ns | 13.04x slower |   0.58x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 6.0 | 1000 |   100 |   833.59 ns | 16.633 ns | 19.155 ns |   825.26 ns |  7.25x slower |   0.12x | 0.7458 |    1560 B |          NA |
|             LinqFasterer | .NET 6.0 | 1000 |   100 |   820.17 ns | 12.398 ns | 14.278 ns |   827.02 ns |  7.10x slower |   0.12x | 2.4424 |    5112 B |          NA |
|                   LinqAF | .NET 6.0 | 1000 |   100 | 6,027.82 ns | 86.127 ns | 76.350 ns | 6,002.56 ns | 52.62x slower |   0.86x |      - |         - |          NA |
|               StructLinq | .NET 6.0 | 1000 |   100 |   331.80 ns |  4.882 ns |  4.076 ns |   331.27 ns |  2.90x slower |   0.05x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   163.21 ns |  1.093 ns |  0.853 ns |   163.10 ns |  1.42x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 | 1000 |   100 |   324.07 ns |  6.351 ns | 11.124 ns |   322.24 ns |  2.86x slower |   0.11x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   217.63 ns |  1.515 ns |  1.183 ns |   217.25 ns |  1.90x slower |   0.02x |      - |         - |          NA |
|                          |          |      |       |             |           |           |             |               |         |        |           |             |
|                  ForLoop | .NET 8.0 | 1000 |   100 |   117.55 ns |  2.371 ns |  4.153 ns |   115.80 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 8.0 | 1000 |   100 |   419.87 ns |  3.214 ns |  3.156 ns |   419.08 ns |  3.55x slower |   0.13x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 8.0 | 1000 |   100 |   728.90 ns | 14.435 ns | 21.158 ns |   722.97 ns |  6.18x slower |   0.24x | 0.7458 |    1560 B |          NA |
|             LinqFasterer | .NET 8.0 | 1000 |   100 |   531.48 ns |  1.828 ns |  1.427 ns |   531.74 ns |  4.56x slower |   0.11x | 2.4424 |    5112 B |          NA |
|                   LinqAF | .NET 8.0 | 1000 |   100 | 2,651.90 ns | 45.368 ns | 46.590 ns | 2,637.72 ns | 22.37x slower |   1.02x |      - |         - |          NA |
|               StructLinq | .NET 8.0 | 1000 |   100 |   196.28 ns |  2.902 ns |  2.851 ns |   195.80 ns |  1.66x slower |   0.07x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    84.42 ns |  0.354 ns |  0.295 ns |    84.40 ns |  1.39x faster |   0.05x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 | 1000 |   100 |   123.03 ns |  0.557 ns |  0.435 ns |   122.90 ns |  1.06x slower |   0.03x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    60.22 ns |  0.251 ns |  0.223 ns |    60.19 ns |  1.95x faster |   0.07x |      - |         - |          NA |

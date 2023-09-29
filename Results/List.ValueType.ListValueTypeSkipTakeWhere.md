## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|                   Method |  Runtime | Skip | Count |       Mean |     Error |   StdDev |         Ratio | RatioSD |    Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |-----------:|----------:|---------:|--------------:|--------:|--------:|----------:|------------:|
|                  ForLoop | .NET 6.0 | 1000 |   100 |   815.7 ns |  15.33 ns | 15.74 ns |      baseline |         |       - |         - |          NA |
|                     Linq | .NET 6.0 | 1000 |   100 | 1,911.6 ns |  11.73 ns | 10.40 ns |  2.34x slower |   0.05x |  0.1526 |     320 B |          NA |
|               LinqFaster | .NET 6.0 | 1000 |   100 | 3,023.3 ns |  52.53 ns | 43.87 ns |  3.69x slower |   0.08x | 10.0250 |   21000 B |          NA |
|             LinqFasterer | .NET 6.0 | 1000 |   100 | 6,159.3 ns |  79.82 ns | 70.76 ns |  7.53x slower |   0.14x | 37.0331 |   80168 B |          NA |
|                   LinqAF | .NET 6.0 | 1000 |   100 | 9,923.7 ns | 105.79 ns | 98.95 ns | 12.15x slower |   0.24x |       - |         - |          NA |
|               StructLinq | .NET 6.0 | 1000 |   100 |   620.2 ns |   6.01 ns |  4.69 ns |  1.32x faster |   0.03x |  0.0572 |     120 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   530.1 ns |   2.53 ns |  1.98 ns |  1.55x faster |   0.03x |       - |         - |          NA |
|                Hyperlinq | .NET 6.0 | 1000 |   100 | 1,023.1 ns |   2.40 ns |  1.87 ns |  1.25x slower |   0.03x |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   830.9 ns |   3.79 ns |  3.36 ns |  1.02x slower |   0.02x |       - |         - |          NA |
|                          |          |      |       |            |           |          |               |         |         |           |             |
|                  ForLoop | .NET 8.0 | 1000 |   100 |   146.8 ns |   0.63 ns |  0.53 ns |      baseline |         |       - |         - |          NA |
|                     Linq | .NET 8.0 | 1000 |   100 |   695.5 ns |  11.13 ns | 10.93 ns |  4.74x slower |   0.09x |  0.1526 |     320 B |          NA |
|               LinqFaster | .NET 8.0 | 1000 |   100 | 2,056.1 ns |  36.86 ns | 42.45 ns | 14.11x slower |   0.20x | 10.0250 |   21000 B |          NA |
|             LinqFasterer | .NET 8.0 | 1000 |   100 | 5,499.0 ns |  67.46 ns | 52.67 ns | 37.46x slower |   0.42x | 37.7350 |   80168 B |          NA |
|                   LinqAF | .NET 8.0 | 1000 |   100 | 4,512.5 ns |  88.11 ns | 94.28 ns | 30.89x slower |   0.74x |       - |         - |          NA |
|               StructLinq | .NET 8.0 | 1000 |   100 |   240.1 ns |   3.64 ns |  3.40 ns |  1.64x slower |   0.02x |  0.0572 |     120 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 |   100 |   126.0 ns |   2.26 ns |  1.76 ns |  1.17x faster |   0.02x |       - |         - |          NA |
|                Hyperlinq | .NET 8.0 | 1000 |   100 |   206.3 ns |   3.05 ns |  3.14 ns |  1.41x slower |   0.02x |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 | 1000 |   100 |   101.3 ns |   1.24 ns |  1.38 ns |  1.45x faster |   0.02x |       - |         - |          NA |

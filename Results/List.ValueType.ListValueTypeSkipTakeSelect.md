## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                   Method |  Runtime | Skip | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |    Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|----------:|------------:|
|                  ForLoop | .NET 6.0 | 1000 |   100 |  1,638.8 ns |  15.01 ns |  13.31 ns |      baseline |         |       - |         - |          NA |
|                     Linq | .NET 6.0 | 1000 |   100 |  2,549.4 ns |  42.34 ns |  35.36 ns |  1.56x slower |   0.02x |  0.1526 |     320 B |          NA |
|               LinqFaster | .NET 6.0 | 1000 |   100 |  4,536.9 ns |  89.96 ns | 137.38 ns |  2.82x slower |   0.08x |  9.2545 |   19368 B |          NA |
|             LinqFasterer | .NET 6.0 | 1000 |   100 |  7,628.0 ns | 147.93 ns | 327.79 ns |  4.67x slower |   0.18x | 38.4598 |   83304 B |          NA |
|                   LinqAF | .NET 6.0 | 1000 |   100 | 10,437.1 ns | 198.59 ns | 258.22 ns |  6.44x slower |   0.16x |       - |         - |          NA |
|               StructLinq | .NET 6.0 | 1000 |   100 |  1,774.7 ns |  23.05 ns |  20.43 ns |  1.08x slower |   0.02x |  0.0572 |     120 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 | 1000 |   100 |  1,665.0 ns |  25.91 ns |  22.97 ns |  1.02x slower |   0.02x |       - |         - |          NA |
|                Hyperlinq | .NET 6.0 | 1000 |   100 |  2,441.3 ns |  16.22 ns |  12.66 ns |  1.49x slower |   0.02x |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 | 1000 |   100 |  1,749.7 ns |  33.53 ns |  37.27 ns |  1.07x slower |   0.02x |       - |         - |          NA |
|                          |          |      |       |             |           |           |               |         |         |           |             |
|                  ForLoop | .NET 8.0 | 1000 |   100 |    160.3 ns |   2.39 ns |   2.75 ns |      baseline |         |       - |         - |          NA |
|                     Linq | .NET 8.0 | 1000 |   100 |  1,043.7 ns |  16.28 ns |  13.59 ns |  6.50x slower |   0.17x |  0.1526 |     320 B |          NA |
|               LinqFaster | .NET 8.0 | 1000 |   100 |  2,167.0 ns |  30.65 ns |  34.07 ns | 13.52x slower |   0.28x |  9.2583 |   19368 B |          NA |
|             LinqFasterer | .NET 8.0 | 1000 |   100 |  5,969.6 ns |  39.63 ns |  44.05 ns | 37.24x slower |   0.61x | 38.4598 |   83304 B |          NA |
|                   LinqAF | .NET 8.0 | 1000 |   100 |  4,452.4 ns |  19.98 ns |  17.71 ns | 27.74x slower |   0.58x |       - |         - |          NA |
|               StructLinq | .NET 8.0 | 1000 |   100 |    301.1 ns |   4.33 ns |   3.61 ns |  1.87x slower |   0.05x |  0.0572 |     120 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    118.2 ns |   0.30 ns |   0.25 ns |  1.36x faster |   0.03x |       - |         - |          NA |
|                Hyperlinq | .NET 8.0 | 1000 |   100 |    295.9 ns |   1.92 ns |   1.60 ns |  1.84x slower |   0.04x |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 | 1000 |   100 |    101.2 ns |   1.35 ns |   1.39 ns |  1.59x faster |   0.03x |       - |         - |          NA |

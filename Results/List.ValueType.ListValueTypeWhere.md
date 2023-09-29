## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|                   Method |  Runtime | Count |       Mean |    Error |   StdDev |     Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |-----------:|---------:|---------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |   571.9 ns | 10.56 ns | 10.84 ns |   566.5 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |   670.6 ns |  9.06 ns | 12.09 ns |   668.6 ns | 1.17x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 1,264.8 ns | 15.59 ns | 12.17 ns | 1,265.0 ns | 2.21x slower |   0.05x | 0.0877 |     184 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 1,449.6 ns | 25.44 ns | 41.80 ns | 1,436.4 ns | 2.54x slower |   0.10x | 3.8605 |    8088 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 1,642.0 ns | 31.17 ns | 30.61 ns | 1,640.0 ns | 2.87x slower |   0.06x | 4.7379 |    9936 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 1,703.4 ns | 30.36 ns | 25.36 ns | 1,700.9 ns | 2.98x slower |   0.08x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 |   667.0 ns | 12.57 ns | 19.57 ns |   660.5 ns | 1.16x slower |   0.03x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |   535.6 ns |  9.50 ns | 10.16 ns |   533.6 ns | 1.07x faster |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 1,316.7 ns | 22.76 ns | 24.35 ns | 1,310.5 ns | 2.30x slower |   0.05x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 |   830.9 ns | 14.30 ns | 12.68 ns |   827.2 ns | 1.45x slower |   0.04x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 1,703.0 ns | 32.60 ns | 42.38 ns | 1,707.3 ns | 2.98x slower |   0.08x | 3.8605 |    8088 B |          NA |
|                          |          |       |            |          |          |            |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   151.7 ns |  3.08 ns |  7.02 ns |   148.7 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |   135.9 ns |  2.74 ns |  2.94 ns |   135.2 ns | 1.14x faster |   0.07x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 |   781.0 ns | 14.46 ns | 12.07 ns |   774.7 ns | 5.01x slower |   0.26x | 0.0877 |     184 B |          NA |
|               LinqFaster | .NET 8.0 |   100 |   866.7 ns | 16.68 ns | 35.90 ns |   848.7 ns | 5.71x slower |   0.37x | 3.8605 |    8088 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 |   963.6 ns | 15.57 ns | 15.29 ns |   964.4 ns | 6.18x slower |   0.36x | 4.7379 |    9936 B |          NA |
|                   LinqAF | .NET 8.0 |   100 |   486.3 ns |  4.57 ns |  4.05 ns |   485.3 ns | 3.12x slower |   0.19x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |   222.4 ns |  3.23 ns |  3.17 ns |   221.3 ns | 1.43x slower |   0.07x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   132.1 ns |  1.33 ns |  1.03 ns |   131.9 ns | 1.18x faster |   0.08x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |   246.8 ns |  2.20 ns |  1.95 ns |   246.6 ns | 1.58x slower |   0.10x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   124.4 ns |  0.87 ns |  0.78 ns |   124.3 ns | 1.26x faster |   0.08x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 |   946.4 ns | 18.19 ns | 22.34 ns |   943.5 ns | 6.14x slower |   0.41x | 3.8605 |    8088 B |          NA |

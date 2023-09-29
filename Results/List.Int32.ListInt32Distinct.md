## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|                   Method |  Runtime | Duplicates | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |   Gen0 | Allocated |   Alloc Ratio |
|------------------------- |--------- |----------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|----------:|--------------:|
|                  ForLoop | .NET 6.0 |          4 |   100 | 3,090.7 ns | 43.44 ns | 48.28 ns |     baseline |         | 2.8648 |    6000 B |               |
|              ForeachLoop | .NET 6.0 |          4 |   100 | 3,039.6 ns | 28.34 ns | 31.50 ns | 1.02x faster |   0.01x | 2.8648 |    6000 B |   1.000x more |
|                     Linq | .NET 6.0 |          4 |   100 | 5,709.8 ns | 96.53 ns | 75.37 ns | 1.84x slower |   0.05x | 2.8534 |    6000 B |   1.000x more |
|               LinqFaster | .NET 6.0 |          4 |   100 |   716.3 ns |  6.06 ns |  5.06 ns | 4.32x faster |   0.09x |      - |         - |            NA |
|             LinqFasterer | .NET 6.0 |          4 |   100 | 4,814.7 ns | 56.30 ns | 43.96 ns | 1.56x slower |   0.04x | 5.2032 |   10896 B |   1.816x more |
|                   LinqAF | .NET 6.0 |          4 |   100 | 8,181.6 ns | 74.86 ns | 58.44 ns | 2.64x slower |   0.05x | 5.9204 |   12400 B |   2.067x more |
|               StructLinq | .NET 6.0 |          4 |   100 | 3,318.1 ns | 14.00 ns | 13.75 ns | 1.07x slower |   0.02x | 0.0153 |      32 B | 187.500x less |
| StructLinq_ValueDelegate | .NET 6.0 |          4 |   100 | 3,320.1 ns | 28.61 ns | 23.89 ns | 1.07x slower |   0.02x |      - |         - |            NA |
|                Hyperlinq | .NET 6.0 |          4 |   100 | 3,363.9 ns | 54.87 ns | 48.64 ns | 1.09x slower |   0.03x |      - |         - |            NA |
|                          |          |            |       |            |          |          |              |         |        |           |               |
|                  ForLoop | .NET 8.0 |          4 |   100 | 3,299.7 ns | 30.71 ns | 23.98 ns |     baseline |         | 2.8648 |    6000 B |               |
|              ForeachLoop | .NET 8.0 |          4 |   100 | 3,133.2 ns | 57.75 ns | 56.71 ns | 1.05x faster |   0.03x | 2.8648 |    6000 B |   1.000x more |
|                     Linq | .NET 8.0 |          4 |   100 | 3,881.7 ns | 32.71 ns | 30.59 ns | 1.18x slower |   0.01x | 2.8610 |    6000 B |   1.000x more |
|               LinqFaster | .NET 8.0 |          4 |   100 |   560.2 ns |  2.23 ns |  1.86 ns | 5.89x faster |   0.04x |      - |         - |            NA |
|             LinqFasterer | .NET 8.0 |          4 |   100 | 3,580.8 ns | 40.23 ns | 31.41 ns | 1.09x slower |   0.01x | 5.2032 |   10896 B |   1.816x more |
|                   LinqAF | .NET 8.0 |          4 |   100 | 6,053.5 ns | 97.16 ns | 75.86 ns | 1.83x slower |   0.03x | 5.9204 |   12400 B |   2.067x more |
|               StructLinq | .NET 8.0 |          4 |   100 | 2,626.1 ns | 18.29 ns | 16.21 ns | 1.26x faster |   0.01x | 0.0153 |      32 B | 187.500x less |
| StructLinq_ValueDelegate | .NET 8.0 |          4 |   100 | 2,611.1 ns | 36.83 ns | 28.76 ns | 1.26x faster |   0.02x |      - |         - |            NA |
|                Hyperlinq | .NET 8.0 |          4 |   100 | 2,551.1 ns | 50.16 ns | 59.71 ns | 1.28x faster |   0.04x |      - |         - |            NA |

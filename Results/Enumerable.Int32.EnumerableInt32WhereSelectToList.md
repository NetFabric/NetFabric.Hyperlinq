## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|              ForeachLoop | .NET 6.0 |   100 |   747.1 ns |  8.62 ns |  6.73 ns |   745.1 ns |     baseline |         | 0.3242 |     680 B |             |
|                     Linq | .NET 6.0 |   100 |   902.5 ns | 15.63 ns | 19.19 ns |   895.2 ns | 1.20x slower |   0.03x | 0.3815 |     800 B |  1.18x more |
|                   LinqAF | .NET 6.0 |   100 | 1,222.0 ns | 23.54 ns | 22.02 ns | 1,227.2 ns | 1.63x slower |   0.03x | 0.3242 |     680 B |  1.00x more |
|               StructLinq | .NET 6.0 |   100 | 1,010.2 ns | 19.95 ns | 15.58 ns | 1,014.2 ns | 1.35x slower |   0.03x | 0.1869 |     392 B |  1.73x less |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |   662.8 ns | 12.36 ns | 15.18 ns |   657.8 ns | 1.13x faster |   0.02x | 0.1450 |     304 B |  2.24x less |
|                Hyperlinq | .NET 6.0 |   100 | 1,080.5 ns | 16.83 ns | 14.05 ns | 1,082.8 ns | 1.44x slower |   0.02x | 0.1450 |     304 B |  2.24x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 |   945.8 ns |  8.16 ns |  7.23 ns |   943.7 ns | 1.27x slower |   0.01x | 0.1450 |     304 B |  2.24x less |
|                          |          |       |            |          |          |            |              |         |        |           |             |
|              ForeachLoop | .NET 8.0 |   100 |   274.7 ns |  2.40 ns |  2.13 ns |   273.9 ns |     baseline |         | 0.3247 |     680 B |             |
|                     Linq | .NET 8.0 |   100 |   357.4 ns |  3.50 ns |  3.89 ns |   356.3 ns | 1.30x slower |   0.01x | 0.3824 |     800 B |  1.18x more |
|                   LinqAF | .NET 8.0 |   100 |   493.8 ns |  5.28 ns |  4.94 ns |   493.5 ns | 1.80x slower |   0.02x | 0.3242 |     680 B |  1.00x more |
|               StructLinq | .NET 8.0 |   100 |   481.7 ns |  2.17 ns |  1.81 ns |   481.5 ns | 1.75x slower |   0.01x | 0.1869 |     392 B |  1.73x less |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   410.8 ns |  7.97 ns |  8.52 ns |   407.6 ns | 1.50x slower |   0.03x | 0.1450 |     304 B |  2.24x less |
|                Hyperlinq | .NET 8.0 |   100 |   537.2 ns |  8.94 ns |  7.92 ns |   539.0 ns | 1.96x slower |   0.04x | 0.1450 |     304 B |  2.24x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   499.2 ns |  9.98 ns | 22.52 ns |   486.9 ns | 1.87x slower |   0.06x | 0.1450 |     304 B |  2.24x less |

## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                   Method |  Runtime | Count |       Mean |    Error |    StdDev |     Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |-----------:|---------:|----------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 | 1,637.0 ns | 31.63 ns |  82.78 ns | 1,634.2 ns |     baseline |         | 5.5237 |   11.3 KB |             |
|              ForeachLoop | .NET 6.0 |   100 | 1,686.0 ns | 31.95 ns |  31.37 ns | 1,685.9 ns | 1.01x faster |   0.05x | 5.5237 |   11.3 KB |  1.00x more |
|                     Linq | .NET 6.0 |   100 | 1,730.1 ns | 25.95 ns |  25.48 ns | 1,728.1 ns | 1.01x slower |   0.05x | 4.0035 |   8.19 KB |  1.38x less |
|               LinqFaster | .NET 6.0 |   100 | 2,061.8 ns | 26.82 ns |  22.40 ns | 2,058.9 ns | 1.21x slower |   0.06x | 5.5237 |   11.3 KB |  1.00x more |
|             LinqFasterer | .NET 6.0 |   100 | 1,897.6 ns | 17.95 ns |  14.01 ns | 1,904.0 ns | 1.11x slower |   0.05x | 6.3934 |  13.07 KB |  1.16x more |
|                   LinqAF | .NET 6.0 |   100 | 3,287.9 ns | 68.93 ns | 194.43 ns | 3,174.4 ns | 2.01x slower |   0.14x | 5.5084 |  11.27 KB |  1.00x less |
|               StructLinq | .NET 6.0 |   100 | 2,042.5 ns | 43.09 ns | 123.63 ns | 2,020.7 ns | 1.25x slower |   0.08x | 1.7109 |    3.5 KB |  3.23x less |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 1,089.6 ns | 17.58 ns |  22.86 ns | 1,082.6 ns | 1.54x faster |   0.07x | 1.6575 |    3.4 KB |  3.32x less |
|                Hyperlinq | .NET 6.0 |   100 | 1,674.7 ns | 33.56 ns |  79.10 ns | 1,642.1 ns | 1.03x slower |   0.07x | 1.6575 |    3.4 KB |  3.32x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 1,235.6 ns | 23.67 ns |  20.99 ns | 1,237.1 ns | 1.38x faster |   0.07x | 1.6575 |    3.4 KB |  3.32x less |
|                  Faslinq | .NET 6.0 |   100 | 1,774.1 ns | 26.15 ns |  21.83 ns | 1,770.9 ns | 1.04x slower |   0.05x | 5.5237 |   11.3 KB |  1.00x more |
|                          |          |       |            |          |           |            |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   940.7 ns | 18.87 ns |  15.76 ns |   940.5 ns |     baseline |         | 5.5237 |   11.3 KB |             |
|              ForeachLoop | .NET 8.0 |   100 |   991.1 ns | 11.11 ns |   9.28 ns |   991.4 ns | 1.05x slower |   0.01x | 5.5237 |   11.3 KB |  1.00x more |
|                     Linq | .NET 8.0 |   100 |   890.6 ns |  6.63 ns |   6.52 ns |   890.3 ns | 1.06x faster |   0.02x | 4.0045 |   8.19 KB |  1.38x less |
|               LinqFaster | .NET 8.0 |   100 | 1,141.1 ns | 10.71 ns |   8.36 ns | 1,138.7 ns | 1.21x slower |   0.02x | 5.5237 |   11.3 KB |  1.00x more |
|             LinqFasterer | .NET 8.0 |   100 | 1,158.9 ns | 22.97 ns |  27.34 ns | 1,148.0 ns | 1.23x slower |   0.04x | 6.3953 |  13.07 KB |  1.16x more |
|                   LinqAF | .NET 8.0 |   100 | 1,600.0 ns | 30.25 ns |  25.26 ns | 1,592.8 ns | 1.70x slower |   0.03x | 5.5084 |  11.27 KB |  1.00x less |
|               StructLinq | .NET 8.0 |   100 |   940.1 ns | 10.46 ns |   8.16 ns |   937.5 ns | 1.00x faster |   0.02x | 1.7109 |    3.5 KB |  3.23x less |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   587.8 ns | 10.91 ns |  11.20 ns |   584.3 ns | 1.60x faster |   0.05x | 1.6575 |    3.4 KB |  3.32x less |
|                Hyperlinq | .NET 8.0 |   100 |   689.9 ns |  5.14 ns |   4.01 ns |   689.6 ns | 1.37x faster |   0.02x | 1.6575 |    3.4 KB |  3.32x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   583.7 ns |  5.72 ns |   4.78 ns |   583.3 ns | 1.61x faster |   0.03x | 1.6575 |    3.4 KB |  3.32x less |
|                  Faslinq | .NET 8.0 |   100 | 1,095.9 ns |  6.90 ns |   5.39 ns | 1,094.7 ns | 1.16x slower |   0.02x | 5.5237 |   11.3 KB |  1.00x more |

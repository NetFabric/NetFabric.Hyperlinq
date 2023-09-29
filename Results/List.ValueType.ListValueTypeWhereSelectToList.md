## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                  ForLoop | .NET 6.0 |   100 | 1,291.3 ns | 10.38 ns |  11.53 ns | 1,290.0 ns |     baseline |         | 3.8605 |    7.9 KB |             |
|              ForeachLoop | .NET 6.0 |   100 | 1,373.1 ns | 23.67 ns |  26.31 ns | 1,375.5 ns | 1.06x slower |   0.02x | 3.8605 |    7.9 KB |  1.00x more |
|                     Linq | .NET 6.0 |   100 | 2,193.4 ns | 43.67 ns |  89.20 ns | 2,169.2 ns | 1.70x slower |   0.08x | 4.0436 |   8.27 KB |  1.05x more |
|               LinqFaster | .NET 6.0 |   100 | 1,799.7 ns | 15.96 ns |  13.32 ns | 1,799.3 ns | 1.39x slower |   0.02x | 5.5389 |  11.33 KB |  1.43x more |
|             LinqFasterer | .NET 6.0 |   100 | 3,449.2 ns | 68.29 ns | 108.31 ns | 3,439.1 ns | 2.66x slower |   0.10x | 8.0643 |   16.5 KB |  2.09x more |
|                   LinqAF | .NET 6.0 |   100 | 2,852.1 ns | 56.45 ns |  47.14 ns | 2,835.0 ns | 2.21x slower |   0.04x | 3.8605 |    7.9 KB |  1.00x more |
|               StructLinq | .NET 6.0 |   100 | 1,401.7 ns | 16.91 ns |  18.80 ns | 1,397.8 ns | 1.09x slower |   0.02x | 1.7262 |   3.53 KB |  2.24x less |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 1,120.2 ns | 22.35 ns |  31.33 ns | 1,106.7 ns | 1.15x faster |   0.04x | 1.6766 |   3.43 KB |  2.30x less |
|                Hyperlinq | .NET 6.0 |   100 | 1,634.4 ns | 32.69 ns |  82.61 ns | 1,602.4 ns | 1.29x slower |   0.07x | 1.6766 |   3.43 KB |  2.30x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 1,309.9 ns | 21.54 ns |  17.99 ns | 1,311.0 ns | 1.01x slower |   0.02x | 1.6766 |   3.43 KB |  2.30x less |
|                  Faslinq | .NET 6.0 |   100 | 1,541.1 ns | 28.02 ns |  21.87 ns | 1,532.5 ns | 1.19x slower |   0.02x | 3.8605 |    7.9 KB |  1.00x more |
|                          |          |       |            |          |           |            |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   724.7 ns |  9.01 ns |   9.64 ns |   721.6 ns |     baseline |         | 3.8605 |    7.9 KB |             |
|              ForeachLoop | .NET 8.0 |   100 |   793.4 ns | 15.65 ns |  17.40 ns |   797.4 ns | 1.09x slower |   0.03x | 3.8605 |    7.9 KB |  1.00x more |
|                     Linq | .NET 8.0 |   100 |   870.6 ns | 17.38 ns |  16.26 ns |   865.0 ns | 1.20x slower |   0.03x | 4.0436 |   8.27 KB |  1.05x more |
|               LinqFaster | .NET 8.0 |   100 | 1,138.4 ns |  8.09 ns |   6.76 ns | 1,140.1 ns | 1.57x slower |   0.02x | 5.5389 |  11.33 KB |  1.43x more |
|             LinqFasterer | .NET 8.0 |   100 | 1,439.1 ns | 17.95 ns |  21.37 ns | 1,437.7 ns | 1.99x slower |   0.04x | 8.0643 |   16.5 KB |  2.09x more |
|                   LinqAF | .NET 8.0 |   100 | 1,348.7 ns | 13.06 ns |  10.20 ns | 1,345.4 ns | 1.86x slower |   0.03x | 3.8605 |    7.9 KB |  1.00x more |
|               StructLinq | .NET 8.0 |   100 |   962.0 ns |  3.71 ns |   3.29 ns |   961.7 ns | 1.33x slower |   0.02x | 1.7262 |   3.53 KB |  2.24x less |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   585.1 ns |  9.22 ns |   7.19 ns |   581.4 ns | 1.24x faster |   0.03x | 1.6775 |   3.43 KB |  2.30x less |
|                Hyperlinq | .NET 8.0 |   100 |   693.6 ns | 11.79 ns |  19.71 ns |   684.7 ns | 1.05x faster |   0.04x | 1.6775 |   3.43 KB |  2.30x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   621.2 ns | 12.04 ns |  14.78 ns |   623.9 ns | 1.16x faster |   0.03x | 1.6775 |   3.43 KB |  2.30x less |
|                  Faslinq | .NET 8.0 |   100 |   842.5 ns | 14.17 ns |  14.55 ns |   836.4 ns | 1.16x slower |   0.03x | 3.8605 |    7.9 KB |  1.00x more |

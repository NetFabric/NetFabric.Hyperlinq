## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                  ForLoop | .NET 6.0 |   100 | 1,235.4 ns | 13.89 ns |  12.31 ns | 1,232.1 ns |     baseline |         | 3.8605 |    7.9 KB |             |
|              ForeachLoop | .NET 6.0 |   100 | 1,418.6 ns | 26.92 ns |  57.37 ns | 1,402.8 ns | 1.21x slower |   0.03x | 3.8605 |    7.9 KB |  1.00x more |
|                     Linq | .NET 6.0 |   100 | 1,693.9 ns | 38.79 ns | 110.68 ns | 1,691.5 ns | 1.39x slower |   0.08x | 3.9673 |   8.11 KB |  1.03x more |
|               LinqFaster | .NET 6.0 |   100 | 1,609.0 ns | 18.72 ns |  14.62 ns | 1,606.0 ns | 1.30x slower |   0.02x | 6.4087 |   13.1 KB |  1.66x more |
|             LinqFasterer | .NET 6.0 |   100 | 3,094.1 ns | 61.92 ns | 178.67 ns | 3,096.5 ns | 2.53x slower |   0.16x | 9.0332 |  18.48 KB |  2.34x more |
|                   LinqAF | .NET 6.0 |   100 | 2,500.2 ns | 59.93 ns | 170.01 ns | 2,460.4 ns | 2.09x slower |   0.14x | 3.8605 |    7.9 KB |  1.00x more |
|                 SpanLinq | .NET 6.0 |   100 | 1,875.7 ns | 24.22 ns |  22.65 ns | 1,877.2 ns | 1.52x slower |   0.03x | 3.8605 |    7.9 KB |  1.00x more |
|               StructLinq | .NET 6.0 |   100 | 1,435.8 ns | 14.89 ns |  12.43 ns | 1,434.1 ns | 1.16x slower |   0.02x | 1.7204 |   3.52 KB |  2.24x less |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 1,284.3 ns | 24.83 ns |  23.22 ns | 1,277.2 ns | 1.04x slower |   0.02x | 1.6766 |   3.43 KB |  2.30x less |
|                Hyperlinq | .NET 6.0 |   100 | 1,651.8 ns | 33.00 ns |  75.15 ns | 1,620.3 ns | 1.37x slower |   0.08x | 1.6747 |   3.43 KB |  2.30x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 1,430.2 ns | 21.03 ns |  16.42 ns | 1,425.9 ns | 1.16x slower |   0.02x | 1.6766 |   3.43 KB |  2.30x less |
|                  Faslinq | .NET 6.0 |   100 | 1,600.6 ns | 16.00 ns |  14.18 ns | 1,601.4 ns | 1.30x slower |   0.02x | 6.1531 |  12.58 KB |  1.59x more |
|                          |          |       |            |          |           |            |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   753.1 ns | 12.71 ns |  16.53 ns |   748.6 ns |     baseline |         | 3.8605 |    7.9 KB |             |
|              ForeachLoop | .NET 8.0 |   100 |   773.1 ns | 15.46 ns |  42.33 ns |   752.7 ns | 1.04x slower |   0.04x | 3.8605 |    7.9 KB |  1.00x more |
|                     Linq | .NET 8.0 |   100 |   920.2 ns | 20.24 ns |  56.75 ns |   892.2 ns | 1.26x slower |   0.10x | 3.9673 |   8.11 KB |  1.03x more |
|               LinqFaster | .NET 8.0 |   100 | 1,218.8 ns | 27.58 ns |  79.58 ns | 1,208.1 ns | 1.63x slower |   0.10x | 6.4087 |   13.1 KB |  1.66x more |
|             LinqFasterer | .NET 8.0 |   100 | 1,856.8 ns | 23.72 ns |  18.52 ns | 1,857.6 ns | 2.48x slower |   0.05x | 9.0332 |  18.48 KB |  2.34x more |
|                   LinqAF | .NET 8.0 |   100 | 1,395.5 ns | 36.49 ns | 105.29 ns | 1,343.2 ns | 1.92x slower |   0.12x | 3.8605 |    7.9 KB |  1.00x more |
|                 SpanLinq | .NET 8.0 |   100 |   916.0 ns | 22.80 ns |  64.30 ns |   882.4 ns | 1.26x slower |   0.10x | 3.8605 |    7.9 KB |  1.00x more |
|               StructLinq | .NET 8.0 |   100 | 1,084.1 ns | 23.32 ns |  66.90 ns | 1,065.9 ns | 1.51x slower |   0.09x | 1.7223 |   3.52 KB |  2.24x less |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   710.0 ns |  9.03 ns |   7.05 ns |   709.7 ns | 1.05x faster |   0.02x | 1.6775 |   3.43 KB |  2.30x less |
|                Hyperlinq | .NET 8.0 |   100 |   731.2 ns | 10.64 ns |   9.95 ns |   729.9 ns | 1.03x faster |   0.03x | 1.6766 |   3.43 KB |  2.30x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   754.4 ns | 17.49 ns |  50.75 ns |   726.3 ns | 1.02x slower |   0.07x | 1.6775 |   3.43 KB |  2.30x less |
|                  Faslinq | .NET 8.0 |   100 | 1,406.6 ns | 30.04 ns |  84.24 ns | 1,406.4 ns | 1.92x slower |   0.10x | 6.1531 |  12.58 KB |  1.59x more |

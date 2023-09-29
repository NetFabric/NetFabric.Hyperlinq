## List.ValueType.ListValueTypeToArray

### Source
[ListValueTypeToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeToArray.cs)

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
|                   Method |  Runtime | Count |     Mean |   Error |   StdDev |   Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|--------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|             List_ToArray | .NET 6.0 |   100 | 365.7 ns | 7.32 ns | 15.12 ns | 362.4 ns |     baseline |         | 3.0670 |   6.27 KB |             |
|                     Linq | .NET 6.0 |   100 | 378.3 ns | 7.05 ns | 10.76 ns | 380.1 ns | 1.02x slower |   0.05x | 3.0670 |   6.27 KB |  1.00x more |
|             LinqFasterer | .NET 6.0 |   100 | 362.9 ns | 7.18 ns |  9.08 ns | 366.1 ns | 1.02x faster |   0.02x | 3.0670 |   6.27 KB |  1.00x more |
|                   LinqAF | .NET 6.0 |   100 | 370.2 ns | 6.60 ns |  7.60 ns | 368.5 ns | 1.01x slower |   0.04x | 3.0670 |   6.27 KB |  1.00x more |
|               StructLinq | .NET 6.0 |   100 | 391.9 ns | 5.15 ns |  5.51 ns | 391.6 ns | 1.07x slower |   0.04x | 3.0861 |   6.31 KB |  1.01x more |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 328.8 ns | 5.98 ns |  6.14 ns | 331.4 ns | 1.11x faster |   0.03x | 3.0580 |   6.27 KB |  1.00x more |
|                Hyperlinq | .NET 6.0 |   100 | 375.3 ns | 4.18 ns |  3.49 ns | 374.2 ns | 1.03x slower |   0.04x | 3.0670 |   6.27 KB |  1.00x more |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 377.4 ns | 7.58 ns | 16.32 ns | 373.9 ns | 1.03x slower |   0.05x | 3.0670 |   6.27 KB |  1.00x more |
|                          |          |       |          |         |          |          |              |         |        |           |             |
|             List_ToArray | .NET 8.0 |   100 | 394.1 ns | 4.66 ns |  5.36 ns | 393.0 ns |     baseline |         | 3.0670 |   6.27 KB |             |
|                     Linq | .NET 8.0 |   100 | 405.9 ns | 7.98 ns |  9.50 ns | 401.7 ns | 1.03x slower |   0.02x | 3.0670 |   6.27 KB |  1.00x more |
|             LinqFasterer | .NET 8.0 |   100 | 394.2 ns | 6.87 ns |  7.05 ns | 391.4 ns | 1.00x faster |   0.02x | 3.0670 |   6.27 KB |  1.00x more |
|                   LinqAF | .NET 8.0 |   100 | 418.5 ns | 8.38 ns | 21.48 ns | 411.2 ns | 1.05x slower |   0.06x | 3.0670 |   6.27 KB |  1.00x more |
|               StructLinq | .NET 8.0 |   100 | 399.6 ns | 2.69 ns |  3.30 ns | 398.8 ns | 1.01x slower |   0.01x | 3.0861 |   6.31 KB |  1.01x more |
| StructLinq_ValueDelegate | .NET 8.0 |   100 | 317.9 ns | 2.02 ns |  1.58 ns | 317.7 ns | 1.24x faster |   0.02x | 3.0580 |   6.27 KB |  1.00x more |
|                Hyperlinq | .NET 8.0 |   100 | 406.8 ns | 7.99 ns | 12.68 ns | 405.5 ns | 1.04x slower |   0.04x | 3.0670 |   6.27 KB |  1.00x more |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 | 406.2 ns | 7.48 ns |  8.61 ns | 406.1 ns | 1.03x slower |   0.03x | 3.0670 |   6.27 KB |  1.00x more |

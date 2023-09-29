## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                   Method |  Runtime | Count |       Mean |   Error |  StdDev |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |-----------:|--------:|--------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |   241.7 ns | 1.53 ns | 1.36 ns |     baseline |         | 0.3095 |     648 B |             |
|              ForeachLoop | .NET 6.0 |   100 |   247.7 ns | 1.32 ns | 1.10 ns | 1.02x slower |   0.01x | 0.3095 |     648 B |  1.00x more |
|                     Linq | .NET 6.0 |   100 |   476.2 ns | 3.61 ns | 3.02 ns | 1.97x slower |   0.02x | 0.3824 |     800 B |  1.23x more |
|               LinqFaster | .NET 6.0 |   100 |   437.8 ns | 4.14 ns | 3.45 ns | 1.81x slower |   0.02x | 0.4396 |     920 B |  1.42x more |
|             LinqFasterer | .NET 6.0 |   100 |   513.5 ns | 5.58 ns | 5.22 ns | 2.12x slower |   0.02x | 0.5617 |    1176 B |  1.81x more |
|                   LinqAF | .NET 6.0 |   100 | 1,104.9 ns | 3.89 ns | 3.25 ns | 4.57x slower |   0.03x | 0.3090 |     648 B |  1.00x more |
|               StructLinq | .NET 6.0 |   100 |   525.7 ns | 3.22 ns | 2.86 ns | 2.18x slower |   0.02x | 0.1755 |     368 B |  1.76x less |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |   288.9 ns | 1.89 ns | 1.67 ns | 1.20x slower |   0.01x | 0.1297 |     272 B |  2.38x less |
|                Hyperlinq | .NET 6.0 |   100 |   582.7 ns | 2.73 ns | 2.13 ns | 2.41x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 |   354.3 ns | 4.77 ns | 5.11 ns | 1.47x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
|                  Faslinq | .NET 6.0 |   100 |   455.7 ns | 8.84 ns | 8.27 ns | 1.89x slower |   0.04x | 0.3095 |     648 B |  1.00x more |
|                          |          |       |            |         |         |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   237.8 ns | 3.01 ns | 2.51 ns |     baseline |         | 0.3095 |     648 B |             |
|              ForeachLoop | .NET 8.0 |   100 |   226.6 ns | 1.56 ns | 1.53 ns | 1.05x faster |   0.01x | 0.3097 |     648 B |  1.00x more |
|                     Linq | .NET 8.0 |   100 |   362.9 ns | 3.81 ns | 4.23 ns | 1.53x slower |   0.02x | 0.3824 |     800 B |  1.23x more |
|               LinqFaster | .NET 8.0 |   100 |   292.5 ns | 4.19 ns | 3.27 ns | 1.23x slower |   0.02x | 0.4396 |     920 B |  1.42x more |
|             LinqFasterer | .NET 8.0 |   100 |   270.9 ns | 2.05 ns | 2.28 ns | 1.14x slower |   0.01x | 0.5622 |    1176 B |  1.81x more |
|                   LinqAF | .NET 8.0 |   100 |   467.6 ns | 8.76 ns | 7.77 ns | 1.97x slower |   0.04x | 0.3095 |     648 B |  1.00x more |
|               StructLinq | .NET 8.0 |   100 |   403.8 ns | 7.43 ns | 7.95 ns | 1.70x slower |   0.04x | 0.1760 |     368 B |  1.76x less |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   255.2 ns | 1.98 ns | 1.85 ns | 1.07x slower |   0.01x | 0.1297 |     272 B |  2.38x less |
|                Hyperlinq | .NET 8.0 |   100 |   353.8 ns | 2.87 ns | 3.53 ns | 1.49x slower |   0.03x | 0.1297 |     272 B |  2.38x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   290.6 ns | 1.57 ns | 1.31 ns | 1.22x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
|                  Faslinq | .NET 8.0 |   100 |   339.8 ns | 5.86 ns | 6.51 ns | 1.43x slower |   0.03x | 0.3095 |     648 B |  1.00x more |

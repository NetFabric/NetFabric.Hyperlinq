## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|              ForeachLoop | .NET 6.0 |   100 |   717.7 ns | 13.64 ns | 14.59 ns |   712.0 ns |     baseline |         | 0.4396 |     920 B |             |
|                     Linq | .NET 6.0 |   100 |   969.9 ns | 13.68 ns | 11.42 ns |   966.1 ns | 1.35x slower |   0.03x | 0.4005 |     840 B |  1.10x less |
|                   LinqAF | .NET 6.0 |   100 | 1,215.5 ns | 20.96 ns | 18.58 ns | 1,209.2 ns | 1.69x slower |   0.05x | 0.4234 |     888 B |  1.04x less |
|               StructLinq | .NET 6.0 |   100 |   995.0 ns |  5.03 ns |  4.70 ns |   993.7 ns | 1.39x slower |   0.03x | 0.1717 |     360 B |  2.56x less |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |   649.9 ns | 10.05 ns | 11.57 ns |   647.0 ns | 1.10x faster |   0.02x | 0.1297 |     272 B |  3.38x less |
|                Hyperlinq | .NET 6.0 |   100 | 1,012.8 ns | 13.88 ns | 10.84 ns | 1,011.0 ns | 1.42x slower |   0.03x | 0.1297 |     272 B |  3.38x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 |   927.3 ns | 17.09 ns | 33.33 ns |   912.7 ns | 1.31x slower |   0.03x | 0.1297 |     272 B |  3.38x less |
|                          |          |       |            |          |          |            |              |         |        |           |             |
|              ForeachLoop | .NET 8.0 |   100 |   311.7 ns |  7.42 ns | 20.94 ns |   301.3 ns |     baseline |         | 0.4396 |     920 B |             |
|                     Linq | .NET 8.0 |   100 |   481.7 ns |  9.66 ns | 12.90 ns |   481.3 ns | 1.53x slower |   0.10x | 0.4015 |     840 B |  1.10x less |
|                   LinqAF | .NET 8.0 |   100 |   523.7 ns |  6.92 ns |  6.13 ns |   522.3 ns | 1.70x slower |   0.14x | 0.4244 |     888 B |  1.04x less |
|               StructLinq | .NET 8.0 |   100 |   479.5 ns |  2.64 ns |  2.20 ns |   479.2 ns | 1.57x slower |   0.11x | 0.1717 |     360 B |  2.56x less |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   426.2 ns |  9.98 ns | 28.95 ns |   421.6 ns | 1.37x slower |   0.13x | 0.1297 |     272 B |  3.38x less |
|                Hyperlinq | .NET 8.0 |   100 |   519.1 ns |  2.85 ns |  2.23 ns |   519.1 ns | 1.69x slower |   0.12x | 0.1297 |     272 B |  3.38x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   483.1 ns |  9.33 ns | 26.61 ns |   472.5 ns | 1.56x slower |   0.12x | 0.1297 |     272 B |  3.38x less |

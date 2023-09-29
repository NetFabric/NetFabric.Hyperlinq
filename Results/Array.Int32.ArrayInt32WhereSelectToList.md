## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                   Method |  Runtime | Count |     Mean |    Error |   StdDev |   Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|---------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 | 234.1 ns |  3.41 ns |  2.85 ns | 232.8 ns |     baseline |         | 0.3095 |     648 B |             |
|              ForeachLoop | .NET 6.0 |   100 | 248.1 ns |  4.91 ns |  7.19 ns | 249.0 ns | 1.04x slower |   0.04x | 0.3095 |     648 B |  1.00x more |
|                     Linq | .NET 6.0 |   100 | 458.7 ns |  3.75 ns |  3.32 ns | 457.5 ns | 1.96x slower |   0.03x | 0.3595 |     752 B |  1.16x more |
|               LinqFaster | .NET 6.0 |   100 | 374.1 ns |  7.50 ns | 17.53 ns | 365.3 ns | 1.57x slower |   0.05x | 0.4473 |     936 B |  1.44x more |
|             LinqFasterer | .NET 6.0 |   100 | 543.4 ns |  4.90 ns |  4.09 ns | 542.5 ns | 2.32x slower |   0.03x | 0.6113 |    1280 B |  1.98x more |
|                   LinqAF | .NET 6.0 |   100 | 754.8 ns | 14.48 ns | 11.30 ns | 759.2 ns | 3.22x slower |   0.07x | 0.3090 |     648 B |  1.00x more |
|                 SpanLinq | .NET 6.0 |   100 | 526.2 ns | 10.51 ns | 21.47 ns | 517.3 ns | 2.27x slower |   0.07x | 0.3090 |     648 B |  1.00x more |
|               StructLinq | .NET 6.0 |   100 | 554.3 ns | 10.00 ns | 16.98 ns | 555.8 ns | 2.35x slower |   0.11x | 0.1755 |     368 B |  1.76x less |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 309.6 ns |  2.10 ns |  1.75 ns | 309.7 ns | 1.32x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
|                Hyperlinq | .NET 6.0 |   100 | 625.9 ns | 12.43 ns | 17.43 ns | 627.1 ns | 2.65x slower |   0.12x | 0.1297 |     272 B |  2.38x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 387.7 ns |  3.54 ns |  3.13 ns | 386.7 ns | 1.66x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
|                  Faslinq | .NET 6.0 |   100 | 442.2 ns |  4.68 ns |  3.91 ns | 441.3 ns | 1.89x slower |   0.03x | 0.4206 |     880 B |  1.36x more |
|                          |          |       |          |          |          |          |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 | 235.5 ns |  1.90 ns |  1.69 ns | 235.2 ns |     baseline |         | 0.3095 |     648 B |             |
|              ForeachLoop | .NET 8.0 |   100 | 255.6 ns |  5.20 ns |  5.10 ns | 257.6 ns | 1.08x slower |   0.03x | 0.3095 |     648 B |  1.00x more |
|                     Linq | .NET 8.0 |   100 | 347.1 ns |  7.02 ns | 19.09 ns | 342.1 ns | 1.49x slower |   0.08x | 0.3595 |     752 B |  1.16x more |
|               LinqFaster | .NET 8.0 |   100 | 238.5 ns |  4.70 ns |  5.77 ns | 236.8 ns | 1.02x slower |   0.03x | 0.4473 |     936 B |  1.44x more |
|             LinqFasterer | .NET 8.0 |   100 | 358.1 ns |  5.42 ns |  4.23 ns | 357.0 ns | 1.52x slower |   0.02x | 0.6118 |    1280 B |  1.98x more |
|                   LinqAF | .NET 8.0 |   100 | 443.4 ns | 11.00 ns | 31.38 ns | 441.1 ns | 1.88x slower |   0.19x | 0.3095 |     648 B |  1.00x more |
|                 SpanLinq | .NET 8.0 |   100 | 287.2 ns |  5.04 ns | 11.57 ns | 282.5 ns | 1.24x slower |   0.07x | 0.3095 |     648 B |  1.00x more |
|               StructLinq | .NET 8.0 |   100 | 412.3 ns | 10.97 ns | 32.01 ns | 408.2 ns | 1.78x slower |   0.18x | 0.1760 |     368 B |  1.76x less |
| StructLinq_ValueDelegate | .NET 8.0 |   100 | 310.8 ns |  6.90 ns | 19.92 ns | 307.4 ns | 1.32x slower |   0.09x | 0.1297 |     272 B |  2.38x less |
|                Hyperlinq | .NET 8.0 |   100 | 375.7 ns |  8.64 ns | 24.78 ns | 372.9 ns | 1.59x slower |   0.09x | 0.1297 |     272 B |  2.38x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 | 299.7 ns |  3.29 ns |  3.23 ns | 300.0 ns | 1.28x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
|                  Faslinq | .NET 8.0 |   100 | 238.2 ns |  4.53 ns |  4.65 ns | 237.2 ns | 1.01x slower |   0.02x | 0.4206 |     880 B |  1.36x more |

## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                  ForLoop | .NET 6.0 |   100 |   270.2 ns |  4.50 ns |  3.51 ns |   269.2 ns |     baseline |         | 0.4244 |     888 B |             |
|              ForeachLoop | .NET 6.0 |   100 |   272.4 ns |  2.62 ns |  2.57 ns |   272.5 ns | 1.01x slower |   0.02x | 0.4244 |     888 B |  1.00x more |
|                     Linq | .NET 6.0 |   100 |   509.5 ns | 10.19 ns | 10.01 ns |   506.0 ns | 1.89x slower |   0.05x | 0.4015 |     840 B |  1.06x less |
|               LinqFaster | .NET 6.0 |   100 |   455.0 ns |  2.22 ns |  1.85 ns |   455.1 ns | 1.68x slower |   0.02x | 0.4244 |     888 B |  1.00x more |
|             LinqFasterer | .NET 6.0 |   100 |   462.2 ns |  6.31 ns |  6.48 ns |   461.0 ns | 1.71x slower |   0.02x | 0.4320 |     904 B |  1.02x more |
|                   LinqAF | .NET 6.0 |   100 | 1,181.9 ns |  8.89 ns |  6.94 ns | 1,181.3 ns | 4.38x slower |   0.07x | 0.4082 |     856 B |  1.04x less |
|               StructLinq | .NET 6.0 |   100 |   499.6 ns |  6.80 ns |  5.31 ns |   497.4 ns | 1.85x slower |   0.03x | 0.1602 |     336 B |  2.64x less |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |   286.7 ns |  2.37 ns |  2.10 ns |   286.3 ns | 1.06x slower |   0.01x | 0.1144 |     240 B |  3.70x less |
|                Hyperlinq | .NET 6.0 |   100 |   550.8 ns |  2.80 ns |  2.48 ns |   550.6 ns | 2.04x slower |   0.03x | 0.1144 |     240 B |  3.70x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 |   346.1 ns |  6.97 ns |  5.44 ns |   344.2 ns | 1.28x slower |   0.01x | 0.1144 |     240 B |  3.70x less |
|                  Faslinq | .NET 6.0 |   100 |   473.0 ns |  9.22 ns | 12.30 ns |   469.3 ns | 1.73x slower |   0.02x | 0.4244 |     888 B |  1.00x more |
|                          |          |       |            |          |          |            |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   297.4 ns |  2.42 ns |  2.15 ns |   296.4 ns |     baseline |         | 0.4244 |     888 B |             |
|              ForeachLoop | .NET 8.0 |   100 |   303.5 ns |  1.36 ns |  1.06 ns |   303.2 ns | 1.02x slower |   0.01x | 0.4244 |     888 B |  1.00x more |
|                     Linq | .NET 8.0 |   100 |   337.2 ns |  3.06 ns |  2.56 ns |   336.6 ns | 1.13x slower |   0.01x | 0.4015 |     840 B |  1.06x less |
|               LinqFaster | .NET 8.0 |   100 |   287.0 ns |  5.81 ns | 13.01 ns |   281.4 ns | 1.03x faster |   0.04x | 0.4244 |     888 B |  1.00x more |
|             LinqFasterer | .NET 8.0 |   100 |   256.0 ns |  2.50 ns |  1.95 ns |   255.6 ns | 1.16x faster |   0.01x | 0.4320 |     904 B |  1.02x more |
|                   LinqAF | .NET 8.0 |   100 |   464.4 ns |  9.18 ns | 19.57 ns |   454.4 ns | 1.57x slower |   0.07x | 0.4091 |     856 B |  1.04x less |
|               StructLinq | .NET 8.0 |   100 |   396.1 ns |  4.45 ns |  3.47 ns |   395.0 ns | 1.33x slower |   0.01x | 0.1602 |     336 B |  2.64x less |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   249.0 ns |  3.10 ns |  3.57 ns |   247.5 ns | 1.19x faster |   0.02x | 0.1144 |     240 B |  3.70x less |
|                Hyperlinq | .NET 8.0 |   100 |   323.3 ns |  5.33 ns |  4.16 ns |   321.7 ns | 1.09x slower |   0.01x | 0.1144 |     240 B |  3.70x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   284.5 ns |  1.58 ns |  1.24 ns |   284.1 ns | 1.04x faster |   0.01x | 0.1144 |     240 B |  3.70x less |
|                  Faslinq | .NET 8.0 |   100 |   389.6 ns |  7.50 ns | 12.33 ns |   384.6 ns | 1.31x slower |   0.04x | 0.4244 |     888 B |  1.00x more |

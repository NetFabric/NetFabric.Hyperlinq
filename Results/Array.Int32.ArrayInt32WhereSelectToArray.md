## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                  ForLoop | .NET 6.0 |   100 | 256.9 ns |  3.33 ns |  2.95 ns | 256.6 ns |     baseline |         | 0.4244 |     888 B |             |
|              ForeachLoop | .NET 6.0 |   100 | 254.8 ns |  3.13 ns |  2.93 ns | 254.9 ns | 1.01x faster |   0.02x | 0.4244 |     888 B |  1.00x more |
|                     Linq | .NET 6.0 |   100 | 547.1 ns |  3.38 ns |  2.83 ns | 547.5 ns | 2.13x slower |   0.02x | 0.3786 |     792 B |  1.12x less |
|               LinqFaster | .NET 6.0 |   100 | 365.6 ns |  7.35 ns |  9.02 ns | 361.5 ns | 1.43x slower |   0.05x | 0.3171 |     664 B |  1.34x less |
|             LinqFasterer | .NET 6.0 |   100 | 475.3 ns |  4.01 ns |  3.35 ns | 475.0 ns | 1.85x slower |   0.02x | 0.3977 |     832 B |  1.07x less |
|                   LinqAF | .NET 6.0 |   100 | 757.9 ns | 14.95 ns | 25.39 ns | 766.9 ns | 3.03x slower |   0.07x | 0.4091 |     856 B |  1.04x less |
|                 SpanLinq | .NET 6.0 |   100 | 594.6 ns | 11.61 ns | 17.02 ns | 597.8 ns | 2.29x slower |   0.10x | 0.4244 |     888 B |  1.00x more |
|               StructLinq | .NET 6.0 |   100 | 500.8 ns |  2.15 ns |  2.01 ns | 501.1 ns | 1.95x slower |   0.03x | 0.1602 |     336 B |  2.64x less |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 337.7 ns |  7.83 ns | 21.83 ns | 332.9 ns | 1.19x slower |   0.10x | 0.1144 |     240 B |  3.70x less |
|                Hyperlinq | .NET 6.0 |   100 | 558.0 ns |  9.89 ns | 12.14 ns | 553.1 ns | 2.18x slower |   0.07x | 0.1144 |     240 B |  3.70x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 381.6 ns |  4.36 ns |  4.29 ns | 380.3 ns | 1.48x slower |   0.02x | 0.1144 |     240 B |  3.70x less |
|                  Faslinq | .NET 6.0 |   100 | 318.3 ns |  6.27 ns |  5.23 ns | 316.1 ns | 1.24x slower |   0.02x | 0.2027 |     424 B |  2.09x less |
|                          |          |       |          |          |          |          |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 | 251.8 ns |  5.54 ns | 15.53 ns | 243.7 ns |     baseline |         | 0.4244 |     888 B |             |
|              ForeachLoop | .NET 8.0 |   100 | 239.2 ns |  1.58 ns |  1.32 ns | 238.7 ns | 1.04x faster |   0.06x | 0.4244 |     888 B |  1.00x more |
|                     Linq | .NET 8.0 |   100 | 351.7 ns |  5.01 ns |  4.18 ns | 350.8 ns | 1.42x slower |   0.07x | 0.3786 |     792 B |  1.12x less |
|               LinqFaster | .NET 8.0 |   100 | 196.8 ns |  3.16 ns |  3.64 ns | 195.8 ns | 1.29x faster |   0.07x | 0.3173 |     664 B |  1.34x less |
|             LinqFasterer | .NET 8.0 |   100 | 335.7 ns |  6.55 ns |  7.54 ns | 334.8 ns | 1.33x slower |   0.08x | 0.3977 |     832 B |  1.07x less |
|                   LinqAF | .NET 8.0 |   100 | 370.6 ns |  7.41 ns |  6.18 ns | 369.8 ns | 1.50x slower |   0.07x | 0.4091 |     856 B |  1.04x less |
|                 SpanLinq | .NET 8.0 |   100 | 321.8 ns |  5.15 ns |  6.88 ns | 321.6 ns | 1.25x slower |   0.10x | 0.4244 |     888 B |  1.00x more |
|               StructLinq | .NET 8.0 |   100 | 392.1 ns |  7.73 ns | 17.76 ns | 388.0 ns | 1.54x slower |   0.11x | 0.1602 |     336 B |  2.64x less |
| StructLinq_ValueDelegate | .NET 8.0 |   100 | 305.2 ns |  5.74 ns |  5.09 ns | 305.4 ns | 1.24x slower |   0.07x | 0.1144 |     240 B |  3.70x less |
|                Hyperlinq | .NET 8.0 |   100 | 353.1 ns |  3.52 ns |  2.94 ns | 351.8 ns | 1.43x slower |   0.06x | 0.1144 |     240 B |  3.70x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 | 285.7 ns |  2.28 ns |  2.02 ns | 284.9 ns | 1.16x slower |   0.05x | 0.1144 |     240 B |  3.70x less |
|                  Faslinq | .NET 8.0 |   100 | 187.3 ns |  4.44 ns | 12.74 ns | 181.2 ns | 1.35x faster |   0.12x | 0.2027 |     424 B |  2.09x less |

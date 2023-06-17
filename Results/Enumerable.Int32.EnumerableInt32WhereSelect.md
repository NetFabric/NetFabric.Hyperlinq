## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-preview.5.23303.2
  [Host] : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 6 : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 8 : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2


```
|                   Method |    Job |  Runtime | Count |       Mean |    Error |   StdDev |     Median |        Ratio | RatioSD |   Gen0 | Allocated |  Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|---------:|---------:|-----------:|-------------:|--------:|-------:|----------:|-------------:|
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   445.3 ns |  5.62 ns |  4.69 ns |   445.7 ns |     baseline |         | 0.0191 |      40 B |              |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,165.4 ns | 18.14 ns | 14.16 ns | 1,163.5 ns | 2.62x slower |   0.04x | 0.0763 |     160 B |   4.00x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 1,102.9 ns |  7.58 ns |  6.33 ns | 1,100.2 ns | 2.48x slower |   0.03x | 0.0191 |      40 B |   1.00x more |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,920.9 ns | 29.00 ns | 24.22 ns | 1,925.6 ns | 4.31x slower |   0.08x | 4.2534 |    8906 B | 222.65x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 2,069.6 ns | 15.47 ns | 13.72 ns | 2,066.9 ns | 4.64x slower |   0.06x | 0.3548 |     744 B |  18.60x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   985.1 ns | 13.13 ns | 10.97 ns |   980.0 ns | 2.21x slower |   0.03x | 0.0458 |      96 B |   2.40x more |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   636.9 ns |  4.34 ns |  3.38 ns |   637.5 ns | 1.43x slower |   0.01x | 0.0191 |      40 B |   1.00x more |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   860.4 ns |  5.26 ns |  4.39 ns |   859.6 ns | 1.93x slower |   0.02x | 0.0191 |      40 B |   1.00x more |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   621.0 ns | 11.83 ns | 10.49 ns |   616.5 ns | 1.40x slower |   0.02x | 0.0191 |      40 B |   1.00x more |
|                          |        |          |       |            |          |          |            |              |         |        |           |              |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   223.5 ns |  1.67 ns |  1.86 ns |   223.0 ns |     baseline |         | 0.0191 |      40 B |              |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   454.6 ns |  3.57 ns |  3.16 ns |   454.1 ns | 2.03x slower |   0.02x | 0.0763 |     160 B |   4.00x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   393.8 ns |  7.52 ns | 13.37 ns |   387.7 ns | 1.76x slower |   0.06x | 0.0191 |      40 B |   1.00x more |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,517.4 ns | 20.18 ns | 17.89 ns | 1,519.2 ns | 6.78x slower |   0.12x | 4.2534 |    8905 B | 222.62x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,514.3 ns | 34.52 ns | 99.03 ns | 1,463.6 ns | 6.94x slower |   0.51x | 0.3548 |     744 B |  18.60x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   403.1 ns |  7.58 ns |  9.86 ns |   399.2 ns | 1.81x slower |   0.05x | 0.0458 |      96 B |   2.40x more |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   275.0 ns |  1.60 ns |  1.42 ns |   275.0 ns | 1.23x slower |   0.01x | 0.0191 |      40 B |   1.00x more |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   361.3 ns |  7.08 ns |  5.91 ns |   359.4 ns | 1.61x slower |   0.03x | 0.0191 |      40 B |   1.00x more |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   260.8 ns |  1.38 ns |  1.36 ns |   260.4 ns | 1.17x slower |   0.01x | 0.0191 |      40 B |   1.00x more |

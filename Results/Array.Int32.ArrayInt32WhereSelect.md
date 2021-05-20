## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     70.78 ns |   0.491 ns |   0.435 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |     70.77 ns |   1.152 ns |   1.077 ns |   1.00x faster |   0.02x |       - |     - |     - |         - |
|                     Linq |   100 |    556.90 ns |   6.662 ns |   5.906 ns |   7.87x slower |   0.07x |  0.0496 |     - |     - |     104 B |
|               LinqFaster |   100 |    418.29 ns |   3.310 ns |   2.934 ns |   5.91x slower |   0.05x |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    700.66 ns |   5.219 ns |   4.627 ns |   9.90x slower |   0.09x |  0.4129 |     - |     - |     864 B |
|                   LinqAF |   100 |    464.00 ns |   5.160 ns |   4.574 ns |   6.56x slower |   0.06x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 45,953.55 ns | 567.377 ns | 530.725 ns | 649.01x slower |   6.00x | 14.2212 |     - |     - |  29,776 B |
|                 SpanLinq |   100 |    425.42 ns |   5.480 ns |   4.858 ns |   6.01x slower |   0.09x |       - |     - |     - |         - |
|                  Streams |   100 |  1,579.13 ns |   8.071 ns |   6.739 ns |  22.31x slower |   0.17x |  0.3510 |     - |     - |     736 B |
|               StructLinq |   100 |    341.44 ns |   1.806 ns |   1.508 ns |   4.82x slower |   0.04x |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    189.90 ns |   1.116 ns |   1.044 ns |   2.68x slower |   0.02x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    346.13 ns |   4.554 ns |   4.037 ns |   4.89x slower |   0.06x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    238.78 ns |   0.906 ns |   0.848 ns |   3.37x slower |   0.02x |       - |     - |     - |         - |

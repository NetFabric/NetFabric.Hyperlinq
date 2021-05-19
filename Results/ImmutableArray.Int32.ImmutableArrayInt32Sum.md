## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     45.51 ns |   0.130 ns |   0.115 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |     46.11 ns |   0.139 ns |   0.116 ns |   1.01 |    0.00 |      - |     - |     - |         - |
|                     Linq |   100 |    389.40 ns |   2.074 ns |   1.940 ns |   8.56 |    0.05 | 0.0267 |     - |     - |      56 B |
|             LinqFasterer |   100 |    110.24 ns |   1.129 ns |   1.001 ns |   2.42 |    0.02 | 0.2141 |     - |     - |     448 B |
|            LinqOptimizer |   100 | 25,297.14 ns | 192.955 ns | 150.646 ns | 555.96 |    3.17 | 8.3008 |     - |     - |  17,414 B |
|                  Streams |   100 |    592.45 ns |   4.586 ns |   4.289 ns |  13.03 |    0.09 | 0.1259 |     - |     - |     264 B |
|               StructLinq |   100 |    144.47 ns |   0.483 ns |   0.428 ns |   3.17 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     66.09 ns |   0.380 ns |   0.337 ns |   1.45 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |   100 |     20.86 ns |   0.182 ns |   0.243 ns |   0.46 |    0.01 |      - |     - |     - |         - |

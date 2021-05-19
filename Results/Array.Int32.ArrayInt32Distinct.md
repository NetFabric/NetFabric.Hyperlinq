## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|                   Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 3.451 μs | 0.0113 μs | 0.0100 μs |  1.00 | 2.8648 |     - |     - |   6,000 B |
|              ForeachLoop |          4 |   100 | 3.397 μs | 0.0129 μs | 0.0120 μs |  0.98 | 2.8648 |     - |     - |   6,000 B |
|                     Linq |          4 |   100 | 4.193 μs | 0.0305 μs | 0.0270 μs |  1.22 | 2.8610 |     - |     - |   5,992 B |
|             LinqFasterer |          4 |   100 | 4.035 μs | 0.0371 μs | 0.0347 μs |  1.17 | 4.4174 |     - |     - |   9,272 B |
|                   LinqAF |          4 |   100 | 8.178 μs | 0.0361 μs | 0.0338 μs |  2.37 | 5.9204 |     - |     - |  12,400 B |
|               StructLinq |          4 |   100 | 3.513 μs | 0.0141 μs | 0.0125 μs |  1.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |          4 |   100 | 3.358 μs | 0.0161 μs | 0.0143 μs |  0.97 |      - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 3.648 μs | 0.0164 μs | 0.0128 μs |  1.06 |      - |     - |     - |         - |

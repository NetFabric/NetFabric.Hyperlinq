## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 464.8 ns | 0.99 ns | 0.93 ns |  1.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 | 467.0 ns | 1.83 ns | 1.71 ns |  1.00 |      - |     - |     - |         - |
|                     Linq |   100 | 173.9 ns | 1.05 ns | 0.82 ns |  0.37 |      - |     - |     - |         - |
|               LinqFaster |   100 | 177.7 ns | 1.41 ns | 1.25 ns |  0.38 |      - |     - |     - |         - |
|             LinqFasterer |   100 | 200.5 ns | 0.91 ns | 0.81 ns |  0.43 |      - |     - |     - |         - |
|                   LinqAF |   100 | 202.5 ns | 1.76 ns | 1.56 ns |  0.44 |      - |     - |     - |         - |
|               StructLinq |   100 | 517.1 ns | 3.01 ns | 2.82 ns |  1.11 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 503.0 ns | 2.45 ns | 2.29 ns |  1.08 |      - |     - |     - |         - |
|                Hyperlinq |   100 | 198.8 ns | 1.09 ns | 0.85 ns |  0.43 |      - |     - |     - |         - |

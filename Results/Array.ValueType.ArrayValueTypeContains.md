## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|                   Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |   453.1 ns | 0.87 ns | 0.73 ns |  1.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |   458.2 ns | 1.13 ns | 0.94 ns |  1.01 |      - |     - |     - |         - |
|                     Linq |   100 |   171.0 ns | 1.01 ns | 0.90 ns |  0.38 |      - |     - |     - |         - |
|               LinqFaster |   100 |   177.0 ns | 0.78 ns | 0.65 ns |  0.39 |      - |     - |     - |         - |
|             LinqFasterer |   100 |   174.0 ns | 0.59 ns | 0.52 ns |  0.38 |      - |     - |     - |         - |
|                   LinqAF |   100 |   199.9 ns | 1.26 ns | 1.11 ns |  0.44 |      - |     - |     - |         - |
|               StructLinq |   100 |   516.3 ns | 4.93 ns | 4.37 ns |  1.14 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 1,472.6 ns | 2.74 ns | 2.56 ns |  3.25 |      - |     - |     - |         - |
|                Hyperlinq |   100 |   175.6 ns | 0.70 ns | 0.58 ns |  0.39 |      - |     - |     - |         - |

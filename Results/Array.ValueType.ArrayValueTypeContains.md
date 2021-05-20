## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|                   Method | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|--------:|--------:|-------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 471.2 ns | 3.18 ns | 2.97 ns |     baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 | 472.7 ns | 1.81 ns | 1.69 ns | 1.00x slower |   0.01x |      - |     - |     - |         - |
|                     Linq |   100 | 201.8 ns | 1.49 ns | 1.24 ns | 2.33x faster |   0.03x |      - |     - |     - |         - |
|               LinqFaster |   100 | 185.0 ns | 1.06 ns | 0.94 ns | 2.55x faster |   0.02x |      - |     - |     - |         - |
|             LinqFasterer |   100 | 181.4 ns | 1.44 ns | 1.28 ns | 2.60x faster |   0.02x |      - |     - |     - |         - |
|                   LinqAF |   100 | 206.8 ns | 1.72 ns | 2.12 ns | 2.27x faster |   0.02x |      - |     - |     - |         - |
|               StructLinq |   100 | 531.1 ns | 5.80 ns | 5.42 ns | 1.13x slower |   0.01x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 513.1 ns | 4.84 ns | 4.29 ns | 1.09x slower |   0.01x |      - |     - |     - |         - |
|                Hyperlinq |   100 | 186.4 ns | 1.49 ns | 1.32 ns | 2.53x faster |   0.02x |      - |     - |     - |         - |

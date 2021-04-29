## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
|                   Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 45.44 ns | 0.159 ns | 0.133 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 | 46.09 ns | 0.136 ns | 0.127 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|                     Linq |   100 | 35.79 ns | 0.484 ns | 0.452 ns |  0.79 |    0.01 |      - |     - |     - |         - |
|             LinqFasterer |   100 | 83.39 ns | 0.656 ns | 0.613 ns |  1.84 |    0.02 | 0.2142 |     - |     - |     448 B |
|               StructLinq |   100 | 95.11 ns | 0.573 ns | 0.536 ns |  2.10 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 59.84 ns | 0.215 ns | 0.201 ns |  1.32 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |   100 | 34.29 ns | 0.154 ns | 0.144 ns |  0.75 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 | 22.37 ns | 0.115 ns | 0.108 ns |  0.49 |    0.00 |      - |     - |     - |         - |

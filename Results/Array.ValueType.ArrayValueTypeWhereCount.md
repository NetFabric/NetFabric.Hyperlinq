## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     68.89 ns |   0.431 ns |   0.382 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |    151.51 ns |   0.654 ns |   0.579 ns |   2.20 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    569.47 ns |   7.300 ns |   6.472 ns |   8.27 |    0.12 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    275.66 ns |   0.917 ns |   0.813 ns |   4.00 |    0.02 |      - |     - |     - |         - |
|             LinqFasterer |   100 |    223.64 ns |   1.347 ns |   1.194 ns |   3.25 |    0.02 |      - |     - |     - |         - |
|                   LinqAF |   100 |    679.15 ns |  13.561 ns |  17.633 ns |   9.86 |    0.27 |      - |     - |     - |         - |
|               StructLinq |   100 |    351.42 ns |   3.805 ns |   3.559 ns |   5.10 |    0.07 | 0.0305 |     - |     - |      64 B |
|            LinqOptimizer |   100 | 29,077.03 ns | 197.890 ns | 165.247 ns | 422.38 |    3.24 | 9.1553 |     - |     - |  19,185 B |
|                  Streams |   100 |    719.62 ns |  14.177 ns |  16.877 ns |  10.42 |    0.27 | 0.1717 |     - |     - |     360 B |
| StructLinq_ValueDelegate |   100 |    181.06 ns |   0.449 ns |   0.375 ns |   2.63 |    0.02 |      - |     - |     - |         - |
|                Hyperlinq |   100 |    488.18 ns |   0.906 ns |   0.757 ns |   7.09 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    341.21 ns |   1.020 ns |   0.954 ns |   4.95 |    0.04 |      - |     - |     - |         - |

## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
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
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    284.2 ns |   2.07 ns |   1.94 ns |    284.2 ns |   1.00 |    0.00 |  0.4244 |     - |     - |     888 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    243.2 ns |   1.34 ns |   1.12 ns |    243.4 ns |   0.86 |    0.01 |  0.4244 |     - |     - |     888 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    522.6 ns |   3.04 ns |   2.85 ns |    522.2 ns |   1.84 |    0.02 |  0.3786 |     - |     - |     792 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    406.4 ns |   7.76 ns |   6.48 ns |    408.0 ns |   1.43 |    0.02 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    716.2 ns |   5.40 ns |   4.78 ns |    715.8 ns |   2.52 |    0.03 |  0.4091 |     - |     - |     856 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 51,628.3 ns | 458.14 ns | 428.55 ns | 51,762.6 ns | 181.68 |    1.89 | 14.6484 |     - |     - |  30,786 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,015.9 ns |  20.03 ns |  34.54 ns |  1,034.5 ns |   3.46 |    0.12 |  0.6695 |     - |     - |   1,400 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    531.6 ns |   3.77 ns |   3.53 ns |    530.5 ns |   1.87 |    0.02 |  0.1602 |     - |     - |     336 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    300.6 ns |   1.83 ns |   1.62 ns |    300.4 ns |   1.06 |    0.01 |  0.1144 |     - |     - |     240 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    611.8 ns |   3.37 ns |   2.99 ns |    611.6 ns |   2.15 |    0.02 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    336.5 ns |   3.02 ns |   2.82 ns |    334.8 ns |   1.18 |    0.01 |  0.1144 |     - |     - |     240 B |
|                      |        |                                                                        |          |       |             |           |           |             |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    231.8 ns |   3.24 ns |   2.70 ns |    231.1 ns |   1.00 |    0.00 |  0.4246 |     - |     - |     888 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    240.9 ns |   3.46 ns |   3.23 ns |    239.1 ns |   1.04 |    0.01 |  0.4244 |     - |     - |     888 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    604.8 ns |  11.44 ns |  11.23 ns |    606.3 ns |   2.61 |    0.06 |  0.3786 |     - |     - |     792 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    410.7 ns |   1.84 ns |   1.54 ns |    410.7 ns |   1.77 |    0.02 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    668.7 ns |  13.15 ns |  19.68 ns |    677.4 ns |   2.83 |    0.11 |  0.4091 |     - |     - |     856 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 44,755.8 ns | 464.68 ns | 434.66 ns | 44,713.7 ns | 193.15 |    3.51 | 14.5264 |     - |     - |  30,496 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    987.7 ns |   8.90 ns |   7.89 ns |    986.0 ns |   4.26 |    0.07 |  0.6695 |     - |     - |   1,400 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    565.4 ns |  11.30 ns |  13.45 ns |    570.8 ns |   2.41 |    0.07 |  0.1602 |     - |     - |     336 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    314.8 ns |   6.30 ns |   8.41 ns |    310.4 ns |   1.37 |    0.04 |  0.1144 |     - |     - |     240 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    571.8 ns |   5.83 ns |   4.87 ns |    570.4 ns |   2.47 |    0.03 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    359.7 ns |   7.23 ns |  11.88 ns |    365.2 ns |   1.50 |    0.06 |  0.1144 |     - |     - |     240 B |

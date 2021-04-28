## Enumerable.FatReferenceType.EnumerableFatReferenceTypeAny

### Source
[EnumerableFatReferenceTypeAny.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeAny.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |     Mean |    Error |   StdDev |   Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |---------:|---------:|---------:|---------:|-------:|------:|------:|----------:|
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 29.63 ns | 0.621 ns | 1.071 ns | 30.09 ns | 0.0229 |     - |     - |      48 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 38.11 ns | 0.196 ns | 0.183 ns | 38.09 ns | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 23.44 ns | 0.502 ns | 1.123 ns | 22.71 ns | 0.0344 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 22.09 ns | 0.176 ns | 0.156 ns | 22.13 ns | 0.0344 |     - |     - |      72 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 25.23 ns | 0.531 ns | 1.144 ns | 24.42 ns | 0.0229 |     - |     - |      48 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 22.19 ns | 0.508 ns | 1.348 ns | 21.38 ns | 0.0229 |     - |     - |      48 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 33.17 ns | 0.453 ns | 0.424 ns | 32.99 ns | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 17.36 ns | 0.295 ns | 0.276 ns | 17.25 ns | 0.0344 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 16.69 ns | 0.190 ns | 0.168 ns | 16.67 ns | 0.0344 |     - |     - |      72 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 16.51 ns | 0.127 ns | 0.119 ns | 16.53 ns | 0.0229 |     - |     - |      48 B |

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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |     Mean |    Error |   StdDev |   Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |---------:|---------:|---------:|---------:|-------:|------:|------:|----------:|
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 30.96 ns | 0.235 ns | 0.208 ns | 30.91 ns | 0.0229 |     - |     - |      48 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 38.53 ns | 0.200 ns | 0.167 ns | 38.47 ns | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 22.40 ns | 0.116 ns | 0.090 ns | 22.42 ns | 0.0344 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 24.76 ns | 0.524 ns | 1.138 ns | 24.04 ns | 0.0344 |     - |     - |      72 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 22.37 ns | 0.058 ns | 0.048 ns | 22.36 ns | 0.0229 |     - |     - |      48 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 23.16 ns | 0.107 ns | 0.100 ns | 23.17 ns | 0.0229 |     - |     - |      48 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 30.73 ns | 0.162 ns | 0.152 ns | 30.68 ns | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 16.61 ns | 0.095 ns | 0.074 ns | 16.62 ns | 0.0344 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 16.05 ns | 0.308 ns | 0.257 ns | 15.98 ns | 0.0344 |     - |     - |      72 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 16.33 ns | 0.159 ns | 0.279 ns | 16.25 ns | 0.0229 |     - |     - |      48 B |

## Enumerable.FatReferenceType.EnumerableFatReferenceTypeFirstOrDefault

### Source
[EnumerableFatReferenceTypeFirstOrDefault.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeFirstOrDefault.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |     Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |---------:|---------:|---------:|-------:|------:|------:|----------:|
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 33.22 ns | 0.195 ns | 0.173 ns | 0.0229 |     - |     - |      48 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 41.45 ns | 0.202 ns | 0.179 ns | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 27.12 ns | 0.139 ns | 0.123 ns | 0.0344 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 18.99 ns | 0.111 ns | 0.104 ns | 0.0229 |     - |     - |      48 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 41.55 ns | 0.229 ns | 0.191 ns | 0.0344 |     - |     - |      72 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 19.82 ns | 0.127 ns | 0.106 ns | 0.0229 |     - |     - |      48 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 37.65 ns | 0.225 ns | 0.210 ns | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 16.19 ns | 0.158 ns | 0.300 ns | 0.0344 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 12.60 ns | 0.167 ns | 0.148 ns | 0.0229 |     - |     - |      48 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 27.78 ns | 0.261 ns | 0.232 ns | 0.0344 |     - |     - |      72 B |

## Enumerable.FatReferenceType.EnumerableFatReferenceTypeFirstOrDefault

### Source
[EnumerableFatReferenceTypeFirstOrDefault.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeFirstOrDefault.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19042.867 (20H2/October2020Update)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Count |     Mean |    Error |   StdDev |   Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |---------:|---------:|---------:|---------:|-------:|------:|------:|----------:|
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 42.18 ns | 1.085 ns | 3.131 ns | 41.28 ns | 0.0153 |     - |     - |      48 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 63.63 ns | 1.267 ns | 3.337 ns | 63.19 ns | 0.0153 |     - |     - |      48 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 37.91 ns | 0.847 ns | 2.275 ns | 37.46 ns | 0.0229 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 27.64 ns | 0.640 ns | 1.825 ns | 27.21 ns | 0.0153 |     - |     - |      48 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 54.89 ns | 1.181 ns | 3.005 ns | 54.34 ns | 0.0229 |     - |     - |      72 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 37.93 ns | 0.916 ns | 2.701 ns | 37.47 ns | 0.0153 |     - |     - |      48 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 50.40 ns | 1.169 ns | 3.336 ns | 49.71 ns | 0.0153 |     - |     - |      48 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 26.83 ns | 0.612 ns | 1.687 ns | 26.58 ns | 0.0229 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 17.57 ns | 0.522 ns | 1.521 ns | 17.13 ns | 0.0153 |     - |     - |      48 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 46.32 ns | 1.280 ns | 3.713 ns | 45.98 ns | 0.0229 |     - |     - |      72 B |

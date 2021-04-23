## Enumerable.FatReferenceType.EnumerableFatReferenceTypeAny

### Source
[EnumerableFatReferenceTypeAny.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeAny.cs)

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
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 44.35 ns | 0.802 ns | 0.750 ns | 44.15 ns | 0.0153 |     - |     - |      48 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 47.78 ns | 0.715 ns | 0.597 ns | 47.83 ns | 0.0153 |     - |     - |      48 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 37.51 ns | 1.563 ns | 4.608 ns | 36.90 ns | 0.0229 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 31.34 ns | 0.710 ns | 0.818 ns | 31.40 ns | 0.0229 |     - |     - |      72 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 35.25 ns | 0.890 ns | 2.610 ns | 35.30 ns | 0.0153 |     - |     - |      48 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 27.00 ns | 0.628 ns | 1.392 ns | 26.53 ns | 0.0153 |     - |     - |      48 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 47.87 ns | 1.480 ns | 4.362 ns | 47.90 ns | 0.0153 |     - |     - |      48 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 28.24 ns | 0.538 ns | 1.225 ns | 27.77 ns | 0.0229 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 26.21 ns | 0.532 ns | 0.498 ns | 26.05 ns | 0.0229 |     - |     - |      72 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 29.37 ns | 0.606 ns | 1.700 ns | 28.79 ns | 0.0153 |     - |     - |      48 B |

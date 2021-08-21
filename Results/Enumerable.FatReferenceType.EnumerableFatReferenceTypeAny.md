## Enumerable.FatReferenceType.EnumerableFatReferenceTypeAny

### Source
[EnumerableFatReferenceTypeAny.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeAny.cs)

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

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |     Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 | 14.26 ns | 0.018 ns | 0.016 ns |     baseline |         | 0.0229 |     - |     - |      48 B |
|                     Linq |   100 | 24.70 ns | 0.035 ns | 0.027 ns | 1.73x slower |   0.00x | 0.0229 |     - |     - |      48 B |
|                   LinqAF |   100 | 36.34 ns | 0.062 ns | 0.058 ns | 2.55x slower |   0.00x | 0.0229 |     - |     - |      48 B |
|               StructLinq |   100 | 25.01 ns | 0.512 ns | 0.454 ns | 1.75x slower |   0.03x | 0.0344 |     - |     - |      72 B |
| StructLinq_ValueDelegate |   100 | 24.32 ns | 0.038 ns | 0.034 ns | 1.71x slower |   0.00x | 0.0344 |     - |     - |      72 B |
|                Hyperlinq |   100 | 21.35 ns | 0.041 ns | 0.034 ns | 1.50x slower |   0.00x | 0.0229 |     - |     - |      48 B |

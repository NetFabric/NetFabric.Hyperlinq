## Enumerable.FatReferenceType.EnumerableFatReferenceTypeAny

### Source
[EnumerableFatReferenceTypeAny.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeAny.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |     Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 | 10.22 ns | 0.364 ns | 1.055 ns |  9.589 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
|                     Linq |   100 | 23.63 ns | 0.148 ns | 0.132 ns | 23.643 ns |  1.96 |    0.12 | 0.0229 |     - |     - |      48 B |
|                   LinqAF |   100 | 31.23 ns | 0.211 ns | 0.187 ns | 31.269 ns |  2.59 |    0.17 | 0.0229 |     - |     - |      48 B |
|               StructLinq |   100 | 15.90 ns | 0.378 ns | 1.114 ns | 15.331 ns |  1.57 |    0.17 | 0.0344 |     - |     - |      72 B |
| StructLinq_ValueDelegate |   100 | 16.31 ns | 0.523 ns | 1.526 ns | 16.057 ns |  1.60 |    0.16 | 0.0344 |     - |     - |      72 B |
|                Hyperlinq |   100 | 15.39 ns | 0.365 ns | 0.754 ns | 15.056 ns |  1.51 |    0.12 | 0.0229 |     - |     - |      48 B |

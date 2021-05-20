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

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |     Mean |    Error |   StdDev |   Median |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 | 11.16 ns | 0.509 ns | 1.501 ns | 10.24 ns |     baseline |         | 0.0229 |     - |     - |      48 B |
|                     Linq |   100 | 23.83 ns | 0.542 ns | 1.571 ns | 22.99 ns | 2.16x slower |   0.22x | 0.0229 |     - |     - |      48 B |
|                   LinqAF |   100 | 32.68 ns | 0.401 ns | 0.356 ns | 32.62 ns | 2.38x slower |   0.09x | 0.0229 |     - |     - |      48 B |
|               StructLinq |   100 | 17.63 ns | 0.160 ns | 0.133 ns | 17.65 ns | 1.28x slower |   0.04x | 0.0344 |     - |     - |      72 B |
| StructLinq_ValueDelegate |   100 | 16.48 ns | 0.576 ns | 1.697 ns | 15.53 ns | 1.48x slower |   0.08x | 0.0344 |     - |     - |      72 B |
|                Hyperlinq |   100 | 16.81 ns | 0.510 ns | 1.503 ns | 15.95 ns | 1.52x slower |   0.09x | 0.0229 |     - |     - |      48 B |

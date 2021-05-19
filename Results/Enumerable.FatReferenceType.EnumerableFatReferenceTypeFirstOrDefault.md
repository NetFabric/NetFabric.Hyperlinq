## Enumerable.FatReferenceType.EnumerableFatReferenceTypeFirstOrDefault

### Source
[EnumerableFatReferenceTypeFirstOrDefault.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeFirstOrDefault.cs)

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
|              ForeachLoop |   100 | 10.25 ns | 0.382 ns | 1.095 ns |  9.603 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
|                     Linq |   100 | 20.76 ns | 0.228 ns | 0.202 ns | 20.730 ns |  1.73 |    0.11 | 0.0229 |     - |     - |      48 B |
|                   LinqAF |   100 | 37.25 ns | 0.222 ns | 0.208 ns | 37.297 ns |  3.10 |    0.19 | 0.0229 |     - |     - |      48 B |
|               StructLinq |   100 | 20.37 ns | 0.219 ns | 0.194 ns | 20.323 ns |  1.70 |    0.09 | 0.0344 |     - |     - |      72 B |
| StructLinq_ValueDelegate |   100 | 11.35 ns | 0.138 ns | 0.122 ns | 11.364 ns |  0.95 |    0.06 | 0.0229 |     - |     - |      48 B |
|                Hyperlinq |   100 | 31.54 ns | 0.376 ns | 0.352 ns | 31.493 ns |  2.62 |    0.16 | 0.0344 |     - |     - |      72 B |

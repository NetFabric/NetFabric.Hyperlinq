## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
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
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                       Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                      ForLoop |     0 |   100 | 293.14 ns | 5.670 ns | 5.304 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
|                         Linq |     0 |   100 | 288.00 ns | 2.276 ns | 1.777 ns |  0.99 |    0.02 | 0.2599 |     - |     - |     544 B |
|                   LinqFaster |     0 |   100 | 324.45 ns | 2.029 ns | 1.898 ns |  1.11 |    0.02 | 0.6232 |     - |     - |   1,304 B |
|                       LinqAF |     0 |   100 | 697.78 ns | 4.591 ns | 4.295 ns |  2.38 |    0.05 | 0.5655 |     - |     - |   1,184 B |
|                   StructLinq |     0 |   100 | 247.97 ns | 3.262 ns | 2.724 ns |  0.85 |    0.02 | 0.2446 |     - |     - |     512 B |
|     StructLinq_ValueDelegate |     0 |   100 | 107.91 ns | 0.536 ns | 0.501 ns |  0.37 |    0.01 | 0.2180 |     - |     - |     456 B |
|                    Hyperlinq |     0 |   100 | 254.69 ns | 1.425 ns | 1.263 ns |  0.87 |    0.02 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 142.69 ns | 1.533 ns | 1.280 ns |  0.49 |    0.01 | 0.2179 |     - |     - |     456 B |
|               Hyperlinq_SIMD |     0 |   100 |  96.88 ns | 0.513 ns | 0.455 ns |  0.33 |    0.01 | 0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  68.09 ns | 0.399 ns | 0.373 ns |  0.23 |    0.00 | 0.2180 |     - |     - |     456 B |

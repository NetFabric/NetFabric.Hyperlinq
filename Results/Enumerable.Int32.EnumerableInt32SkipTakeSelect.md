## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  5.017 μs | 0.0239 μs | 0.0199 μs |  1.00 |    0.00 |  0.0153 |     - |     - |      40 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 16.934 μs | 0.1209 μs | 0.1010 μs |  3.38 |    0.02 |  0.0916 |     - |     - |     208 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 13.471 μs | 0.0737 μs | 0.0653 μs |  2.69 |    0.02 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 66.973 μs | 0.5482 μs | 0.4859 μs | 13.35 |    0.08 | 17.3340 |     - |     - |  36,467 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 31.530 μs | 0.1755 μs | 0.1556 μs |  6.28 |    0.04 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  9.699 μs | 0.0708 μs | 0.0627 μs |  1.93 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  8.783 μs | 0.0628 μs | 0.0557 μs |  1.75 |    0.01 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  9.616 μs | 0.0496 μs | 0.0387 μs |  1.92 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  8.477 μs | 0.0267 μs | 0.0237 μs |  1.69 |    0.01 |  0.0153 |     - |     - |      40 B |
|                      |        |          |      |       |           |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  3.173 μs | 0.0132 μs | 0.0117 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |  1000 | 11.317 μs | 0.0459 μs | 0.0383 μs |  3.56 |    0.02 |  0.0916 |     - |     - |     208 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 11.832 μs | 0.0540 μs | 0.0479 μs |  3.73 |    0.02 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 59.084 μs | 0.4100 μs | 0.3634 μs | 18.62 |    0.15 | 17.2119 |     - |     - |  36,027 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 22.896 μs | 0.3848 μs | 0.3213 μs |  7.21 |    0.09 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  7.762 μs | 0.0452 μs | 0.0423 μs |  2.45 |    0.02 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  7.112 μs | 0.0279 μs | 0.0247 μs |  2.24 |    0.01 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  8.065 μs | 0.0372 μs | 0.0310 μs |  2.54 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  6.168 μs | 0.0288 μs | 0.0269 μs |  1.94 |    0.01 |  0.0153 |     - |     - |      40 B |

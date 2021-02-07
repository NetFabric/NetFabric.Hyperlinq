## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    94.15 ns | 0.265 ns | 0.248 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,574.38 ns | 4.971 ns | 4.650 ns | 27.34 |    0.07 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,324.77 ns | 2.598 ns | 2.430 ns | 14.07 |    0.05 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   334.96 ns | 3.034 ns | 2.838 ns |  3.56 |    0.03 | 0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |   100 | 2,748.73 ns | 6.032 ns | 5.347 ns | 29.20 |    0.10 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   320.56 ns | 1.758 ns | 1.645 ns |  3.40 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   167.74 ns | 0.314 ns | 0.294 ns |  1.78 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   257.39 ns | 0.637 ns | 0.498 ns |  2.73 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   184.41 ns | 0.318 ns | 0.298 ns |  1.96 |    0.01 |      - |     - |     - |         - |

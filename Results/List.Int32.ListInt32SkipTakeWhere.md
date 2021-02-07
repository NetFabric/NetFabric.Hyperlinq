## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   118.9 ns |  0.34 ns |  0.32 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,491.0 ns | 11.44 ns | 10.14 ns | 37.78 |    0.08 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,234.0 ns |  3.27 ns |  3.06 ns | 10.38 |    0.04 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   818.6 ns |  1.89 ns |  1.67 ns |  6.89 |    0.03 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 5,571.9 ns |  8.78 ns |  7.33 ns | 46.88 |    0.16 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   322.2 ns |  1.20 ns |  1.12 ns |  2.71 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   172.0 ns |  0.35 ns |  0.33 ns |  1.45 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   235.0 ns |  0.59 ns |  0.46 ns |  1.98 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   185.2 ns |  0.35 ns |  0.27 ns |  1.56 |    0.00 |      - |     - |     - |         - |

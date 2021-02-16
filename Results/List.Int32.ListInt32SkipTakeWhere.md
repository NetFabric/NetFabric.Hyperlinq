## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   115.1 ns |  0.21 ns |  0.19 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,605.0 ns | 10.70 ns |  9.48 ns | 40.02 |    0.12 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,577.4 ns |  6.15 ns |  5.75 ns | 13.70 |    0.06 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   821.0 ns |  2.91 ns |  2.43 ns |  7.13 |    0.02 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 5,510.9 ns | 18.59 ns | 16.48 ns | 47.89 |    0.14 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   321.6 ns |  2.08 ns |  1.74 ns |  2.79 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   187.6 ns |  0.53 ns |  0.50 ns |  1.63 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   266.1 ns |  2.07 ns |  1.94 ns |  2.31 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   196.1 ns |  0.63 ns |  0.56 ns |  1.70 |    0.01 |      - |     - |     - |         - |

## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|              ForLoop | 1000 |   100 |   134.1 ns |  0.35 ns |  0.30 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,498.8 ns | 10.11 ns |  8.96 ns | 33.54 |    0.11 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,256.3 ns |  3.85 ns |  3.41 ns |  9.36 |    0.03 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   889.7 ns |  3.30 ns |  2.93 ns |  6.64 |    0.02 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 5,717.2 ns | 20.82 ns | 18.46 ns | 42.63 |    0.17 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   321.6 ns |  0.67 ns |  0.63 ns |  2.40 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   191.5 ns |  0.68 ns |  0.56 ns |  1.43 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   279.0 ns |  1.08 ns |  1.01 ns |  2.08 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   199.9 ns |  0.24 ns |  0.19 ns |  1.49 |    0.00 |      - |     - |     - |         - |

## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|              ForLoop | 1000 |   100 |   128.7 ns |  0.49 ns |  0.46 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,191.6 ns | 28.96 ns | 24.18 ns | 32.56 |    0.25 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,388.6 ns |  8.02 ns |  7.50 ns | 10.79 |    0.06 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 | 1,013.8 ns |  7.24 ns |  6.42 ns |  7.88 |    0.07 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 6,031.1 ns | 23.48 ns | 21.96 ns | 46.87 |    0.26 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   356.7 ns |  1.48 ns |  1.39 ns |  2.77 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   210.0 ns |  1.10 ns |  0.97 ns |  1.63 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   283.0 ns |  1.44 ns |  1.20 ns |  2.20 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   205.2 ns |  0.57 ns |  0.54 ns |  1.59 |    0.01 |      - |     - |     - |         - |

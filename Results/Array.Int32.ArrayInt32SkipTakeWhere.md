## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|              ForLoop | 1000 |   100 |   103.8 ns |  1.68 ns |  1.57 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,562.7 ns | 27.64 ns | 25.85 ns | 24.69 |    0.43 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,418.4 ns | 21.72 ns | 19.26 ns | 13.68 |    0.30 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   379.8 ns |  6.23 ns |  5.82 ns |  3.66 |    0.07 | 0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |   100 | 2,950.2 ns | 37.82 ns | 35.37 ns | 28.43 |    0.54 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   352.0 ns |  4.81 ns |  4.50 ns |  3.39 |    0.05 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   181.7 ns |  2.14 ns |  2.00 ns |  1.75 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   289.7 ns |  2.53 ns |  2.37 ns |  2.79 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   198.6 ns |  1.48 ns |  1.38 ns |  1.91 |    0.03 |      - |     - |     - |         - |

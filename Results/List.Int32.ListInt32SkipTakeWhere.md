## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    78.27 ns |  0.414 ns |  0.367 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 3,771.56 ns | 14.438 ns | 12.798 ns | 48.19 |    0.31 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,272.38 ns |  2.796 ns |  2.478 ns | 16.26 |    0.08 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   845.22 ns |  2.299 ns |  2.038 ns | 10.80 |    0.05 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 5,442.27 ns |  9.712 ns |  8.609 ns | 69.53 |    0.34 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   311.13 ns |  0.692 ns |  0.647 ns |  3.97 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   170.67 ns |  0.658 ns |  0.583 ns |  2.18 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   267.11 ns |  1.675 ns |  1.567 ns |  3.41 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   184.87 ns |  0.287 ns |  0.224 ns |  2.36 |    0.01 |      - |     - |     - |         - |

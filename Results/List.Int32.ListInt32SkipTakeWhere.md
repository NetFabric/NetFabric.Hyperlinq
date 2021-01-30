## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|              ForLoop | 1000 |   100 |    78.55 ns |  0.507 ns |  0.423 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,500.42 ns | 21.570 ns | 19.121 ns | 57.28 |    0.37 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,262.14 ns |  8.838 ns |  7.835 ns | 16.08 |    0.11 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   846.55 ns |  2.178 ns |  1.931 ns | 10.78 |    0.05 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 5,614.99 ns | 13.415 ns | 11.892 ns | 71.48 |    0.38 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   310.51 ns |  1.381 ns |  1.153 ns |  3.95 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   192.15 ns |  0.546 ns |  0.484 ns |  2.45 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   257.89 ns |  0.429 ns |  0.380 ns |  3.28 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   187.09 ns |  0.343 ns |  0.304 ns |  2.38 |    0.01 |      - |     - |     - |         - |

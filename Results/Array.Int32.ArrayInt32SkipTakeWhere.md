## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    88.25 ns | 0.203 ns | 0.170 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,569.49 ns | 7.582 ns | 6.722 ns | 29.11 |    0.11 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,579.64 ns | 6.345 ns | 4.954 ns | 17.90 |    0.08 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   340.42 ns | 2.158 ns | 2.018 ns |  3.86 |    0.02 | 0.7191 |     - |     - |    1504 B |
|               LinqAF | 1000 |   100 | 2,988.57 ns | 8.662 ns | 7.679 ns | 33.87 |    0.12 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   407.62 ns | 4.854 ns | 4.303 ns |  4.62 |    0.05 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   162.59 ns | 0.388 ns | 0.344 ns |  1.84 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   270.08 ns | 1.536 ns | 1.362 ns |  3.06 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   195.09 ns | 0.713 ns | 0.632 ns |  2.21 |    0.01 |      - |     - |     - |         - |

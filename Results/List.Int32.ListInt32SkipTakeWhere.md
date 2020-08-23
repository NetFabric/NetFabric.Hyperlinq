## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   136.6 ns |  1.20 ns |  1.00 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 3,869.4 ns | 39.07 ns | 36.55 ns | 28.36 |    0.43 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,315.4 ns | 12.83 ns | 12.00 ns |  9.61 |    0.06 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   923.5 ns |  4.36 ns |  4.08 ns |  6.76 |    0.06 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 5,601.5 ns | 44.92 ns | 39.82 ns | 40.96 |    0.30 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   380.6 ns |  1.10 ns |  0.92 ns |  2.79 |    0.02 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   185.1 ns |  1.23 ns |  1.09 ns |  1.36 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   364.9 ns |  3.11 ns |  2.76 ns |  2.67 |    0.03 |      - |     - |     - |         - |

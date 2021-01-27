## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|              ForLoop | 1000 |   100 |   118.9 ns |  0.35 ns |  0.31 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,490.9 ns | 13.62 ns | 12.07 ns | 37.76 |    0.17 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,234.6 ns |  4.02 ns |  3.76 ns | 10.38 |    0.05 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   821.7 ns |  2.86 ns |  2.53 ns |  6.91 |    0.02 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 5,797.8 ns | 19.27 ns | 17.08 ns | 48.75 |    0.20 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   302.2 ns |  0.49 ns |  0.41 ns |  2.54 |    0.01 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   181.2 ns |  0.36 ns |  0.33 ns |  1.52 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   260.4 ns |  0.97 ns |  0.86 ns |  2.19 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   188.2 ns |  0.35 ns |  0.31 ns |  1.58 |    0.01 |      - |     - |     - |         - |

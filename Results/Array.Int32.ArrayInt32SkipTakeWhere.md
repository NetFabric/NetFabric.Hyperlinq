## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   121.4 ns | 0.26 ns | 0.23 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,604.8 ns | 6.44 ns | 5.71 ns | 21.46 |    0.06 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,329.4 ns | 3.13 ns | 2.77 ns | 10.95 |    0.03 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   350.7 ns | 4.15 ns | 3.68 ns |  2.89 |    0.03 | 0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |   100 | 2,744.8 ns | 9.73 ns | 8.62 ns | 22.62 |    0.06 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   300.7 ns | 1.12 ns | 1.05 ns |  2.48 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   168.7 ns | 0.40 ns | 0.36 ns |  1.39 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   267.4 ns | 0.72 ns | 0.68 ns |  2.20 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   184.4 ns | 0.28 ns | 0.25 ns |  1.52 |    0.00 |      - |     - |     - |         - |

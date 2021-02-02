## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    95.17 ns |  0.273 ns |  0.228 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,324.44 ns |  5.285 ns |  4.944 ns | 24.42 |    0.08 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,263.97 ns |  2.612 ns |  2.443 ns | 13.28 |    0.03 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   348.53 ns |  2.103 ns |  1.864 ns |  3.66 |    0.02 | 0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |   100 | 2,683.21 ns | 13.960 ns | 11.658 ns | 28.19 |    0.15 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   323.90 ns |  0.790 ns |  0.660 ns |  3.40 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   167.40 ns |  0.694 ns |  0.579 ns |  1.76 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   268.01 ns |  0.453 ns |  0.379 ns |  2.82 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   184.81 ns |  0.223 ns |  0.197 ns |  1.94 |    0.00 |      - |     - |     - |         - |

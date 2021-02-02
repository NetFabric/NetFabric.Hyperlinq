## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    52.52 ns |  0.142 ns |  0.118 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 2,276.80 ns |  7.724 ns |  6.031 ns | 43.36 |    0.14 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 |   969.35 ns |  2.155 ns |  1.911 ns | 18.46 |    0.05 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   357.52 ns |  3.145 ns |  2.942 ns |  6.80 |    0.06 | 0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |   100 | 3,033.53 ns | 42.265 ns | 35.293 ns | 57.76 |    0.69 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   247.67 ns |  1.177 ns |  1.101 ns |  4.72 |    0.03 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   164.13 ns |  0.443 ns |  0.370 ns |  3.13 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   193.96 ns |  0.451 ns |  0.421 ns |  3.69 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   160.36 ns |  0.403 ns |  0.336 ns |  3.05 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   192.26 ns |  0.503 ns |  0.446 ns |  3.66 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |    88.68 ns |  0.150 ns |  0.141 ns |  1.69 |    0.00 |      - |     - |     - |         - |

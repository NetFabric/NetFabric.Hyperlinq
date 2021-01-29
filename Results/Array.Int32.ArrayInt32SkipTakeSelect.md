## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    57.45 ns |  0.702 ns |  0.657 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 2,509.67 ns | 31.607 ns | 24.677 ns | 43.74 |    0.78 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 1,059.20 ns | 11.453 ns | 10.714 ns | 18.44 |    0.30 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   385.24 ns |  4.997 ns |  4.674 ns |  6.71 |    0.11 | 0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |   100 | 3,060.76 ns | 43.882 ns | 38.901 ns | 53.29 |    0.85 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   273.26 ns |  2.249 ns |  2.103 ns |  4.76 |    0.06 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   177.26 ns |  1.580 ns |  1.478 ns |  3.09 |    0.05 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   208.73 ns |  2.264 ns |  2.118 ns |  3.63 |    0.06 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   172.12 ns |  1.426 ns |  1.334 ns |  3.00 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   239.31 ns |  2.986 ns |  2.647 ns |  4.17 |    0.07 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |    98.19 ns |  1.346 ns |  1.259 ns |  1.71 |    0.03 |      - |     - |     - |         - |

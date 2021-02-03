## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    53.35 ns |  1.075 ns |   0.953 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 2,608.46 ns | 10.632 ns |   9.945 ns | 48.90 |    0.89 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 1,841.53 ns | 37.589 ns | 108.452 ns | 35.02 |    1.51 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   354.54 ns |  2.502 ns |   2.341 ns |  6.64 |    0.12 | 0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |   100 | 2,692.59 ns | 12.251 ns |  11.460 ns | 50.48 |    0.91 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   251.26 ns |  1.034 ns |   0.916 ns |  4.71 |    0.07 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   164.10 ns |  0.452 ns |   0.401 ns |  3.08 |    0.05 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   368.50 ns |  7.835 ns |  22.977 ns |  6.86 |    0.37 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   163.79 ns |  0.597 ns |   0.498 ns |  3.07 |    0.05 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   433.85 ns |  9.020 ns |  26.312 ns |  8.05 |    0.51 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |    88.97 ns |  0.165 ns |   0.138 ns |  1.67 |    0.03 |      - |     - |     - |         - |

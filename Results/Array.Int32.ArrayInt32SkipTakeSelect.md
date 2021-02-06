## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|                     ForLoop | 1000 |   100 |    53.10 ns |  0.270 ns |   0.253 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 2,630.37 ns | 12.277 ns |  10.252 ns | 49.55 |    0.26 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 1,871.55 ns | 47.447 ns | 139.154 ns | 37.45 |    3.11 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   357.29 ns |  4.016 ns |   3.560 ns |  6.73 |    0.07 | 0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |   100 | 2,829.11 ns |  5.593 ns |   5.232 ns | 53.28 |    0.24 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   251.10 ns |  0.947 ns |   0.790 ns |  4.73 |    0.03 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   164.59 ns |  0.353 ns |   0.330 ns |  3.10 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   393.71 ns |  8.114 ns |  23.019 ns |  7.61 |    0.43 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   163.10 ns |  0.397 ns |   0.332 ns |  3.07 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   410.29 ns |  8.639 ns |  25.472 ns |  7.79 |    0.63 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |    89.64 ns |  0.221 ns |   0.206 ns |  1.69 |    0.01 |      - |     - |     - |         - |

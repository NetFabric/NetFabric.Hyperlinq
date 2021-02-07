## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

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
|                     ForLoop | 1000 |   100 |    57.34 ns |  0.111 ns |  0.104 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 2,266.23 ns |  5.511 ns |  5.155 ns | 39.52 |    0.12 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 1,046.47 ns | 17.711 ns | 14.789 ns | 18.25 |    0.26 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   305.54 ns |  2.027 ns |  1.693 ns |  5.33 |    0.03 | 0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |   100 | 2,786.91 ns |  3.845 ns |  3.409 ns | 48.60 |    0.12 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   267.11 ns |  0.284 ns |  0.252 ns |  4.66 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   163.91 ns |  0.266 ns |  0.236 ns |  2.86 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   191.99 ns |  0.508 ns |  0.475 ns |  3.35 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   161.54 ns |  0.445 ns |  0.417 ns |  2.82 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   218.28 ns |  0.366 ns |  0.343 ns |  3.81 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |   137.06 ns |  0.258 ns |  0.241 ns |  2.39 |    0.01 |      - |     - |     - |         - |

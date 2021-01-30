## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    53.03 ns |  0.228 ns |   0.178 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 2,625.72 ns | 25.634 ns |  21.406 ns | 49.52 |    0.49 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 1,799.52 ns | 39.903 ns | 117.030 ns | 32.75 |    1.95 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   354.95 ns |  1.235 ns |   1.155 ns |  6.69 |    0.03 | 0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |   100 | 2,736.78 ns |  8.663 ns |   7.680 ns | 51.57 |    0.15 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   250.64 ns |  0.703 ns |   0.657 ns |  4.73 |    0.03 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   164.37 ns |  0.276 ns |   0.259 ns |  3.10 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   361.70 ns |  7.643 ns |  22.416 ns |  6.59 |    0.36 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   165.27 ns |  0.637 ns |   0.532 ns |  3.12 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   368.07 ns |  7.688 ns |  22.303 ns |  6.81 |    0.47 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |    88.93 ns |  0.271 ns |   0.253 ns |  1.68 |    0.01 |      - |     - |     - |         - |

## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
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
|              ForLoop | 1000 |   100 |   130.0 ns |  1.52 ns |  1.34 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,922.3 ns | 14.05 ns | 11.73 ns | 22.50 |    0.24 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,484.9 ns |  7.46 ns |  6.23 ns | 11.43 |    0.11 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   399.5 ns |  1.77 ns |  1.38 ns |  3.08 |    0.04 | 0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |   100 | 2,903.8 ns | 11.54 ns | 10.23 ns | 22.35 |    0.25 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   350.0 ns |  2.18 ns |  2.04 ns |  2.69 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   180.6 ns |  0.77 ns |  0.72 ns |  1.39 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   280.5 ns |  0.85 ns |  0.76 ns |  2.16 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   203.2 ns |  0.79 ns |  0.74 ns |  1.56 |    0.02 |      - |     - |     - |         - |

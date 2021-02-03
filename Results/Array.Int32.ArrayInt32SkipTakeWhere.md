## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   121.4 ns | 0.21 ns | 0.19 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,622.9 ns | 9.10 ns | 8.51 ns | 21.60 |    0.06 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,333.1 ns | 6.84 ns | 5.71 ns | 10.98 |    0.05 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   350.9 ns | 2.65 ns | 2.48 ns |  2.89 |    0.02 | 0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |   100 | 2,791.9 ns | 6.53 ns | 6.10 ns | 23.00 |    0.07 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   301.1 ns | 1.13 ns | 0.88 ns |  2.48 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   168.8 ns | 0.51 ns | 0.47 ns |  1.39 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   267.9 ns | 0.59 ns | 0.49 ns |  2.21 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   184.1 ns | 0.34 ns | 0.30 ns |  1.52 |    0.00 |      - |     - |     - |         - |

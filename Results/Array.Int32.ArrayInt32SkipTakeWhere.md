## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   121.5 ns | 0.33 ns | 0.27 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,607.5 ns | 8.22 ns | 7.69 ns | 21.46 |    0.07 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,334.6 ns | 6.09 ns | 5.40 ns | 10.98 |    0.05 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   353.8 ns | 2.16 ns | 2.02 ns |  2.91 |    0.02 | 0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |   100 | 2,565.4 ns | 8.16 ns | 7.23 ns | 21.11 |    0.08 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   301.9 ns | 1.06 ns | 0.94 ns |  2.49 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   168.7 ns | 0.45 ns | 0.42 ns |  1.39 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   246.4 ns | 2.29 ns | 1.79 ns |  2.03 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   185.4 ns | 0.26 ns | 0.23 ns |  1.53 |    0.00 |      - |     - |     - |         - |

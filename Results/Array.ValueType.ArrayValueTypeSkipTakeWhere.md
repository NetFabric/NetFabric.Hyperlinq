## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   409.4 ns |  0.79 ns |  0.70 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,667.3 ns |  7.80 ns |  6.92 ns |  6.51 |    0.02 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,589.0 ns |  2.86 ns |  2.54 ns |  3.88 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 1,430.6 ns |  7.16 ns |  5.98 ns |  3.49 |    0.02 | 6.7329 |     - |     - |   14096 B |
|               LinqAF | 1000 |   100 | 5,212.1 ns | 31.41 ns | 29.38 ns | 12.72 |    0.08 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   616.0 ns |  1.15 ns |  1.02 ns |  1.50 |    0.00 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   487.0 ns |  0.82 ns |  0.68 ns |  1.19 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   515.5 ns |  1.14 ns |  1.01 ns |  1.26 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   467.2 ns |  0.63 ns |  0.56 ns |  1.14 |    0.00 |      - |     - |     - |         - |

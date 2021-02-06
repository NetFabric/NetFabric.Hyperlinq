## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   411.1 ns |  1.45 ns |  1.35 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,678.5 ns |  7.77 ns |  6.89 ns |  6.51 |    0.03 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,599.7 ns |  4.06 ns |  3.60 ns |  3.89 |    0.02 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 1,442.8 ns | 18.32 ns | 17.14 ns |  3.51 |    0.04 | 6.7329 |     - |     - |   14096 B |
|               LinqAF | 1000 |   100 | 5,024.6 ns | 99.75 ns | 93.30 ns | 12.22 |    0.24 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   616.0 ns |  1.70 ns |  1.50 ns |  1.50 |    0.00 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   501.1 ns |  1.22 ns |  1.02 ns |  1.22 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   530.1 ns |  0.82 ns |  0.73 ns |  1.29 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   468.8 ns |  1.36 ns |  1.27 ns |  1.14 |    0.01 |      - |     - |     - |         - |

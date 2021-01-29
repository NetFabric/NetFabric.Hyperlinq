## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   459.5 ns |  1.80 ns |  1.68 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,898.3 ns |  7.06 ns |  6.61 ns |  6.31 |    0.03 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,778.5 ns |  6.75 ns |  5.27 ns |  3.87 |    0.02 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 1,599.5 ns | 19.13 ns | 15.97 ns |  3.48 |    0.03 | 6.7329 |     - |     - |   14096 B |
|               LinqAF | 1000 |   100 | 5,405.1 ns | 15.80 ns | 13.20 ns | 11.76 |    0.05 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   714.0 ns |  3.37 ns |  2.81 ns |  1.55 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   576.0 ns |  1.44 ns |  1.28 ns |  1.25 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   707.5 ns |  2.12 ns |  1.99 ns |  1.54 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   599.5 ns |  3.20 ns |  2.99 ns |  1.30 |    0.01 |      - |     - |     - |         - |

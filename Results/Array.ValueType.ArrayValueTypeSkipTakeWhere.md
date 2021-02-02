## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|              ForLoop | 1000 |   100 |   408.9 ns |  0.46 ns |  0.41 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,666.6 ns | 11.00 ns |  9.75 ns |  6.52 |    0.02 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,595.0 ns |  3.40 ns |  3.18 ns |  3.90 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 1,431.0 ns | 23.77 ns | 22.24 ns |  3.49 |    0.05 | 6.7329 |     - |     - |   14096 B |
|               LinqAF | 1000 |   100 | 5,228.8 ns | 26.29 ns | 21.95 ns | 12.79 |    0.05 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   613.1 ns |  1.33 ns |  1.11 ns |  1.50 |    0.00 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   501.7 ns |  1.31 ns |  1.16 ns |  1.23 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   513.8 ns |  0.80 ns |  0.75 ns |  1.26 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   467.2 ns |  0.82 ns |  0.73 ns |  1.14 |    0.00 |      - |     - |     - |         - |

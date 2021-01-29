## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    82.03 ns | 0.413 ns | 0.366 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   130.39 ns | 0.851 ns | 0.754 ns |  1.59 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 |   739.28 ns | 7.251 ns | 6.428 ns |  9.01 |    0.10 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   278.78 ns | 1.713 ns | 1.431 ns |  3.40 |    0.02 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,152.53 ns | 6.270 ns | 5.865 ns | 14.05 |    0.11 |      - |     - |     - |         - |
|           StructLinq |   100 |   311.83 ns | 1.627 ns | 1.358 ns |  3.80 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   195.92 ns | 0.617 ns | 0.547 ns |  2.39 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   403.99 ns | 2.693 ns | 2.519 ns |  4.92 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   262.68 ns | 1.189 ns | 0.993 ns |  3.20 |    0.01 |      - |     - |     - |         - |

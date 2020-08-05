## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 120.9 ns | 0.74 ns | 0.66 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 120.6 ns | 0.54 ns | 0.42 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 642.8 ns | 3.46 ns | 3.24 ns |  5.32 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 221.9 ns | 1.62 ns | 1.44 ns |  1.84 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 355.2 ns | 2.54 ns | 2.38 ns |  2.94 |    0.03 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 185.4 ns | 1.41 ns | 1.32 ns |  1.53 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 197.2 ns | 1.79 ns | 1.49 ns |  1.63 |    0.01 |      - |     - |     - |         - |

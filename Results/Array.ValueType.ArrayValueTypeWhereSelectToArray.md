## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 1,020.4 ns |  6.04 ns |  5.35 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|          ForeachLoop |   100 | 1,018.9 ns |  9.29 ns |  8.23 ns |  1.00 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                 Linq |   100 | 1,293.9 ns | 13.70 ns | 12.81 ns |  1.27 |    0.01 | 2.4319 |     - |     - |    5088 B |
|           LinqFaster |   100 | 1,051.2 ns |  6.36 ns |  5.31 ns |  1.03 |    0.01 | 2.8896 |     - |     - |    6048 B |
|           StructLinq |   100 | 1,288.0 ns | 20.36 ns | 18.05 ns |  1.26 |    0.02 | 0.9899 |     - |     - |    2072 B |
| StructLinq_IFunction |   100 |   880.7 ns |  8.10 ns |  7.18 ns |  0.86 |    0.01 | 0.9899 |     - |     - |    2072 B |
|            Hyperlinq |   100 | 1,252.4 ns |  9.46 ns |  8.39 ns |  1.23 |    0.01 | 0.9670 |     - |     - |    2024 B |
|       Hyperlinq_Pool |   100 | 1,187.0 ns | 10.69 ns |  9.48 ns |  1.16 |    0.01 | 0.0267 |     - |     - |      56 B |

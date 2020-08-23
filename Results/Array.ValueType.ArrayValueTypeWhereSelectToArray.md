## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

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
|              ForLoop |   100 |   968.9 ns | 11.30 ns | 10.02 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|          ForeachLoop |   100 | 1,037.5 ns |  8.62 ns |  8.06 ns |  1.07 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                 Linq |   100 | 1,312.8 ns | 14.61 ns | 13.67 ns |  1.35 |    0.02 | 2.4319 |     - |     - |    5088 B |
|           LinqFaster |   100 | 1,031.6 ns | 10.64 ns |  8.30 ns |  1.06 |    0.01 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,972.7 ns | 20.29 ns | 18.98 ns |  2.04 |    0.03 | 3.3951 |     - |     - |    7104 B |
|           StructLinq |   100 | 1,253.0 ns |  7.23 ns |  6.41 ns |  1.29 |    0.02 | 1.0128 |     - |     - |    2120 B |
| StructLinq_IFunction |   100 |   863.4 ns |  6.26 ns |  5.23 ns |  0.89 |    0.01 | 0.9670 |     - |     - |    2024 B |
|            Hyperlinq |   100 | 1,284.6 ns |  8.16 ns |  7.63 ns |  1.33 |    0.02 | 0.9670 |     - |     - |    2024 B |
|       Hyperlinq_Pool |   100 | 1,178.6 ns |  7.63 ns |  7.14 ns |  1.22 |    0.01 | 0.0267 |     - |     - |      56 B |

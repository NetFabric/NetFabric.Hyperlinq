## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|              ForLoop |   100 | 1,063.7 ns |  7.72 ns |  6.85 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|          ForeachLoop |   100 | 1,288.7 ns |  9.94 ns |  8.81 ns |  1.21 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                 Linq |   100 | 1,365.1 ns | 13.61 ns | 12.73 ns |  1.28 |    0.01 | 2.4853 |     - |     - |    5200 B |
|           LinqFaster |   100 | 1,405.8 ns | 19.61 ns | 17.39 ns |  1.32 |    0.02 | 3.4103 |     - |     - |    7136 B |
|               LinqAF |   100 | 2,406.8 ns | 26.10 ns | 23.13 ns |  2.26 |    0.02 | 3.3951 |     - |     - |    7104 B |
|           StructLinq |   100 | 1,275.1 ns |  6.91 ns |  6.13 ns |  1.20 |    0.01 | 1.0128 |     - |     - |    2120 B |
| StructLinq_IFunction |   100 |   873.2 ns |  9.58 ns |  8.50 ns |  0.82 |    0.01 | 0.9670 |     - |     - |    2024 B |
|            Hyperlinq |   100 | 1,243.3 ns |  8.98 ns |  8.40 ns |  1.17 |    0.01 | 0.9670 |     - |     - |    2024 B |
|       Hyperlinq_Pool |   100 | 1,166.7 ns |  7.27 ns |  6.44 ns |  1.10 |    0.01 | 0.0267 |     - |     - |      56 B |

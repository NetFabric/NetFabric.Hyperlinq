## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|              ForLoop |   100 | 1,067.5 ns |  8.69 ns |  8.13 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|          ForeachLoop |   100 | 1,266.6 ns | 10.02 ns |  9.37 ns |  1.19 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                 Linq |   100 | 1,372.3 ns | 17.47 ns | 15.49 ns |  1.29 |    0.02 | 2.4853 |     - |     - |    5200 B |
|           LinqFaster |   100 | 1,399.1 ns | 20.84 ns | 19.49 ns |  1.31 |    0.02 | 3.4103 |     - |     - |    7136 B |
|           StructLinq |   100 | 1,297.5 ns | 14.22 ns | 12.60 ns |  1.22 |    0.01 | 0.9899 |     - |     - |    2072 B |
| StructLinq_IFunction |   100 |   886.4 ns |  6.42 ns |  5.69 ns |  0.83 |    0.01 | 0.9899 |     - |     - |    2072 B |
|            Hyperlinq |   100 | 1,240.0 ns | 11.63 ns |  9.71 ns |  1.16 |    0.01 | 0.9670 |     - |     - |    2024 B |
|       Hyperlinq_Pool |   100 | 1,157.9 ns |  7.68 ns |  7.18 ns |  1.08 |    0.01 | 0.0267 |     - |     - |      56 B |

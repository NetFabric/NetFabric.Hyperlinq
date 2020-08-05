## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   484.1 ns | 3.63 ns | 3.40 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   685.4 ns | 5.19 ns | 4.85 ns |  1.42 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 1,128.0 ns | 6.34 ns | 5.93 ns |  2.33 |    0.02 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,101.1 ns | 7.96 ns | 7.45 ns |  2.27 |    0.02 | 2.4433 |     - |     - |    5112 B |
|           StructLinq |   100 |   728.7 ns | 1.89 ns | 1.77 ns |  1.51 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   494.4 ns | 1.23 ns | 1.15 ns |  1.02 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   675.0 ns | 1.85 ns | 1.44 ns |  1.39 |    0.01 |      - |     - |     - |         - |

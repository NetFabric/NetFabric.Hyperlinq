## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|              ForLoop |   100 |   499.0 ns |  4.07 ns |  3.81 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   706.0 ns |  5.31 ns |  4.97 ns |  1.41 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 1,123.7 ns | 16.72 ns | 15.64 ns |  2.25 |    0.04 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,218.1 ns | 11.64 ns | 10.89 ns |  2.44 |    0.03 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,410.7 ns | 16.45 ns | 13.74 ns |  2.83 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 |   637.2 ns |  5.31 ns |  4.70 ns |  1.28 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   489.0 ns |  3.99 ns |  3.73 ns |  0.98 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   673.6 ns |  3.98 ns |  3.32 ns |  1.35 |    0.01 |      - |     - |     - |         - |

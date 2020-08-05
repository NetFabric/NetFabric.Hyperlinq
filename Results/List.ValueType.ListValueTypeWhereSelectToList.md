## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|              ForLoop |   100 |   923.0 ns |  4.95 ns |  4.63 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|          ForeachLoop |   100 | 1,136.1 ns |  7.40 ns |  6.56 ns |  1.23 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                 Linq |   100 | 1,321.3 ns | 18.21 ns | 17.04 ns |  1.43 |    0.02 | 2.5768 |     - |     - |   5.27 KB |
|           LinqFaster |   100 | 1,426.4 ns | 28.04 ns | 26.23 ns |  1.55 |    0.03 | 3.4237 |     - |     - |      7 KB |
|           StructLinq |   100 | 1,285.4 ns | 21.03 ns | 18.64 ns |  1.39 |    0.02 | 1.0052 |     - |     - |   2.05 KB |
| StructLinq_IFunction |   100 |   857.8 ns |  3.70 ns |  3.46 ns |  0.93 |    0.00 | 1.0052 |     - |     - |   2.05 KB |
|            Hyperlinq |   100 | 1,285.4 ns | 10.36 ns |  9.69 ns |  1.39 |    0.01 | 1.0166 |     - |     - |   2.08 KB |

## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   877.6 ns |  5.61 ns |  4.98 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,068.1 ns |  6.79 ns |  6.02 ns |  1.22 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,632.8 ns |  4.10 ns |  3.64 ns |  1.86 |    0.01 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,734.2 ns | 19.80 ns | 17.55 ns |  1.98 |    0.02 | 2.4433 |     - |     - |    5112 B |
|           StructLinq |   100 | 1,235.5 ns | 10.62 ns |  9.93 ns |  1.41 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   901.7 ns |  2.20 ns |  1.95 ns |  1.03 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,202.2 ns |  4.39 ns |  3.66 ns |  1.37 |    0.01 |      - |     - |     - |         - |

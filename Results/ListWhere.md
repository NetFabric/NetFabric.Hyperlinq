## ListWhere

### Source
[ListWhere.cs](../LinqBenchmarks/ListWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 122.2 ns | 0.31 ns | 0.29 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 219.9 ns | 0.55 ns | 0.46 ns |  1.80 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 626.4 ns | 1.99 ns | 1.86 ns |  5.12 |    0.02 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 394.7 ns | 0.91 ns | 0.85 ns |  3.23 |    0.01 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 337.9 ns | 0.51 ns | 0.45 ns |  2.76 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 163.1 ns | 0.39 ns | 0.36 ns |  1.33 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 378.2 ns | 0.75 ns | 0.70 ns |  3.09 |    0.01 |      - |     - |     - |         - |

## ListWhereSelect

### Source
[ListWhereSelect.cs](../LinqBenchmarks/ListWhereSelect.cs)

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
|              ForLoop |   100 | 104.4 ns | 0.27 ns | 0.24 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 220.0 ns | 0.88 ns | 0.78 ns |  2.11 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 740.6 ns | 6.03 ns | 5.34 ns |  7.09 |    0.06 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 | 511.9 ns | 2.57 ns | 2.41 ns |  4.90 |    0.02 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 | 426.4 ns | 1.15 ns | 0.96 ns |  4.08 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 181.3 ns | 0.77 ns | 0.68 ns |  1.74 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 452.7 ns | 3.41 ns | 2.66 ns |  4.33 |    0.03 |      - |     - |     - |         - |

## ArrayWhereSelect

### Source
[ArrayWhereSelect.cs](../LinqBenchmarks/ArrayWhereSelect.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  79.15 ns | 0.208 ns | 0.185 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  74.91 ns | 0.145 ns | 0.129 ns |  0.95 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 561.40 ns | 1.704 ns | 1.594 ns |  7.09 |    0.03 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 387.83 ns | 1.273 ns | 0.994 ns |  4.90 |    0.02 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 414.83 ns | 1.951 ns | 1.729 ns |  5.24 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 181.15 ns | 0.384 ns | 0.320 ns |  2.29 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 519.82 ns | 2.324 ns | 2.174 ns |  6.56 |    0.03 |      - |     - |     - |         - |

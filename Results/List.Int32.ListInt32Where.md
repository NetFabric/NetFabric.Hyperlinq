## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 106.4 ns | 1.02 ns | 0.96 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 215.0 ns | 1.25 ns | 1.11 ns |  2.02 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 638.0 ns | 4.40 ns | 3.90 ns |  6.00 |    0.07 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 439.3 ns | 2.58 ns | 2.41 ns |  4.13 |    0.04 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 376.4 ns | 0.90 ns | 0.80 ns |  3.54 |    0.03 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 163.7 ns | 0.85 ns | 0.80 ns |  1.54 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 344.8 ns | 5.72 ns | 5.07 ns |  3.24 |    0.05 |      - |     - |     - |         - |

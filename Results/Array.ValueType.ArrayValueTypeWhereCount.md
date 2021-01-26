## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    81.72 ns |  0.294 ns |  0.261 ns |    81.67 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   130.67 ns |  0.495 ns |  0.463 ns |   130.74 ns |  1.60 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,105.26 ns | 22.126 ns | 47.153 ns | 1,122.70 ns | 13.13 |    0.43 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   453.18 ns |  5.717 ns |  5.348 ns |   452.03 ns |  5.54 |    0.08 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,465.06 ns | 23.585 ns | 22.061 ns | 1,462.47 ns | 17.93 |    0.28 |      - |     - |     - |         - |
|           StructLinq |   100 |   477.88 ns |  7.332 ns |  6.123 ns |   477.75 ns |  5.85 |    0.07 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   204.97 ns |  0.592 ns |  0.554 ns |   205.02 ns |  2.51 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   471.91 ns |  8.376 ns |  7.425 ns |   473.05 ns |  5.77 |    0.08 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   231.15 ns |  1.995 ns |  1.866 ns |   231.11 ns |  2.83 |    0.03 |      - |     - |     - |         - |

## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    88.40 ns | 0.564 ns | 0.527 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |    97.70 ns | 1.410 ns | 1.319 ns |  1.11 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 |   759.26 ns | 5.265 ns | 4.925 ns |  8.59 |    0.09 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   245.26 ns | 2.646 ns | 2.346 ns |  2.77 |    0.03 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,038.30 ns | 9.772 ns | 9.140 ns | 11.75 |    0.14 |      - |     - |     - |         - |
|           StructLinq |   100 |   336.97 ns | 3.753 ns | 3.511 ns |  3.81 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   178.04 ns | 0.462 ns | 0.386 ns |  2.02 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   194.95 ns | 0.499 ns | 0.467 ns |  2.21 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   115.86 ns | 0.517 ns | 0.458 ns |  1.31 |    0.01 |      - |     - |     - |         - |

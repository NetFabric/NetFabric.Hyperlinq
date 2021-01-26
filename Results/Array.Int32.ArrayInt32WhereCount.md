## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|               Method | Count |        Mean |     Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    83.67 ns |  0.285 ns | 0.267 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |    83.83 ns |  0.290 ns | 0.257 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,122.05 ns | 10.029 ns | 9.381 ns | 13.41 |    0.12 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   390.29 ns |  6.505 ns | 6.085 ns |  4.66 |    0.07 |      - |     - |     - |         - |
|               LinqAF |   100 |   347.60 ns |  3.374 ns | 3.156 ns |  4.15 |    0.04 |      - |     - |     - |         - |
|           StructLinq |   100 |   454.17 ns |  7.373 ns | 6.536 ns |  5.43 |    0.08 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   178.65 ns |  0.824 ns | 0.730 ns |  2.13 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   303.22 ns |  5.994 ns | 5.314 ns |  3.62 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |    80.80 ns |  0.401 ns | 0.375 ns |  0.97 |    0.00 |      - |     - |     - |         - |

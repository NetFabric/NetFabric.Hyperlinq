## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    78.01 ns |  0.139 ns |  0.130 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |    78.10 ns |  0.187 ns |  0.146 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,027.46 ns |  2.329 ns |  2.178 ns | 13.17 |    0.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   497.29 ns | 11.506 ns | 33.745 ns |  6.32 |    0.38 |      - |     - |     - |         - |
|               LinqAF |   100 |   480.45 ns | 11.340 ns | 33.079 ns |  6.19 |    0.35 |      - |     - |     - |         - |
|           StructLinq |   100 |   477.48 ns |  8.654 ns |  7.672 ns |  6.12 |    0.10 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |    81.40 ns |  0.370 ns |  0.346 ns |  1.04 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   191.73 ns |  0.403 ns |  0.337 ns |  2.46 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |    73.12 ns |  0.299 ns |  0.265 ns |  0.94 |    0.00 |      - |     - |     - |         - |

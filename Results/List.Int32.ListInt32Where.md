## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 114.9 ns |  0.57 ns |  0.51 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 368.7 ns |  4.79 ns |  4.48 ns |  3.21 |    0.04 |      - |     - |     - |         - |
|                 Linq |   100 | 953.6 ns | 18.76 ns | 21.61 ns |  8.29 |    0.21 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 645.3 ns |  5.91 ns |  5.24 ns |  5.61 |    0.05 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 940.8 ns | 11.43 ns | 10.14 ns |  8.18 |    0.10 |      - |     - |     - |         - |
|           StructLinq |   100 | 437.2 ns |  7.98 ns |  7.47 ns |  3.81 |    0.07 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 185.2 ns |  1.11 ns |  1.04 ns |  1.61 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 369.8 ns |  4.97 ns |  4.15 ns |  3.22 |    0.04 |      - |     - |     - |         - |

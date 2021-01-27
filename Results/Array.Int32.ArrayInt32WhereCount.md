## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  77.54 ns | 0.387 ns | 0.343 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  77.62 ns | 0.140 ns | 0.124 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 633.21 ns | 1.551 ns | 1.375 ns |  8.17 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 213.08 ns | 1.005 ns | 0.891 ns |  2.75 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 262.56 ns | 1.535 ns | 1.360 ns |  3.39 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 266.76 ns | 1.231 ns | 1.091 ns |  3.44 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 162.26 ns | 0.404 ns | 0.378 ns |  2.09 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 214.34 ns | 0.463 ns | 0.387 ns |  2.76 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  74.42 ns | 0.562 ns | 0.498 ns |  0.96 |    0.01 |      - |     - |     - |         - |

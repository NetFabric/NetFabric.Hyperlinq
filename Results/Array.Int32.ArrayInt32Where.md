## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  80.21 ns |  0.325 ns |  0.289 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  80.23 ns |  0.461 ns |  0.408 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 654.69 ns | 13.011 ns | 12.171 ns |  8.18 |    0.14 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 317.11 ns |  1.957 ns |  1.735 ns |  3.95 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 573.27 ns |  7.249 ns |  6.780 ns |  7.14 |    0.09 |      - |     - |     - |         - |
|           StructLinq |   100 | 475.73 ns |  6.040 ns |  5.650 ns |  5.93 |    0.08 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 176.17 ns |  0.775 ns |  0.647 ns |  2.20 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 389.90 ns |  3.738 ns |  3.314 ns |  4.86 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 199.99 ns |  0.727 ns |  0.680 ns |  2.49 |    0.01 |      - |     - |     - |         - |

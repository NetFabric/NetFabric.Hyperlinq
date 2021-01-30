## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|              ForLoop |   100 |    74.69 ns |  0.149 ns |  0.132 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   119.67 ns |  0.276 ns |  0.245 ns |  1.60 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,335.66 ns | 28.750 ns | 84.770 ns | 18.02 |    1.20 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   584.05 ns | 12.747 ns | 37.586 ns |  7.65 |    0.25 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,668.97 ns | 31.150 ns | 29.138 ns | 22.33 |    0.41 |      - |     - |     - |         - |
|           StructLinq |   100 |   549.12 ns | 11.010 ns | 29.004 ns |  7.49 |    0.49 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   178.60 ns |  0.405 ns |  0.338 ns |  2.39 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   432.17 ns | 12.605 ns | 37.167 ns |  5.70 |    0.52 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   193.24 ns |  0.431 ns |  0.382 ns |  2.59 |    0.01 |      - |     - |     - |         - |

## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|              ForLoop |   100 |  73.95 ns | 0.205 ns | 0.182 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  74.01 ns | 0.228 ns | 0.214 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 447.63 ns | 1.017 ns | 0.849 ns |  6.05 |    0.02 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 282.30 ns | 1.152 ns | 1.021 ns |  3.82 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 374.67 ns | 1.574 ns | 1.473 ns |  5.07 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 265.67 ns | 0.572 ns | 0.446 ns |  3.59 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 165.68 ns | 0.311 ns | 0.276 ns |  2.24 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 238.65 ns | 0.587 ns | 0.490 ns |  3.23 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 182.58 ns | 0.246 ns | 0.206 ns |  2.47 |    0.01 |      - |     - |     - |         - |

## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    74.80 ns | 0.316 ns | 0.280 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   119.16 ns | 0.432 ns | 0.383 ns |  1.59 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 |   645.48 ns | 2.958 ns | 2.767 ns |  8.63 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   248.29 ns | 0.564 ns | 0.471 ns |  3.32 |    0.02 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,041.31 ns | 3.718 ns | 2.902 ns | 13.91 |    0.06 |      - |     - |     - |         - |
|           StructLinq |   100 |   284.28 ns | 1.134 ns | 0.947 ns |  3.80 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   176.52 ns | 0.435 ns | 0.364 ns |  2.36 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   193.56 ns | 0.293 ns | 0.260 ns |  2.59 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   118.53 ns | 0.303 ns | 0.253 ns |  1.58 |    0.01 |      - |     - |     - |         - |

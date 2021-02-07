## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

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
|              ForLoop |   100 |    74.53 ns |  0.194 ns |  0.172 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   119.29 ns |  0.385 ns |  0.321 ns |  1.60 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 |   642.88 ns |  2.379 ns |  2.109 ns |  8.63 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   280.87 ns |  0.704 ns |  0.624 ns |  3.77 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,125.53 ns | 12.136 ns | 11.352 ns | 15.10 |    0.16 |      - |     - |     - |         - |
|           StructLinq |   100 |   289.75 ns |  0.914 ns |  0.763 ns |  3.89 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   176.11 ns |  0.520 ns |  0.461 ns |  2.36 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   193.14 ns |  0.637 ns |  0.497 ns |  2.59 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   137.28 ns |  0.262 ns |  0.219 ns |  1.84 |    0.00 |      - |     - |     - |         - |

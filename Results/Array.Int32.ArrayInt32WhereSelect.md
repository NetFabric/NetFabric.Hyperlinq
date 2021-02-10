## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|              ForLoop |   100 |  78.51 ns | 0.806 ns | 0.754 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  65.77 ns | 0.353 ns | 0.295 ns |  0.84 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 655.57 ns | 1.881 ns | 1.571 ns |  8.34 |    0.09 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 331.60 ns | 1.968 ns | 1.644 ns |  4.22 |    0.04 | 0.3171 |     - |     - |     664 B |
|               LinqAF |   100 | 499.64 ns | 2.953 ns | 2.618 ns |  6.36 |    0.07 |      - |     - |     - |         - |
|           StructLinq |   100 | 380.64 ns | 1.290 ns | 1.143 ns |  4.85 |    0.05 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 180.64 ns | 0.321 ns | 0.285 ns |  2.30 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 355.23 ns | 0.854 ns | 0.799 ns |  4.53 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 190.08 ns | 0.495 ns | 0.439 ns |  2.42 |    0.02 |      - |     - |     - |         - |

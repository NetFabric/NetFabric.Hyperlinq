## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    85.61 ns | 0.268 ns | 0.237 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |    91.30 ns | 0.308 ns | 0.273 ns |  1.07 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 |   735.36 ns | 1.374 ns | 1.218 ns |  8.59 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   235.55 ns | 0.722 ns | 0.603 ns |  2.75 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,005.16 ns | 9.697 ns | 8.596 ns | 11.74 |    0.10 |      - |     - |     - |         - |
|           StructLinq |   100 |   281.65 ns | 1.074 ns | 0.897 ns |  3.29 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   171.14 ns | 0.350 ns | 0.292 ns |  2.00 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   191.79 ns | 0.441 ns | 0.369 ns |  2.24 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |    92.75 ns | 0.252 ns | 0.223 ns |  1.08 |    0.00 |      - |     - |     - |         - |

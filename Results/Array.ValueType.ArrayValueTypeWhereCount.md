## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|              ForLoop |   100 |    86.23 ns | 1.266 ns | 1.554 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |    94.37 ns | 0.465 ns | 0.412 ns |  1.09 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 |   735.18 ns | 2.763 ns | 2.307 ns |  8.50 |    0.19 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   235.21 ns | 0.531 ns | 0.497 ns |  2.72 |    0.06 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,048.50 ns | 8.097 ns | 7.574 ns | 12.13 |    0.29 |      - |     - |     - |         - |
|           StructLinq |   100 |   281.39 ns | 0.786 ns | 0.696 ns |  3.25 |    0.07 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   176.04 ns | 0.401 ns | 0.356 ns |  2.04 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   168.02 ns | 0.542 ns | 0.452 ns |  1.94 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   112.70 ns | 0.269 ns | 0.210 ns |  1.30 |    0.03 |      - |     - |     - |         - |

## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   432.4 ns |  0.68 ns |  0.56 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,663.6 ns |  7.73 ns |  7.23 ns |  6.16 |    0.02 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,887.2 ns |  6.29 ns |  5.89 ns |  4.36 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 1,409.2 ns | 27.91 ns | 34.28 ns |  3.25 |    0.08 | 6.7558 |     - |     - |   14136 B |
|               LinqAF | 1000 |   100 | 6,352.4 ns | 22.86 ns | 21.38 ns | 14.70 |    0.06 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   623.7 ns |  1.26 ns |  1.05 ns |  1.44 |    0.00 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   495.3 ns |  1.13 ns |  0.94 ns |  1.15 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   537.2 ns |  0.86 ns |  0.72 ns |  1.24 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   477.0 ns |  1.21 ns |  1.08 ns |  1.10 |    0.00 |      - |     - |     - |         - |

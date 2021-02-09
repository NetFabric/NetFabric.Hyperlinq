## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   419.5 ns |  1.10 ns |  0.92 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,648.2 ns |  8.23 ns |  7.30 ns |  6.31 |    0.02 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,919.3 ns |  3.93 ns |  3.28 ns |  4.58 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 1,376.2 ns | 20.93 ns | 18.55 ns |  3.28 |    0.04 | 6.7558 |     - |     - |   14136 B |
|               LinqAF | 1000 |   100 | 5,437.5 ns | 78.51 ns | 73.44 ns | 12.95 |    0.19 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   625.4 ns |  1.28 ns |  1.14 ns |  1.49 |    0.00 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   496.1 ns |  1.28 ns |  1.07 ns |  1.18 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   537.1 ns |  2.01 ns |  1.68 ns |  1.28 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   477.8 ns |  1.46 ns |  1.37 ns |  1.14 |    0.00 |      - |     - |     - |         - |

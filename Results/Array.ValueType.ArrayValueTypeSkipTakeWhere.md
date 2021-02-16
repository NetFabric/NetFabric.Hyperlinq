## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   418.8 ns |  0.70 ns |  0.62 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,417.0 ns |  7.36 ns |  6.52 ns |  5.77 |    0.02 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,931.6 ns |  7.37 ns |  6.16 ns |  4.61 |    0.02 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 1,391.5 ns | 15.97 ns | 13.34 ns |  3.32 |    0.03 | 6.7558 |     - |     - |   14136 B |
|               LinqAF | 1000 |   100 | 5,297.8 ns | 93.17 ns | 87.15 ns | 12.65 |    0.21 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   623.0 ns |  0.97 ns |  0.76 ns |  1.49 |    0.00 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   496.2 ns |  0.88 ns |  0.74 ns |  1.18 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   584.6 ns |  1.24 ns |  1.04 ns |  1.40 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   495.9 ns |  0.74 ns |  0.65 ns |  1.18 |    0.00 |      - |     - |     - |         - |

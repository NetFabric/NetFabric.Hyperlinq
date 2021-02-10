## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    93.58 ns |   0.344 ns |   0.269 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,120.78 ns | 144.080 ns | 424.823 ns | 53.91 |    4.08 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 2,798.97 ns |  55.638 ns | 144.611 ns | 29.96 |    1.75 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   352.36 ns |   1.636 ns |   1.531 ns |  3.76 |    0.02 | 0.7191 |     - |     - |    1504 B |
|               LinqAF | 1000 |   100 | 4,434.02 ns |  88.627 ns | 135.343 ns | 47.18 |    1.64 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   493.81 ns |   9.847 ns |  24.523 ns |  5.24 |    0.22 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   164.53 ns |   0.624 ns |   0.553 ns |  1.76 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   543.84 ns |  10.879 ns |  30.506 ns |  5.81 |    0.28 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   183.59 ns |   0.380 ns |   0.337 ns |  1.96 |    0.01 |      - |     - |     - |         - |

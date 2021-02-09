## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    98.74 ns |   0.393 ns |   0.348 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,401.62 ns | 171.045 ns | 504.329 ns | 51.92 |    4.71 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 2,831.91 ns |  56.335 ns | 132.788 ns | 28.35 |    1.59 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   353.68 ns |   1.464 ns |   1.298 ns |  3.58 |    0.02 | 0.7191 |     - |     - |    1504 B |
|               LinqAF | 1000 |   100 | 4,606.79 ns |  88.323 ns | 114.845 ns | 46.63 |    1.09 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   497.23 ns |   9.955 ns |  27.082 ns |  5.08 |    0.29 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   164.67 ns |   0.579 ns |   0.483 ns |  1.67 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   574.09 ns |  14.931 ns |  44.025 ns |  5.74 |    0.45 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   183.69 ns |   0.656 ns |   0.581 ns |  1.86 |    0.01 |      - |     - |     - |         - |

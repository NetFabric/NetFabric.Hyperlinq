## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    94.88 ns |  0.757 ns |  0.632 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,918.36 ns | 32.273 ns | 28.609 ns | 30.77 |    0.28 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,896.94 ns | 22.938 ns | 20.334 ns | 20.01 |    0.25 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   366.94 ns |  1.871 ns |  1.658 ns |  3.87 |    0.03 | 0.7191 |     - |     - |    1504 B |
|               LinqAF | 1000 |   100 | 3,562.57 ns | 27.952 ns | 24.779 ns | 37.54 |    0.36 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   373.12 ns |  5.590 ns |  5.229 ns |  3.94 |    0.06 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   168.79 ns |  1.105 ns |  0.979 ns |  1.78 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   330.02 ns |  2.544 ns |  2.380 ns |  3.47 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   188.05 ns |  1.142 ns |  1.069 ns |  1.98 |    0.01 |      - |     - |     - |         - |

## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  67.68 ns | 0.265 ns | 0.248 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  80.44 ns | 0.332 ns | 0.294 ns |  1.19 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 671.68 ns | 3.755 ns | 3.328 ns |  9.93 |    0.07 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 210.57 ns | 0.956 ns | 0.798 ns |  3.11 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 258.15 ns | 1.627 ns | 1.358 ns |  3.81 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 248.55 ns | 3.111 ns | 2.758 ns |  3.67 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |  88.30 ns | 0.627 ns | 0.586 ns |  1.30 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 196.45 ns | 0.658 ns | 0.583 ns |  2.90 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  76.90 ns | 0.276 ns | 0.245 ns |  1.14 |    0.01 |      - |     - |     - |         - |

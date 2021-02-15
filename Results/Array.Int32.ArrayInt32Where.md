## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|              ForLoop |   100 |  80.94 ns | 0.645 ns | 0.603 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  80.71 ns | 0.719 ns | 0.637 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 502.80 ns | 5.224 ns | 4.631 ns |  6.21 |    0.08 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 293.90 ns | 2.380 ns | 1.988 ns |  3.63 |    0.04 | 0.3171 |     - |     - |     664 B |
|               LinqAF |   100 | 381.08 ns | 2.280 ns | 2.021 ns |  4.71 |    0.04 |      - |     - |     - |         - |
|           StructLinq |   100 | 255.27 ns | 3.148 ns | 2.629 ns |  3.15 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 193.45 ns | 1.207 ns | 1.129 ns |  2.39 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 251.71 ns | 1.668 ns | 1.479 ns |  3.11 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 186.31 ns | 0.754 ns | 0.669 ns |  2.30 |    0.02 |      - |     - |     - |         - |

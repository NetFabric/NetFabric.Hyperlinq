## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|              ForLoop |   100 |  68.51 ns | 0.604 ns | 0.535 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  80.68 ns | 0.583 ns | 0.546 ns |  1.18 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 676.85 ns | 5.341 ns | 4.735 ns |  9.88 |    0.11 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 344.28 ns | 1.985 ns | 1.760 ns |  5.03 |    0.05 | 0.3171 |     - |     - |     664 B |
|               LinqAF |   100 | 504.74 ns | 1.892 ns | 1.478 ns |  7.37 |    0.06 |      - |     - |     - |         - |
|           StructLinq |   100 | 396.16 ns | 3.533 ns | 3.132 ns |  5.78 |    0.07 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 187.02 ns | 1.792 ns | 1.676 ns |  2.73 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 421.63 ns | 2.329 ns | 2.065 ns |  6.15 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 211.95 ns | 1.406 ns | 1.246 ns |  3.09 |    0.03 |      - |     - |     - |         - |

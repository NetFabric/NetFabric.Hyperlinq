## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|               Method | Start | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  40.73 ns |  0.197 ns |  0.184 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 526.47 ns |  5.570 ns |  5.210 ns | 12.93 |    0.16 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 746.60 ns | 11.587 ns | 10.838 ns | 18.33 |    0.28 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 398.78 ns |  7.145 ns |  6.334 ns |  9.79 |    0.17 | 0.4053 |     - |     - |     848 B |
|      LinqFaster_SIMD |     0 |   100 | 166.02 ns |  1.055 ns |  0.936 ns |  4.07 |    0.03 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 782.17 ns |  8.019 ns |  6.696 ns | 19.20 |    0.22 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 259.06 ns |  3.875 ns |  3.625 ns |  6.36 |    0.08 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 | 166.02 ns |  0.484 ns |  0.453 ns |  4.08 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 284.44 ns |  2.632 ns |  2.462 ns |  6.98 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |   100 | 171.53 ns |  0.675 ns |  0.632 ns |  4.21 |    0.02 |      - |     - |     - |         - |

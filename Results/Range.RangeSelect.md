## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  39.20 ns | 0.255 ns | 0.226 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 509.65 ns | 3.436 ns | 3.046 ns | 13.00 |    0.11 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 641.46 ns | 4.853 ns | 4.052 ns | 16.36 |    0.14 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 329.62 ns | 2.576 ns | 2.410 ns |  8.40 |    0.08 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 477.82 ns | 3.603 ns | 3.370 ns | 12.19 |    0.12 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 233.02 ns | 1.571 ns | 1.393 ns |  5.94 |    0.05 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 | 171.80 ns | 1.041 ns | 0.974 ns |  4.38 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 346.03 ns | 1.992 ns | 1.863 ns |  8.84 |    0.07 |      - |     - |     - |         - |

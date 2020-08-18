## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  43.62 ns | 0.067 ns | 0.060 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 511.48 ns | 0.909 ns | 0.710 ns | 11.72 |    0.03 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 681.84 ns | 0.916 ns | 0.765 ns | 15.63 |    0.03 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 398.96 ns | 0.692 ns | 0.578 ns |  9.15 |    0.02 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 515.02 ns | 1.267 ns | 1.185 ns | 11.81 |    0.03 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 295.28 ns | 0.555 ns | 0.492 ns |  6.77 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |     0 |   100 | 184.38 ns | 0.139 ns | 0.130 ns |  4.23 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 352.79 ns | 0.357 ns | 0.334 ns |  8.09 |    0.01 |      - |     - |     - |         - |

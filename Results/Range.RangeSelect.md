## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

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
|              ForLoop |     0 |   100 |  43.67 ns | 0.111 ns | 0.104 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 510.62 ns | 0.622 ns | 0.520 ns | 11.70 |    0.03 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 681.98 ns | 0.556 ns | 0.464 ns | 15.62 |    0.04 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 352.78 ns | 0.557 ns | 0.435 ns |  8.08 |    0.02 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 532.29 ns | 0.315 ns | 0.246 ns | 12.19 |    0.03 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 294.18 ns | 1.197 ns | 1.061 ns |  6.74 |    0.03 |      - |     - |     - |         - |
| StructLinq_IFunction |     0 |   100 | 183.79 ns | 0.074 ns | 0.069 ns |  4.21 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 599.44 ns | 0.871 ns | 0.772 ns | 13.73 |    0.04 |      - |     - |     - |         - |

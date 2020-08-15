## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

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
|              ForLoop |     0 |   100 |  43.75 ns | 0.161 ns | 0.143 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 514.58 ns | 1.796 ns | 1.680 ns | 11.76 |    0.06 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 688.89 ns | 1.761 ns | 1.561 ns | 15.75 |    0.06 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 398.81 ns | 0.657 ns | 0.513 ns |  9.12 |    0.03 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 514.24 ns | 0.996 ns | 0.931 ns | 11.75 |    0.04 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 295.07 ns | 0.182 ns | 0.152 ns |  6.75 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |     0 |   100 | 184.42 ns | 0.127 ns | 0.112 ns |  4.22 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 401.70 ns | 0.290 ns | 0.242 ns |  9.18 |    0.03 |      - |     - |     - |         - |

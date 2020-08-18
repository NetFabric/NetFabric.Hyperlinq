## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|              ForLoop |     0 |   100 |  95.33 ns | 0.284 ns | 0.266 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 Linq |     0 |   100 | 250.27 ns | 0.160 ns | 0.134 ns |  2.62 |    0.01 | 0.2446 |     - |     - |     512 B |
|           LinqFaster |     0 |   100 | 284.41 ns | 0.637 ns | 0.596 ns |  2.98 |    0.01 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 898.61 ns | 2.505 ns | 2.221 ns |  9.43 |    0.04 | 0.7534 |     - |     - |    1576 B |
|           StructLinq |     0 |   100 | 573.58 ns | 0.746 ns | 0.623 ns |  6.02 |    0.02 | 0.2174 |     - |     - |     456 B |
| StructLinq_IFunction |     0 |   100 | 420.78 ns | 0.637 ns | 0.564 ns |  4.41 |    0.01 | 0.2179 |     - |     - |     456 B |
|            Hyperlinq |     0 |   100 | 277.96 ns | 0.472 ns | 0.394 ns |  2.92 |    0.01 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq_Pool |     0 |   100 | 304.63 ns | 0.883 ns | 0.826 ns |  3.20 |    0.01 | 0.0267 |     - |     - |      56 B |

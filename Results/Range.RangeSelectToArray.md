## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|              ForLoop |     0 |   100 |  95.02 ns | 0.298 ns | 0.264 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 Linq |     0 |   100 | 250.66 ns | 1.302 ns | 1.218 ns |  2.64 |    0.02 | 0.2446 |     - |     - |     512 B |
|           LinqFaster |     0 |   100 | 322.97 ns | 1.317 ns | 1.100 ns |  3.40 |    0.01 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 929.94 ns | 2.873 ns | 2.688 ns |  9.79 |    0.05 | 0.7534 |     - |     - |    1576 B |
|           StructLinq |     0 |   100 | 565.71 ns | 0.981 ns | 0.819 ns |  5.95 |    0.02 | 0.2174 |     - |     - |     456 B |
| StructLinq_IFunction |     0 |   100 | 435.34 ns | 0.974 ns | 0.911 ns |  4.58 |    0.01 | 0.2179 |     - |     - |     456 B |
|            Hyperlinq |     0 |   100 | 279.38 ns | 0.453 ns | 0.378 ns |  2.94 |    0.01 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq_Pool |     0 |   100 | 302.80 ns | 0.589 ns | 0.522 ns |  3.19 |    0.01 | 0.0267 |     - |     - |      56 B |

## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|              ForLoop |     0 |   100 |  95.97 ns | 0.374 ns | 0.349 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 Linq |     0 |   100 | 249.08 ns | 0.332 ns | 0.278 ns |  2.59 |    0.01 | 0.2446 |     - |     - |     512 B |
|           LinqFaster |     0 |   100 | 281.93 ns | 0.747 ns | 0.624 ns |  2.94 |    0.01 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 895.67 ns | 1.499 ns | 1.251 ns |  9.33 |    0.04 | 0.7534 |     - |     - |    1576 B |
|           StructLinq |     0 |   100 | 583.21 ns | 0.706 ns | 0.590 ns |  6.07 |    0.02 | 0.2174 |     - |     - |     456 B |
| StructLinq_IFunction |     0 |   100 | 413.56 ns | 0.951 ns | 0.843 ns |  4.31 |    0.02 | 0.2179 |     - |     - |     456 B |
|            Hyperlinq |     0 |   100 | 244.47 ns | 0.340 ns | 0.284 ns |  2.55 |    0.01 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq_Pool |     0 |   100 | 300.08 ns | 1.058 ns | 0.938 ns |  3.13 |    0.01 | 0.0267 |     - |     - |      56 B |

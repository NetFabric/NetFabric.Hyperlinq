## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|              ForLoop |     0 |   100 |  86.72 ns | 0.293 ns | 0.260 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 Linq |     0 |   100 | 229.98 ns | 1.169 ns | 1.036 ns |  2.65 |    0.02 | 0.2446 |     - |     - |     512 B |
|           LinqFaster |     0 |   100 | 285.70 ns | 2.418 ns | 2.262 ns |  3.29 |    0.03 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 861.86 ns | 5.305 ns | 4.703 ns |  9.94 |    0.06 | 0.7534 |     - |     - |    1576 B |
|           StructLinq |     0 |   100 | 424.04 ns | 2.591 ns | 2.297 ns |  4.89 |    0.03 | 0.2141 |     - |     - |     448 B |
| StructLinq_IFunction |     0 |   100 | 297.99 ns | 1.316 ns | 1.167 ns |  3.44 |    0.02 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq |     0 |   100 | 230.20 ns | 1.402 ns | 1.242 ns |  2.65 |    0.02 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq_Pool |     0 |   100 | 295.32 ns | 2.391 ns | 2.120 ns |  3.41 |    0.02 | 0.0267 |     - |     - |      56 B |

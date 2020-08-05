## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

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
|              ForLoop |     0 |   100 |  89.19 ns | 0.645 ns | 0.603 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 Linq |     0 |   100 | 226.17 ns | 1.055 ns | 0.935 ns |  2.54 |    0.02 | 0.2446 |     - |     - |     512 B |
|           LinqFaster |     0 |   100 | 312.18 ns | 1.848 ns | 1.638 ns |  3.50 |    0.02 | 0.4053 |     - |     - |     848 B |
|           StructLinq |     0 |   100 | 521.55 ns | 4.406 ns | 4.122 ns |  5.85 |    0.06 | 0.2174 |     - |     - |     456 B |
| StructLinq_IFunction |     0 |   100 | 380.36 ns | 1.821 ns | 1.614 ns |  4.27 |    0.03 | 0.2179 |     - |     - |     456 B |
|            Hyperlinq |     0 |   100 | 235.64 ns | 1.707 ns | 1.513 ns |  2.64 |    0.03 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq_Pool |     0 |   100 | 300.15 ns | 1.310 ns | 1.226 ns |  3.37 |    0.03 | 0.0267 |     - |     - |      56 B |

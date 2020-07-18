## RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/RangeSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  86.16 ns | 0.318 ns | 0.282 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 Linq |     0 |   100 | 250.24 ns | 2.185 ns | 2.044 ns |  2.90 |    0.03 | 0.2446 |     - |     - |     512 B |
|           LinqFaster |     0 |   100 | 261.99 ns | 2.294 ns | 1.916 ns |  3.04 |    0.02 | 0.4053 |     - |     - |     848 B |
|           StructLinq |     0 |   100 | 532.53 ns | 2.882 ns | 2.555 ns |  6.18 |    0.04 | 0.7839 |     - |     - |    1640 B |
| StructLinq_IFunction |     0 |   100 | 357.30 ns | 2.565 ns | 2.274 ns |  4.15 |    0.03 | 0.7839 |     - |     - |    1640 B |
|            Hyperlinq |     0 |   100 | 257.29 ns | 1.669 ns | 1.561 ns |  2.99 |    0.02 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq_Pool |     0 |   100 | 273.18 ns | 0.811 ns | 0.633 ns |  3.17 |    0.01 | 0.0267 |     - |     - |      56 B |

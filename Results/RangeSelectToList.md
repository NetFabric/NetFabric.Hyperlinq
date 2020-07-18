## RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/RangeSelectToList.cs)

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
|               Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 | 298.1 ns | 2.31 ns | 2.05 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|          ForeachLoop |     0 |   100 | 707.6 ns | 3.70 ns | 2.89 ns |  2.37 |    0.02 | 0.5922 |     - |     - |    1240 B |
|                 Linq |     0 |   100 | 357.1 ns | 1.40 ns | 1.17 ns |  1.20 |    0.01 | 0.2599 |     - |     - |     544 B |
|           LinqFaster |     0 |   100 | 333.2 ns | 1.00 ns | 0.84 ns |  1.12 |    0.01 | 0.6232 |     - |     - |    1304 B |
|           StructLinq |     0 |   100 | 495.1 ns | 4.10 ns | 3.43 ns |  1.66 |    0.02 | 0.5808 |     - |     - |    1216 B |
| StructLinq_IFunction |     0 |   100 | 324.7 ns | 3.43 ns | 3.21 ns |  1.09 |    0.01 | 0.5813 |     - |     - |    1216 B |
|            Hyperlinq |     0 |   100 | 251.5 ns | 1.17 ns | 1.09 ns |  0.84 |    0.01 | 0.2446 |     - |     - |     512 B |

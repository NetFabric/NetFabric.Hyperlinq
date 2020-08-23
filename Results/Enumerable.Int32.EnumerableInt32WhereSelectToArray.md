## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|               Method | Count |       Mean |    Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   669.5 ns |  5.07 ns | 4.74 ns |  1.00 |    0.00 | 0.4358 |     - |     - |     912 B |
|                 Linq |   100 | 1,080.9 ns | 10.11 ns | 9.46 ns |  1.61 |    0.02 | 0.3967 |     - |     - |     832 B |
|               LinqAF |   100 | 1,268.5 ns |  9.92 ns | 9.28 ns |  1.89 |    0.01 | 0.4177 |     - |     - |     880 B |
|           StructLinq |   100 | 1,126.8 ns | 10.68 ns | 9.99 ns |  1.68 |    0.02 | 0.1678 |     - |     - |     352 B |
| StructLinq_IFunction |   100 |   747.8 ns |  3.15 ns | 2.79 ns |  1.12 |    0.01 | 0.1259 |     - |     - |     264 B |
|            Hyperlinq |   100 | 1,047.9 ns |  6.04 ns | 5.35 ns |  1.57 |    0.02 | 0.1259 |     - |     - |     264 B |
|       Hyperlinq_Pool |   100 | 1,129.6 ns |  8.83 ns | 8.26 ns |  1.69 |    0.02 | 0.0458 |     - |     - |      96 B |

## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|               Method | Count |       Mean |    Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   676.3 ns |  5.06 ns | 4.73 ns |  1.00 |    0.00 | 0.4358 |     - |     - |     912 B |
|                 Linq |   100 | 1,006.0 ns |  4.87 ns | 4.56 ns |  1.49 |    0.01 | 0.3967 |     - |     - |     832 B |
|           StructLinq |   100 | 1,081.7 ns | 11.81 ns | 9.86 ns |  1.60 |    0.02 | 0.1450 |     - |     - |     304 B |
| StructLinq_IFunction |   100 |   752.1 ns |  5.07 ns | 4.75 ns |  1.11 |    0.01 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq |   100 | 1,082.6 ns |  8.95 ns | 8.37 ns |  1.60 |    0.01 | 0.1259 |     - |     - |     264 B |
|       Hyperlinq_Pool |   100 | 1,102.1 ns |  7.54 ns | 7.05 ns |  1.63 |    0.01 | 0.0458 |     - |     - |      96 B |

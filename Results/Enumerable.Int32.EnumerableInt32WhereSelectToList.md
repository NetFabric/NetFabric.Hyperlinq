## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   659.9 ns | 11.70 ns | 10.94 ns |  1.00 |    0.00 | 0.3281 |     - |     - |     688 B |
|                 Linq |   100 | 1,028.0 ns |  7.33 ns |  6.49 ns |  1.56 |    0.03 | 0.3853 |     - |     - |     808 B |
|               LinqAF |   100 | 1,257.9 ns |  6.16 ns |  5.46 ns |  1.90 |    0.03 | 0.3281 |     - |     - |     688 B |
|           StructLinq |   100 | 1,189.7 ns |  7.34 ns |  6.13 ns |  1.80 |    0.03 | 0.1831 |     - |     - |     384 B |
| StructLinq_IFunction |   100 |   751.8 ns |  4.33 ns |  3.84 ns |  1.14 |    0.02 | 0.1411 |     - |     - |     296 B |
|            Hyperlinq |   100 | 1,120.8 ns |  7.63 ns |  6.76 ns |  1.70 |    0.03 | 0.1755 |     - |     - |     368 B |

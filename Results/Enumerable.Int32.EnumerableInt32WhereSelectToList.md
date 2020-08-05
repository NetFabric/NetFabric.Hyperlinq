## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   662.5 ns |  8.48 ns |  7.52 ns |  1.00 |    0.00 | 0.3281 |     - |     - |     688 B |
|                 Linq |   100 | 1,036.2 ns | 16.20 ns | 13.53 ns |  1.56 |    0.03 | 0.3853 |     - |     - |     808 B |
|           StructLinq |   100 | 1,095.6 ns |  9.16 ns |  8.57 ns |  1.65 |    0.02 | 0.1602 |     - |     - |     336 B |
| StructLinq_IFunction |   100 |   766.4 ns |  8.81 ns |  7.36 ns |  1.16 |    0.02 | 0.1602 |     - |     - |     336 B |
|            Hyperlinq |   100 | 1,073.6 ns |  8.84 ns |  7.39 ns |  1.62 |    0.02 | 0.1755 |     - |     - |     368 B |

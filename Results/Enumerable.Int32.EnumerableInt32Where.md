## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                 Linq |   100 | 913.4 ns | 12.28 ns | 10.89 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|           StructLinq |   100 | 779.1 ns |  7.79 ns |  9.85 ns |  0.85 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 578.2 ns |  4.22 ns |  3.95 ns |  0.63 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 828.6 ns |  6.42 ns |  6.01 ns |  0.91 |    0.01 | 0.0191 |     - |     - |      40 B |

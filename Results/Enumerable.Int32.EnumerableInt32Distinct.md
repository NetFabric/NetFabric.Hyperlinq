## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 | 1.923 μs | 0.0185 μs | 0.0155 μs |  1.00 |    0.00 | 2.8877 |     - |     - |    6048 B |
|                 Linq |   100 | 2.819 μs | 0.0191 μs | 0.0149 μs |  1.47 |    0.02 | 2.0638 |     - |     - |    4320 B |
|               LinqAF |   100 | 3.973 μs | 0.0240 μs | 0.0224 μs |  2.07 |    0.03 | 2.5024 |     - |     - |    5240 B |
|           StructLinq |   100 | 2.285 μs | 0.0219 μs | 0.0205 μs |  1.19 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 2.227 μs | 0.0186 μs | 0.0164 μs |  1.16 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 2.124 μs | 0.0157 μs | 0.0147 μs |  1.10 |    0.01 | 0.0191 |     - |     - |      40 B |

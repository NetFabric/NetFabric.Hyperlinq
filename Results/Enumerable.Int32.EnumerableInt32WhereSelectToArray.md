## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   805.9 ns |  1.18 ns |  0.99 ns |  1.00 |    0.00 | 0.4358 |     - |     - |     912 B |
|                 Linq |   100 | 1,179.6 ns |  1.85 ns |  1.54 ns |  1.46 |    0.00 | 0.3967 |     - |     - |     832 B |
|               LinqAF |   100 | 1,482.8 ns |  3.71 ns |  3.29 ns |  1.84 |    0.01 | 0.4196 |     - |     - |     880 B |
|           StructLinq |   100 | 1,213.1 ns |  3.27 ns |  2.90 ns |  1.50 |    0.00 | 0.1450 |     - |     - |     304 B |
| StructLinq_IFunction |   100 |   826.0 ns |  2.41 ns |  2.14 ns |  1.03 |    0.00 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq |   100 | 1,180.9 ns | 16.88 ns | 16.58 ns |  1.47 |    0.02 | 0.1259 |     - |     - |     264 B |
|       Hyperlinq_Pool |   100 | 1,236.5 ns |  2.64 ns |  2.47 ns |  1.53 |    0.00 | 0.0458 |     - |     - |      96 B |

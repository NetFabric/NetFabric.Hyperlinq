## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

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
|          ForeachLoop |   100 |   859.8 ns | 13.19 ns | 11.01 ns |  1.00 |    0.00 | 0.3281 |     - |     - |     688 B |
|                 Linq |   100 | 1,094.9 ns |  1.18 ns |  1.05 ns |  1.27 |    0.02 | 0.3853 |     - |     - |     808 B |
|               LinqAF |   100 | 1,419.4 ns |  3.42 ns |  3.20 ns |  1.65 |    0.02 | 0.3281 |     - |     - |     688 B |
|           StructLinq |   100 | 1,187.1 ns |  2.09 ns |  1.74 ns |  1.38 |    0.02 | 0.1602 |     - |     - |     336 B |
| StructLinq_IFunction |   100 |   852.7 ns |  2.22 ns |  2.08 ns |  0.99 |    0.01 | 0.1602 |     - |     - |     336 B |
|            Hyperlinq |   100 | 1,251.5 ns |  2.00 ns |  1.56 ns |  1.46 |    0.02 | 0.1755 |     - |     - |     368 B |

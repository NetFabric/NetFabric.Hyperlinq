## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   883.6 ns | 2.08 ns | 1.95 ns |  1.00 | 0.4358 |     - |     - |     912 B |
|                 Linq |   100 | 1,172.1 ns | 3.43 ns | 3.04 ns |  1.33 | 0.3967 |     - |     - |     832 B |
|               LinqAF |   100 | 1,453.8 ns | 2.80 ns | 2.34 ns |  1.65 | 0.4196 |     - |     - |     880 B |
|           StructLinq |   100 | 1,196.3 ns | 1.27 ns | 1.06 ns |  1.35 | 0.1450 |     - |     - |     304 B |
| StructLinq_IFunction |   100 |   912.0 ns | 2.63 ns | 2.34 ns |  1.03 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq |   100 | 1,264.7 ns | 2.07 ns | 1.83 ns |  1.43 | 0.1259 |     - |     - |     264 B |
|       Hyperlinq_Pool |   100 | 1,200.3 ns | 2.55 ns | 2.13 ns |  1.36 | 0.0458 |     - |     - |      96 B |

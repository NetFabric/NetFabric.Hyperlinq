## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|--------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   800.8 ns |  2.88 ns | 2.56 ns |  1.00 | 0.4358 |     - |     - |     912 B |
|                 Linq |   100 | 1,172.9 ns |  6.18 ns | 5.48 ns |  1.46 | 0.3967 |     - |     - |     832 B |
|               LinqAF |   100 | 1,412.6 ns |  2.80 ns | 2.62 ns |  1.76 | 0.4196 |     - |     - |     880 B |
|           StructLinq |   100 | 1,221.8 ns |  2.41 ns | 2.01 ns |  1.53 | 0.1450 |     - |     - |     304 B |
| StructLinq_IFunction |   100 |   888.8 ns |  2.26 ns | 2.00 ns |  1.11 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq |   100 | 1,270.4 ns | 10.75 ns | 9.53 ns |  1.59 | 0.1259 |     - |     - |     264 B |
|       Hyperlinq_Pool |   100 | 1,300.8 ns |  3.08 ns | 2.73 ns |  1.62 | 0.0458 |     - |     - |      96 B |

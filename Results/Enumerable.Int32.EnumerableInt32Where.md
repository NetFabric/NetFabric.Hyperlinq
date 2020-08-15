## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                 Linq |   100 | 1,007.7 ns | 2.53 ns | 2.11 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 |   872.5 ns | 1.70 ns | 1.59 ns |  0.87 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   902.9 ns | 1.66 ns | 1.39 ns |  0.90 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   679.9 ns | 1.92 ns | 1.70 ns |  0.67 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 |   909.4 ns | 1.88 ns | 1.57 ns |  0.90 | 0.0191 |     - |     - |      40 B |

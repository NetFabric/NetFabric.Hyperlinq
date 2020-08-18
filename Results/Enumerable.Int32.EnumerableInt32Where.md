## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                 Linq |   100 | 1,001.9 ns | 5.35 ns | 4.46 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 |   909.6 ns | 2.33 ns | 1.95 ns |  0.91 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   910.3 ns | 1.76 ns | 1.64 ns |  0.91 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   678.6 ns | 1.73 ns | 1.62 ns |  0.68 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 |   893.4 ns | 1.31 ns | 1.17 ns |  0.89 | 0.0191 |     - |     - |      40 B |

## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                 Linq |   100 | 924.7 ns | 0.85 ns | 0.71 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 | 932.4 ns | 1.47 ns | 1.37 ns |  1.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 856.6 ns | 1.24 ns | 1.10 ns |  0.93 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 678.8 ns | 2.91 ns | 2.73 ns |  0.73 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 974.1 ns | 1.88 ns | 1.76 ns |  1.05 | 0.0191 |     - |     - |      40 B |

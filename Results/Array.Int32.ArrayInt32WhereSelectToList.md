## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|              ForLoop |   100 | 255.3 ns | 0.39 ns | 0.35 ns |  1.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 | 226.4 ns | 0.50 ns | 0.47 ns |  0.89 | 0.3097 |     - |     - |     648 B |
|                 Linq |   100 | 623.3 ns | 2.15 ns | 1.91 ns |  2.44 | 0.3595 |     - |     - |     752 B |
|           LinqFaster |   100 | 439.0 ns | 0.96 ns | 0.80 ns |  1.72 | 0.4320 |     - |     - |     904 B |
|               LinqAF |   100 | 847.5 ns | 2.98 ns | 2.49 ns |  3.32 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 | 718.8 ns | 1.82 ns | 1.70 ns |  2.81 | 0.1450 |     - |     - |     304 B |
| StructLinq_IFunction |   100 | 412.8 ns | 1.55 ns | 1.45 ns |  1.62 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq |   100 | 787.1 ns | 1.25 ns | 0.97 ns |  3.08 | 0.1564 |     - |     - |     328 B |

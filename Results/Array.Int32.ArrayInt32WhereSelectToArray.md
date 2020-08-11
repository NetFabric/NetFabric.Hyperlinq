## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|              ForLoop |   100 | 298.8 ns | 0.51 ns | 0.43 ns |  1.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 | 296.9 ns | 0.33 ns | 0.26 ns |  0.99 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 | 624.5 ns | 1.59 ns | 1.33 ns |  2.09 | 0.3710 |     - |     - |     776 B |
|           LinqFaster |   100 | 351.5 ns | 0.72 ns | 0.63 ns |  1.18 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 885.1 ns | 2.08 ns | 1.95 ns |  2.96 | 0.4015 |     - |     - |     840 B |
|           StructLinq |   100 | 723.0 ns | 1.71 ns | 1.52 ns |  2.42 | 0.1297 |     - |     - |     272 B |
| StructLinq_IFunction |   100 | 426.0 ns | 0.77 ns | 0.64 ns |  1.43 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq |   100 | 698.9 ns | 2.92 ns | 2.73 ns |  2.34 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 | 770.5 ns | 1.23 ns | 1.03 ns |  2.58 | 0.0267 |     - |     - |      56 B |

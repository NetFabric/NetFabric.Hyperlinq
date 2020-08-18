## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 267.8 ns | 0.31 ns | 0.24 ns |  1.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 | 309.2 ns | 0.96 ns | 0.85 ns |  1.15 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 | 654.3 ns | 3.53 ns | 2.75 ns |  2.44 | 0.3710 |     - |     - |     776 B |
|           LinqFaster |   100 | 391.6 ns | 1.63 ns | 1.53 ns |  1.46 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 880.2 ns | 1.81 ns | 1.61 ns |  3.29 | 0.4015 |     - |     - |     840 B |
|           StructLinq |   100 | 711.5 ns | 0.41 ns | 0.32 ns |  2.66 | 0.1297 |     - |     - |     272 B |
| StructLinq_IFunction |   100 | 413.5 ns | 0.92 ns | 0.81 ns |  1.54 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq |   100 | 686.1 ns | 2.11 ns | 1.76 ns |  2.56 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 | 738.6 ns | 1.36 ns | 1.20 ns |  2.76 | 0.0267 |     - |     - |      56 B |

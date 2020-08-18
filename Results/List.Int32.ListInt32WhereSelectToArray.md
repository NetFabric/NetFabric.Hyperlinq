## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|              ForLoop |   100 |   362.5 ns | 1.14 ns | 1.07 ns |  1.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 |   492.0 ns | 3.46 ns | 3.23 ns |  1.36 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 |   658.4 ns | 1.55 ns | 1.45 ns |  1.82 | 0.3939 |     - |     - |     824 B |
|           LinqFaster |   100 |   584.3 ns | 0.58 ns | 0.46 ns |  1.61 | 0.4168 |     - |     - |     872 B |
|               LinqAF |   100 | 1,267.8 ns | 1.77 ns | 1.38 ns |  3.50 | 0.4005 |     - |     - |     840 B |
|           StructLinq |   100 |   684.0 ns | 1.99 ns | 1.76 ns |  1.89 | 0.1297 |     - |     - |     272 B |
| StructLinq_IFunction |   100 |   410.1 ns | 1.27 ns | 1.06 ns |  1.13 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq |   100 |   696.8 ns | 1.77 ns | 1.48 ns |  1.92 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 |   714.7 ns | 0.66 ns | 0.55 ns |  1.97 | 0.0267 |     - |     - |      56 B |

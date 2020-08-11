## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|              ForLoop |   100 |   314.1 ns | 0.37 ns | 0.29 ns |  1.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 |   425.0 ns | 0.93 ns | 0.87 ns |  1.35 | 0.3095 |     - |     - |     648 B |
|                 Linq |   100 |   637.2 ns | 1.03 ns | 0.86 ns |  2.03 | 0.3824 |     - |     - |     800 B |
|           LinqFaster |   100 |   578.1 ns | 1.27 ns | 1.06 ns |  1.84 | 0.4320 |     - |     - |     904 B |
|               LinqAF |   100 | 1,352.5 ns | 2.76 ns | 2.31 ns |  4.31 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 |   712.2 ns | 0.97 ns | 0.81 ns |  2.27 | 0.1450 |     - |     - |     304 B |
| StructLinq_IFunction |   100 |   412.0 ns | 2.33 ns | 2.06 ns |  1.31 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq |   100 |   742.8 ns | 2.57 ns | 2.41 ns |  2.36 | 0.1564 |     - |     - |     328 B |

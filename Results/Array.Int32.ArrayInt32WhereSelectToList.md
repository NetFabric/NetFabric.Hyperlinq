## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|              ForLoop |   100 | 271.6 ns | 0.35 ns | 0.29 ns |  1.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 | 234.9 ns | 0.44 ns | 0.37 ns |  0.86 | 0.3095 |     - |     - |     648 B |
|                 Linq |   100 | 595.6 ns | 1.69 ns | 1.58 ns |  2.19 | 0.3595 |     - |     - |     752 B |
|           LinqFaster |   100 | 430.2 ns | 1.15 ns | 1.08 ns |  1.58 | 0.4320 |     - |     - |     904 B |
|               LinqAF |   100 | 816.7 ns | 2.86 ns | 2.53 ns |  3.01 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 | 713.7 ns | 1.78 ns | 1.66 ns |  2.63 | 0.1450 |     - |     - |     304 B |
| StructLinq_IFunction |   100 | 419.4 ns | 0.68 ns | 0.53 ns |  1.54 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq |   100 | 734.6 ns | 1.09 ns | 0.91 ns |  2.70 | 0.1564 |     - |     - |     328 B |

## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|              ForLoop |   100 |   982.4 ns | 1.29 ns | 1.01 ns |  1.00 | 2.4433 |     - |     - |   4.99 KB |
|          ForeachLoop |   100 |   985.5 ns | 3.56 ns | 3.15 ns |  1.00 | 2.4433 |     - |     - |   4.99 KB |
|                 Linq |   100 | 1,385.7 ns | 4.94 ns | 4.38 ns |  1.41 | 2.5234 |     - |     - |   5.16 KB |
|           LinqFaster |   100 | 1,401.7 ns | 1.85 ns | 1.54 ns |  1.43 | 3.8719 |     - |     - |   7.91 KB |
|               LinqAF |   100 | 2,420.9 ns | 3.66 ns | 3.06 ns |  2.46 | 2.4414 |     - |     - |   4.99 KB |
|           StructLinq |   100 | 1,610.9 ns | 4.77 ns | 4.46 ns |  1.64 | 1.0052 |     - |     - |   2.05 KB |
| StructLinq_IFunction |   100 |   974.6 ns | 1.70 ns | 1.42 ns |  0.99 | 1.0052 |     - |     - |   2.05 KB |
|            Hyperlinq |   100 | 1,435.8 ns | 4.94 ns | 4.38 ns |  1.46 | 1.0166 |     - |     - |   2.08 KB |

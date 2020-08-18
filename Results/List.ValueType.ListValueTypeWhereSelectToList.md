## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|              ForLoop |   100 |   988.9 ns | 5.01 ns | 4.44 ns |  1.00 | 2.4433 |     - |     - |   4.99 KB |
|          ForeachLoop |   100 | 1,256.7 ns | 3.09 ns | 2.58 ns |  1.27 | 2.4433 |     - |     - |   4.99 KB |
|                 Linq |   100 | 1,404.3 ns | 4.29 ns | 4.01 ns |  1.42 | 2.5768 |     - |     - |   5.27 KB |
|           LinqFaster |   100 | 1,542.9 ns | 4.16 ns | 3.47 ns |  1.56 | 3.4237 |     - |     - |      7 KB |
|               LinqAF |   100 | 2,887.7 ns | 7.19 ns | 6.38 ns |  2.92 | 2.4414 |     - |     - |   4.99 KB |
|           StructLinq |   100 | 1,616.8 ns | 3.17 ns | 2.97 ns |  1.64 | 1.0052 |     - |     - |   2.05 KB |
| StructLinq_IFunction |   100 |   946.4 ns | 1.93 ns | 1.71 ns |  0.96 | 1.0052 |     - |     - |   2.05 KB |
|            Hyperlinq |   100 | 1,426.7 ns | 3.65 ns | 3.24 ns |  1.44 | 1.0166 |     - |     - |   2.08 KB |

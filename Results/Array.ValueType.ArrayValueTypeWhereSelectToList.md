## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|              ForLoop |   100 | 1,008.2 ns | 2.24 ns | 1.98 ns |  1.00 | 2.4433 |     - |     - |   4.99 KB |
|          ForeachLoop |   100 | 1,004.0 ns | 2.63 ns | 2.46 ns |  1.00 | 2.4433 |     - |     - |   4.99 KB |
|                 Linq |   100 | 1,390.5 ns | 5.06 ns | 4.73 ns |  1.38 | 2.5234 |     - |     - |   5.16 KB |
|           LinqFaster |   100 | 1,407.1 ns | 4.09 ns | 3.63 ns |  1.40 | 3.8719 |     - |     - |   7.91 KB |
|               LinqAF |   100 | 2,382.6 ns | 8.45 ns | 7.06 ns |  2.36 | 2.4414 |     - |     - |   4.99 KB |
|           StructLinq |   100 | 1,586.0 ns | 5.85 ns | 5.47 ns |  1.57 | 1.0052 |     - |     - |   2.05 KB |
| StructLinq_IFunction |   100 |   947.8 ns | 2.64 ns | 2.47 ns |  0.94 | 1.0052 |     - |     - |   2.05 KB |
|            Hyperlinq |   100 | 1,425.8 ns | 2.61 ns | 2.44 ns |  1.41 | 1.0166 |     - |     - |   2.08 KB |

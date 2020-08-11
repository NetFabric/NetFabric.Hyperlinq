## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|              ForLoop |   100 |   988.5 ns | 1.94 ns | 1.62 ns |  1.00 | 2.4433 |     - |     - |   4.99 KB |
|          ForeachLoop |   100 |   988.9 ns | 2.38 ns | 2.11 ns |  1.00 | 2.4433 |     - |     - |   4.99 KB |
|                 Linq |   100 | 1,384.2 ns | 5.18 ns | 4.60 ns |  1.40 | 2.5234 |     - |     - |   5.16 KB |
|           LinqFaster |   100 | 1,397.0 ns | 2.38 ns | 1.99 ns |  1.41 | 3.8719 |     - |     - |   7.91 KB |
|               LinqAF |   100 | 2,354.1 ns | 3.92 ns | 3.27 ns |  2.38 | 2.4414 |     - |     - |   4.99 KB |
|           StructLinq |   100 | 1,591.3 ns | 1.57 ns | 1.23 ns |  1.61 | 1.0052 |     - |     - |   2.05 KB |
| StructLinq_IFunction |   100 |   938.7 ns | 2.47 ns | 2.19 ns |  0.95 | 1.0052 |     - |     - |   2.05 KB |
|            Hyperlinq |   100 | 1,417.9 ns | 5.09 ns | 4.51 ns |  1.43 | 1.0166 |     - |     - |   2.08 KB |

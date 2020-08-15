## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 310.0 ns | 0.84 ns | 0.75 ns |  1.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 | 272.6 ns | 0.67 ns | 0.56 ns |  0.88 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 | 636.5 ns | 1.95 ns | 1.52 ns |  2.05 | 0.3710 |     - |     - |     776 B |
|           LinqFaster |   100 | 461.4 ns | 2.86 ns | 2.67 ns |  1.49 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 893.6 ns | 2.92 ns | 2.59 ns |  2.88 | 0.4015 |     - |     - |     840 B |
|           StructLinq |   100 | 717.9 ns | 1.59 ns | 1.33 ns |  2.32 | 0.1297 |     - |     - |     272 B |
| StructLinq_IFunction |   100 | 435.5 ns | 0.75 ns | 0.67 ns |  1.41 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq |   100 | 697.0 ns | 3.44 ns | 3.22 ns |  2.25 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 | 826.6 ns | 1.91 ns | 1.49 ns |  2.67 | 0.0267 |     - |     - |      56 B |

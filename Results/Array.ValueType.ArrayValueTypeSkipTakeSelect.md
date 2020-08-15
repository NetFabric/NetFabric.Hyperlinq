## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|            Method | Skip | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 | 1.632 μs | 0.0026 μs | 0.0025 μs |  1.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 | 4.689 μs | 0.0227 μs | 0.0190 μs |  2.87 | 0.0153 |     - |     - |      32 B |
|              Linq | 1000 |   100 | 2.803 μs | 0.0049 μs | 0.0043 μs |  1.72 | 0.1183 |     - |     - |     248 B |
|        LinqFaster | 1000 |   100 | 2.850 μs | 0.0108 μs | 0.0101 μs |  1.75 | 5.7678 |     - |     - |   12072 B |
|            LinqAF | 1000 |   100 | 7.146 μs | 0.0120 μs | 0.0094 μs |  4.38 |      - |     - |     - |         - |
|        StructLinq | 1000 |   100 | 2.869 μs | 0.0031 μs | 0.0029 μs |  1.76 | 0.0763 |     - |     - |     160 B |
| Hyperlinq_Foreach | 1000 |   100 | 2.125 μs | 0.0020 μs | 0.0016 μs |  1.30 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 | 2.093 μs | 0.0013 μs | 0.0012 μs |  1.28 |      - |     - |     - |         - |

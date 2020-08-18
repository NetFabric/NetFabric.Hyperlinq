## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|            Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 | 1.652 μs | 0.0011 μs | 0.0009 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 | 4.670 μs | 0.0244 μs | 0.0204 μs |  2.83 |    0.01 | 0.0153 |     - |     - |      32 B |
|              Linq | 1000 |   100 | 2.791 μs | 0.0042 μs | 0.0038 μs |  1.69 |    0.00 | 0.1183 |     - |     - |     248 B |
|        LinqFaster | 1000 |   100 | 2.835 μs | 0.0067 μs | 0.0056 μs |  1.72 |    0.00 | 5.7678 |     - |     - |   12072 B |
|            LinqAF | 1000 |   100 | 7.165 μs | 0.0511 μs | 0.0478 μs |  4.33 |    0.03 |      - |     - |     - |         - |
|        StructLinq | 1000 |   100 | 2.858 μs | 0.0029 μs | 0.0024 μs |  1.73 |    0.00 | 0.0763 |     - |     - |     160 B |
| Hyperlinq_Foreach | 1000 |   100 | 2.066 μs | 0.0027 μs | 0.0024 μs |  1.25 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 | 2.119 μs | 0.0017 μs | 0.0014 μs |  1.28 |    0.00 |      - |     - |     - |         - |

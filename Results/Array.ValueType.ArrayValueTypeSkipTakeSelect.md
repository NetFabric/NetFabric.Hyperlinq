## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|            Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 | 1.653 μs | 0.0043 μs | 0.0040 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 | 4.166 μs | 0.0025 μs | 0.0021 μs |  2.52 |    0.01 | 0.0153 |     - |     - |      32 B |
|              Linq | 1000 |   100 | 2.792 μs | 0.0031 μs | 0.0027 μs |  1.69 |    0.00 | 0.1183 |     - |     - |     248 B |
|        LinqFaster | 1000 |   100 | 2.871 μs | 0.0104 μs | 0.0092 μs |  1.74 |    0.01 | 5.7678 |     - |     - |   12072 B |
|            LinqAF | 1000 |   100 | 7.177 μs | 0.0859 μs | 0.0804 μs |  4.34 |    0.05 |      - |     - |     - |         - |
|        StructLinq | 1000 |   100 | 2.867 μs | 0.0034 μs | 0.0032 μs |  1.73 |    0.01 | 0.0763 |     - |     - |     160 B |
| Hyperlinq_Foreach | 1000 |   100 | 2.090 μs | 0.0009 μs | 0.0007 μs |  1.26 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 | 2.115 μs | 0.0010 μs | 0.0008 μs |  1.28 |    0.00 |      - |     - |     - |         - |

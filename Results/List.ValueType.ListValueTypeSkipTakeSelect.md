## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|            Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 |  1.709 μs | 0.0015 μs | 0.0013 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 |  7.362 μs | 0.0242 μs | 0.0215 μs |  4.31 |    0.01 | 0.0305 |     - |     - |      72 B |
|              Linq | 1000 |   100 |  2.714 μs | 0.0036 μs | 0.0032 μs |  1.59 |    0.00 | 0.1183 |     - |     - |     248 B |
|        LinqFaster | 1000 |   100 |  3.856 μs | 0.0084 μs | 0.0075 μs |  2.26 |    0.00 | 5.8136 |     - |     - |   12168 B |
|            LinqAF | 1000 |   100 | 11.765 μs | 0.0328 μs | 0.0306 μs |  6.88 |    0.02 |      - |     - |     - |         - |
|        StructLinq | 1000 |   100 |  2.798 μs | 0.0052 μs | 0.0048 μs |  1.64 |    0.00 | 0.0763 |     - |     - |     160 B |
| Hyperlinq_Foreach | 1000 |   100 |  2.085 μs | 0.0004 μs | 0.0003 μs |  1.22 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 |  2.109 μs | 0.0004 μs | 0.0003 μs |  1.23 |    0.00 |      - |     - |     - |         - |

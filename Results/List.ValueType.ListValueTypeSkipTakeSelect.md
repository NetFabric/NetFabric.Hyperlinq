## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|            Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 |  1.722 μs | 0.0015 μs | 0.0011 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 |  7.229 μs | 0.0195 μs | 0.0183 μs |  4.20 |    0.01 | 0.0305 |     - |     - |      72 B |
|              Linq | 1000 |   100 |  2.740 μs | 0.0051 μs | 0.0045 μs |  1.59 |    0.00 | 0.1183 |     - |     - |     248 B |
|        LinqFaster | 1000 |   100 |  3.773 μs | 0.0048 μs | 0.0038 μs |  2.19 |    0.00 | 5.8136 |     - |     - |   12168 B |
|            LinqAF | 1000 |   100 | 11.799 μs | 0.0388 μs | 0.0363 μs |  6.85 |    0.02 |      - |     - |     - |         - |
|        StructLinq | 1000 |   100 |  2.783 μs | 0.0012 μs | 0.0010 μs |  1.62 |    0.00 | 0.0763 |     - |     - |     160 B |
| Hyperlinq_Foreach | 1000 |   100 |  2.059 μs | 0.0010 μs | 0.0008 μs |  1.20 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 |  2.110 μs | 0.0011 μs | 0.0009 μs |  1.23 |    0.00 |      - |     - |     - |         - |

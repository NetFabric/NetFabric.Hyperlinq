## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|            Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 |  1.712 μs | 0.0024 μs | 0.0022 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 |  7.271 μs | 0.0156 μs | 0.0146 μs |  4.25 |    0.01 | 0.0305 |     - |     - |      72 B |
|              Linq | 1000 |   100 |  2.750 μs | 0.0029 μs | 0.0026 μs |  1.61 |    0.00 | 0.1183 |     - |     - |     248 B |
|        LinqFaster | 1000 |   100 |  3.849 μs | 0.0074 μs | 0.0062 μs |  2.25 |    0.00 | 5.8136 |     - |     - |   12168 B |
|            LinqAF | 1000 |   100 | 11.791 μs | 0.0250 μs | 0.0233 μs |  6.89 |    0.02 |      - |     - |     - |         - |
|        StructLinq | 1000 |   100 |  2.775 μs | 0.0025 μs | 0.0021 μs |  1.62 |    0.00 | 0.0763 |     - |     - |     160 B |
| Hyperlinq_Foreach | 1000 |   100 |  2.116 μs | 0.0006 μs | 0.0005 μs |  1.24 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 |  2.083 μs | 0.0010 μs | 0.0008 μs |  1.22 |    0.00 |      - |     - |     - |         - |

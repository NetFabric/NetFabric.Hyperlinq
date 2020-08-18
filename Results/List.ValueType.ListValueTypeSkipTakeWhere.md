## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|      Method | Skip | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | 1000 |   100 |    530.4 ns |  0.22 ns |  0.19 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 |  5,808.1 ns |  9.36 ns |  8.29 ns | 10.95 |    0.02 | 0.0305 |     - |     - |      72 B |
|        Linq | 1000 |   100 |  1,698.3 ns |  3.09 ns |  2.89 ns |  3.20 |    0.01 | 0.1183 |     - |     - |     248 B |
|  LinqFaster | 1000 |   100 |  2,628.8 ns |  7.60 ns |  6.74 ns |  4.96 |    0.01 | 6.3171 |     - |     - |   13224 B |
|      LinqAF | 1000 |   100 | 10,284.2 ns | 13.12 ns | 12.27 ns | 19.39 |    0.02 |      - |     - |     - |         - |
|  StructLinq | 1000 |   100 |  1,700.2 ns |  5.70 ns |  5.05 ns |  3.21 |    0.01 | 0.0763 |     - |     - |     160 B |
|   Hyperlinq | 1000 |   100 |    806.3 ns |  0.35 ns |  0.27 ns |  1.52 |    0.00 |      - |     - |     - |         - |

## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|      Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|     ForLoop |          4 |   100 | 3.743 μs | 0.0115 μs | 0.0096 μs |  1.00 | 2.8687 |     - |     - |    6008 B |
| ForeachLoop |          4 |   100 | 3.692 μs | 0.0125 μs | 0.0117 μs |  0.99 | 2.8725 |     - |     - |    6008 B |
|        Linq |          4 |   100 | 7.703 μs | 0.0110 μs | 0.0098 μs |  2.06 | 2.0599 |     - |     - |    4312 B |
|      LinqAF |          4 |   100 | 9.841 μs | 0.0144 μs | 0.0113 μs |  2.63 | 5.9204 |     - |     - |   12400 B |
|  StructLinq |          4 |   100 | 6.172 μs | 0.0212 μs | 0.0198 μs |  1.65 |      - |     - |     - |         - |
|   Hyperlinq |          4 |   100 | 4.481 μs | 0.0049 μs | 0.0038 μs |  1.20 |      - |     - |     - |         - |

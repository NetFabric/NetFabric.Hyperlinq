## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|      Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |          4 |   100 | 3.717 μs | 0.0189 μs | 0.0177 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
| ForeachLoop |          4 |   100 | 3.693 μs | 0.0121 μs | 0.0107 μs |  0.99 |    0.01 | 2.8725 |     - |     - |    6008 B |
|        Linq |          4 |   100 | 7.679 μs | 0.0180 μs | 0.0150 μs |  2.06 |    0.01 | 2.0599 |     - |     - |    4312 B |
|      LinqAF |          4 |   100 | 9.645 μs | 0.0423 μs | 0.0395 μs |  2.59 |    0.02 | 5.9204 |     - |     - |   12400 B |
|  StructLinq |          4 |   100 | 5.816 μs | 0.0144 μs | 0.0135 μs |  1.56 |    0.01 |      - |     - |     - |         - |
|   Hyperlinq |          4 |   100 | 4.686 μs | 0.0089 μs | 0.0070 μs |  1.26 |    0.01 |      - |     - |     - |         - |

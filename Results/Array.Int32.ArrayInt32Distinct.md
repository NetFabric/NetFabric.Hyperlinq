## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|      Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |          4 |   100 | 3.824 μs | 0.0692 μs | 0.0647 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
| ForeachLoop |          4 |   100 | 3.786 μs | 0.0610 μs | 0.0541 μs |  0.99 |    0.02 | 2.8725 |     - |     - |    6008 B |
|        Linq |          4 |   100 | 7.780 μs | 0.0209 μs | 0.0185 μs |  2.03 |    0.03 | 2.0599 |     - |     - |    4312 B |
|      LinqAF |          4 |   100 | 9.993 μs | 0.0497 μs | 0.0441 μs |  2.61 |    0.04 | 5.9204 |     - |     - |   12400 B |
|  StructLinq |          4 |   100 | 6.205 μs | 0.0142 μs | 0.0126 μs |  1.62 |    0.03 |      - |     - |     - |         - |
|   Hyperlinq |          4 |   100 | 4.654 μs | 0.0189 μs | 0.0177 μs |  1.22 |    0.02 |      - |     - |     - |         - |

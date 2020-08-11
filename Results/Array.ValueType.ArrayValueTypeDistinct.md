## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|      Method | Duplicates | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----------- |------ |-----------:|--------:|--------:|------:|--------:|----------:|------:|------:|----------:|
|     ForLoop |          4 |   100 |   700.5 μs | 1.98 μs | 1.76 μs |  1.00 |    0.00 | 1095.7031 |     - |     - |   2.19 MB |
| ForeachLoop |          4 |   100 |   698.8 μs | 0.70 μs | 0.55 μs |  1.00 |    0.00 | 1095.7031 |     - |     - |   2.19 MB |
|        Linq |          4 |   100 |   775.1 μs | 1.60 μs | 1.33 μs |  1.11 |    0.00 | 1092.7734 |     - |     - |   2.18 MB |
|      LinqAF |          4 |   100 | 3,029.6 μs | 8.46 μs | 7.06 μs |  4.32 |    0.02 | 2187.5000 |     - |     - |   4.36 MB |
|  StructLinq |          4 |   100 |   810.5 μs | 0.99 μs | 0.77 μs |  1.16 |    0.00 | 1086.9141 |     - |     - |   2.17 MB |
|   Hyperlinq |          4 |   100 |   656.9 μs | 0.69 μs | 0.54 μs |  0.94 |    0.00 | 1045.8984 |     - |     - |   2.09 MB |

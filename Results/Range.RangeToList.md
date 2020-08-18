## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|      Method | Start | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 | 334.3 ns | 0.44 ns | 0.37 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
| ForeachLoop |     0 |   100 | 829.0 ns | 2.82 ns | 2.50 ns |  2.48 | 0.5922 |     - |     - |    1240 B |
|        Linq |     0 |   100 | 204.7 ns | 0.36 ns | 0.34 ns |  0.61 | 0.2370 |     - |     - |     496 B |
|  LinqFaster |     0 |   100 | 147.2 ns | 0.38 ns | 0.36 ns |  0.44 | 0.4208 |     - |     - |     880 B |
|      LinqAF |     0 |   100 | 363.6 ns | 1.45 ns | 1.36 ns |  1.09 | 0.2179 |     - |     - |     456 B |
|  StructLinq |     0 |   100 | 362.9 ns | 0.93 ns | 0.82 ns |  1.09 | 0.2294 |     - |     - |     480 B |
|   Hyperlinq |     0 |   100 | 146.6 ns | 0.38 ns | 0.34 ns |  0.44 | 0.2332 |     - |     - |     488 B |

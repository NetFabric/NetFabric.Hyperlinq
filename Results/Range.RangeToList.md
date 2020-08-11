## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|      Method | Start | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 | 332.1 ns | 0.97 ns | 0.91 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
| ForeachLoop |     0 |   100 | 854.1 ns | 3.17 ns | 2.96 ns |  2.57 | 0.5922 |     - |     - |    1240 B |
|        Linq |     0 |   100 | 204.8 ns | 0.37 ns | 0.29 ns |  0.62 | 0.2370 |     - |     - |     496 B |
|  LinqFaster |     0 |   100 | 159.5 ns | 0.98 ns | 0.77 ns |  0.48 | 0.4208 |     - |     - |     880 B |
|      LinqAF |     0 |   100 | 331.6 ns | 0.81 ns | 0.76 ns |  1.00 | 0.2179 |     - |     - |     456 B |
|  StructLinq |     0 |   100 | 364.3 ns | 0.79 ns | 0.70 ns |  1.10 | 0.2294 |     - |     - |     480 B |
|   Hyperlinq |     0 |   100 | 144.6 ns | 0.27 ns | 0.22 ns |  0.44 | 0.2332 |     - |     - |     488 B |

## EmptyBenchmarks

### Source
[EmptyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/EmptyBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                               Method |               Categories |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------- |------------------------- |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                   Linq_Empty_ForEach |                  Empty() |  6.413 ns | 0.0902 ns | 0.0844 ns |  1.00 |      - |     - |     - |         - |
|              Hyperlinq_Empty_ForEach |                  Empty() |  1.772 ns | 0.0264 ns | 0.0221 ns |  0.28 |      - |     - |     - |         - |
|                  Hyperlinq_Empty_For |                  Empty() |  3.475 ns | 0.0317 ns | 0.0296 ns |  0.54 |      - |     - |     - |         - |
|                                      |                          |           |           |           |       |        |       |       |           |
|                     Linq_Empty_Count |          Empty().Count() |  8.608 ns | 0.0612 ns | 0.0511 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_Empty_Count |          Empty().Count() |  1.626 ns | 0.0187 ns | 0.0175 ns |  0.19 |      - |     - |     - |         - |
|                                      |                          |           |           |           |       |        |       |       |           |
|            Linq_Empty_Select_ForEach |         Empty().Select() | 23.193 ns | 0.1113 ns | 0.0930 ns |  1.00 |      - |     - |     - |         - |
|       Hyperlinq_Empty_Select_ForEach |         Empty().Select() | 14.867 ns | 0.1480 ns | 0.1384 ns |  0.64 |      - |     - |     - |         - |
|           Hyperlinq_Empty_Select_For |         Empty().Select() | 14.080 ns | 0.0740 ns | 0.0618 ns |  0.61 |      - |     - |     - |         - |
|                                      |                          |           |           |           |       |        |       |       |           |
|             Linq_Empty_Where_ForEach |          Empty().Where() | 49.150 ns | 0.3618 ns | 0.3207 ns |  1.00 | 0.0268 |     - |     - |      56 B |
|        Hyperlinq_Empty_Where_ForEach |          Empty().Where() | 16.052 ns | 0.1882 ns | 0.1760 ns |  0.33 |      - |     - |     - |         - |
|                                      |                          |           |           |           |       |        |       |       |           |
|      Linq_Empty_Where_Select_ForEach | Empty().Where().Select() | 81.457 ns | 0.5106 ns | 0.4264 ns |  1.00 | 0.0573 |     - |     - |     120 B |
| Hyperlinq_Empty_Where_Select_ForEach | Empty().Where().Select() | 43.707 ns | 0.1672 ns | 0.1482 ns |  0.54 |      - |     - |     - |         - |

## EmptyBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|                               Method |               Categories |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------- |------------------------- |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                   Linq_Empty_ForEach |                  Empty() |  6.974 ns | 0.0261 ns | 0.0244 ns |  1.00 |      - |     - |     - |         - |
|              Hyperlinq_Empty_ForEach |                  Empty() |  1.067 ns | 0.0195 ns | 0.0173 ns |  0.15 |      - |     - |     - |         - |
|                  Hyperlinq_Empty_For |                  Empty() |  2.986 ns | 0.0163 ns | 0.0136 ns |  0.43 |      - |     - |     - |         - |
|                                      |                          |           |           |           |       |        |       |       |           |
|                     Linq_Empty_Count |          Empty().Count() |  8.448 ns | 0.0698 ns | 0.0653 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_Empty_Count |          Empty().Count() |  1.839 ns | 0.0229 ns | 0.0215 ns |  0.22 |      - |     - |     - |         - |
|                                      |                          |           |           |           |       |        |       |       |           |
|            Linq_Empty_Select_ForEach |         Empty().Select() | 22.319 ns | 0.0869 ns | 0.0770 ns |  1.00 |      - |     - |     - |         - |
|       Hyperlinq_Empty_Select_ForEach |         Empty().Select() | 14.958 ns | 0.0627 ns | 0.0524 ns |  0.67 |      - |     - |     - |         - |
|           Hyperlinq_Empty_Select_For |         Empty().Select() | 14.216 ns | 0.0572 ns | 0.0535 ns |  0.64 |      - |     - |     - |         - |
|                                      |                          |           |           |           |       |        |       |       |           |
|             Linq_Empty_Where_ForEach |          Empty().Where() | 45.956 ns | 0.3857 ns | 0.3608 ns |  1.00 | 0.0268 |     - |     - |      56 B |
|        Hyperlinq_Empty_Where_ForEach |          Empty().Where() | 16.156 ns | 0.1318 ns | 0.1168 ns |  0.35 |      - |     - |     - |         - |
|                                      |                          |           |           |           |       |        |       |       |           |
|      Linq_Empty_Where_Select_ForEach | Empty().Where().Select() | 78.052 ns | 0.6378 ns | 0.5654 ns |  1.00 | 0.0573 |     - |     - |     120 B |
| Hyperlinq_Empty_Where_Select_ForEach | Empty().Where().Select() | 43.140 ns | 0.2202 ns | 0.1838 ns |  0.55 |      - |     - |     - |         - |

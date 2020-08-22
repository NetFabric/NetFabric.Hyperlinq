## FirstBenchmarks

### Source
[FirstBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/FirstBenchmarks.cs)

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
|                         Method |                Categories | Count |       Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |-----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |  24.561 ns | 0.1178 ns | 0.1044 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                     Array |   100 |   3.987 ns | 0.0226 ns | 0.0201 ns |  0.16 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                     Array |   100 |   3.965 ns | 0.0331 ns | 0.0309 ns |  0.16 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |   5.592 ns | 0.0443 ns | 0.0370 ns |  0.23 |      - |     - |     - |         - |
|                                |                           |       |            |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |  26.017 ns | 0.1797 ns | 0.1593 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  11.015 ns | 0.0772 ns | 0.0684 ns |  0.42 |      - |     - |     - |         - |
|                                |                           |       |            |           |           |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |  26.438 ns | 0.2050 ns | 0.1817 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |  13.375 ns | 0.0334 ns | 0.0279 ns |  0.51 |      - |     - |     - |         - |
|                                |                           |       |            |           |           |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |  13.202 ns | 0.0985 ns | 0.0873 ns |  1.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |                List_Value |   100 |   7.537 ns | 0.0624 ns | 0.0583 ns |  0.57 |      - |     - |     - |         - |
|                                |                           |       |            |           |           |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 118.315 ns | 0.4366 ns | 0.3870 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                                |                           |       |            |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  20.769 ns | 0.1571 ns | 0.1392 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  16.134 ns | 0.1274 ns | 0.1191 ns |  0.78 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |            |           |           |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |  22.148 ns | 0.1680 ns | 0.1490 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  17.576 ns | 0.0634 ns | 0.0593 ns |  0.79 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |            |           |           |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |  13.257 ns | 0.1122 ns | 0.1050 ns |  1.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |            List_Reference |   100 |   7.672 ns | 0.0228 ns | 0.0202 ns |  0.58 |      - |     - |     - |         - |
|                                |                           |       |            |           |           |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 117.329 ns | 0.8493 ns | 0.7944 ns |  1.00 | 0.0191 |     - |     - |      40 B |

## ElementAtBenchmarks

### Source
[ElementAtBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ElementAtBenchmarks.cs)

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
|                         Method |                Categories | Count |         Mean |      Error |     StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |-------------:|-----------:|-----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |    20.563 ns |  0.1479 ns |  0.1311 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                     Array |   100 |     4.473 ns |  0.0294 ns |  0.0275 ns |  0.22 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                     Array |   100 |     4.226 ns |  0.0358 ns |  0.0334 ns |  0.21 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |     5.820 ns |  0.0258 ns |  0.0202 ns |  0.28 |      - |     - |     - |         - |
|                                |                           |       |              |            |            |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |   343.014 ns |  2.1772 ns |  2.0365 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   132.315 ns |  0.6109 ns |  0.5416 ns |  0.39 |      - |     - |     - |         - |
|                                |                           |       |              |            |            |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |   346.126 ns |  2.1100 ns |  1.8705 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |   138.483 ns |  0.8333 ns |  0.7387 ns |  0.40 |      - |     - |     - |         - |
|                                |                           |       |              |            |            |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |     9.652 ns |  0.0657 ns |  0.0582 ns |  1.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |                List_Value |   100 |     6.556 ns |  0.0498 ns |  0.0441 ns |  0.68 |      - |     - |     - |         - |
|                                |                           |       |              |            |            |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,130.236 ns |  6.6844 ns |  5.9256 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                                |                           |       |              |            |            |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   237.121 ns |  1.7595 ns |  1.5598 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   233.889 ns |  1.0268 ns |  0.9102 ns |  0.99 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |              |            |            |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |   238.227 ns |  2.6173 ns |  2.3202 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   252.386 ns |  1.6660 ns |  1.4769 ns |  1.06 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |              |            |            |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |     9.647 ns |  0.0600 ns |  0.0532 ns |  1.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |            List_Reference |   100 |     6.640 ns |  0.0413 ns |  0.0366 ns |  0.69 |      - |     - |     - |         - |
|                                |                           |       |              |            |            |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,030.669 ns | 15.5202 ns | 14.5176 ns |  1.00 | 0.0191 |     - |     - |      40 B |

## SkipTakeBenchmarks

### Source
[SkipTakeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SkipTakeBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Skip | Count |         Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |----- |------ |-------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |  100 |   100 |    862.62 ns |  4.183 ns |  3.493 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                    StructLinq_Array |                     Array |  100 |   100 |    112.97 ns |  0.562 ns |  0.526 ns |  0.13 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |  100 |   100 |    145.98 ns |  0.665 ns |  0.555 ns |  0.17 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |  100 |   100 |    182.07 ns |  0.492 ns |  0.460 ns |  0.21 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |  100 |   100 |     79.91 ns |  0.230 ns |  0.204 ns |  0.09 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |  100 |   100 |    173.52 ns |  0.500 ns |  0.443 ns |  0.20 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |  100 |   100 |    228.05 ns |  0.684 ns |  0.606 ns |  0.26 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |  100 |   100 |    177.33 ns |  0.429 ns |  0.401 ns |  0.21 |      - |     - |     - |         - |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |  100 |   100 |  1,528.93 ns |  4.887 ns |  4.333 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |  1,008.50 ns |  3.941 ns |  3.291 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |  1,113.97 ns |  6.061 ns |  5.373 ns |  0.73 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |  100 |   100 |  1,511.14 ns |  7.204 ns |  6.386 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Collection_Value |          Collection_Value |  100 |   100 |  1,011.69 ns |  9.560 ns |  7.983 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |  100 |   100 |  1,237.85 ns |  6.506 ns |  5.767 ns |  0.82 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |  100 |   100 |    806.60 ns |  5.569 ns |  4.937 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               StructLinq_List_Value |                List_Value |  100 |   100 |    253.71 ns |  1.685 ns |  1.494 ns |  0.31 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |  100 |   100 |    249.77 ns |  1.241 ns |  1.161 ns |  0.31 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |  100 |   100 |    221.45 ns |  1.170 ns |  0.977 ns |  0.27 |      - |     - |     - |         - |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 |  9,856.75 ns | 38.609 ns | 32.240 ns |  1.00 | 0.0763 |     - |     - |     184 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 |  6,404.32 ns | 19.548 ns | 18.285 ns |  0.65 | 0.0153 |     - |     - |      40 B |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |  1,229.53 ns | 11.593 ns |  9.681 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |    695.52 ns |  3.885 ns |  3.244 ns |  0.57 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |    846.99 ns |  3.299 ns |  3.086 ns |  0.69 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |  100 |   100 |  1,223.58 ns |  3.206 ns |  2.503 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Collection_Reference |      Collection_Reference |  100 |   100 |    695.10 ns |  3.130 ns |  2.613 ns |  0.57 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |  100 |   100 |    925.49 ns |  4.522 ns |  4.009 ns |  0.76 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |  100 |   100 |    804.14 ns |  4.282 ns |  3.795 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|           StructLinq_List_Reference |            List_Reference |  100 |   100 |    695.04 ns |  2.704 ns |  2.397 ns |  0.86 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |  100 |   100 |    250.59 ns |  0.998 ns |  0.885 ns |  0.31 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |  100 |   100 |    222.41 ns |  1.462 ns |  1.221 ns |  0.28 |      - |     - |     - |         - |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 10,018.84 ns | 31.595 ns | 28.008 ns |  1.00 | 0.0763 |     - |     - |     184 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 |  6,246.27 ns | 17.310 ns | 16.192 ns |  0.62 | 0.0153 |     - |     - |      40 B |

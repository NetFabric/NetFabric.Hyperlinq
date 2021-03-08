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
|                          Linq_Array |                     Array |  100 |   100 |    894.93 ns |  3.364 ns |  2.809 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                    StructLinq_Array |                     Array |  100 |   100 |    116.28 ns |  0.257 ns |  0.228 ns |  0.13 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |  100 |   100 |    150.77 ns |  0.654 ns |  0.612 ns |  0.17 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |  100 |   100 |    187.25 ns |  0.321 ns |  0.268 ns |  0.21 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |  100 |   100 |     82.51 ns |  0.216 ns |  0.180 ns |  0.09 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |  100 |   100 |    179.61 ns |  0.625 ns |  0.585 ns |  0.20 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |  100 |   100 |    238.35 ns |  1.381 ns |  1.224 ns |  0.27 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |  100 |   100 |    184.81 ns |  0.760 ns |  0.711 ns |  0.21 |      - |     - |     - |         - |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |  100 |   100 |  1,581.52 ns |  8.840 ns |  8.269 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |  1,055.77 ns |  5.307 ns |  4.964 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |    465.80 ns |  1.631 ns |  1.446 ns |  0.29 |      - |     - |     - |         - |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |  100 |   100 |  1,570.79 ns | 20.427 ns | 18.108 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Collection_Value |          Collection_Value |  100 |   100 |  1,046.59 ns |  4.388 ns |  3.889 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |  100 |   100 |    573.57 ns |  3.364 ns |  2.983 ns |  0.37 |      - |     - |     - |         - |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |  100 |   100 |    834.99 ns |  5.086 ns |  4.509 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               StructLinq_List_Value |                List_Value |  100 |   100 |    236.61 ns |  0.908 ns |  0.805 ns |  0.28 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |  100 |   100 |    258.81 ns |  1.418 ns |  1.257 ns |  0.31 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |  100 |   100 |    231.08 ns |  0.609 ns |  0.475 ns |  0.28 |      - |     - |     - |         - |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 10,221.95 ns | 37.693 ns | 29.428 ns |  1.00 | 0.0763 |     - |     - |     184 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 |  5,587.09 ns | 12.907 ns | 12.073 ns |  0.55 |      - |     - |     - |         - |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |  1,249.27 ns |  8.722 ns |  7.283 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |    751.98 ns |  7.166 ns |  5.984 ns |  0.60 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |    878.36 ns |  3.940 ns |  3.493 ns |  0.70 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |  100 |   100 |  1,279.37 ns |  5.198 ns |  4.862 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Collection_Reference |      Collection_Reference |  100 |   100 |    724.97 ns |  4.017 ns |  3.561 ns |  0.57 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |  100 |   100 |    925.08 ns |  3.833 ns |  3.201 ns |  0.72 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |  100 |   100 |    840.68 ns |  3.652 ns |  5.577 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|           StructLinq_List_Reference |            List_Reference |  100 |   100 |    749.35 ns |  2.721 ns |  2.545 ns |  0.89 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |  100 |   100 |    280.71 ns |  1.711 ns |  1.336 ns |  0.33 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |  100 |   100 |    230.09 ns |  0.590 ns |  0.523 ns |  0.27 |      - |     - |     - |         - |
|                                     |                           |      |       |              |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 |  9,983.10 ns | 36.251 ns | 32.136 ns |  1.00 | 0.0763 |     - |     - |     184 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 |  7,394.23 ns | 25.433 ns | 23.790 ns |  0.74 | 0.0153 |     - |     - |      40 B |

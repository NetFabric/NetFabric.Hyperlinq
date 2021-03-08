## SumBenchmarks

### Source
[SumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SumBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   416.78 ns |  1.530 ns |  1.356 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                    StructLinq_Array |                     Array |   100 |    61.90 ns |  0.240 ns |  0.201 ns |  0.15 |      - |     - |     - |         - |
|                LinqFasterSIMD_Array |                     Array |   100 |    11.42 ns |  0.069 ns |  0.065 ns |  0.03 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    23.41 ns |  0.067 ns |  0.059 ns |  0.06 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |    23.00 ns |  0.057 ns |  0.051 ns |  0.06 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    24.06 ns |  0.099 ns |  0.092 ns |  0.06 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   637.26 ns |  4.688 ns |  4.386 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   637.41 ns |  4.893 ns |  4.577 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   627.98 ns |  3.576 ns |  2.986 ns |  0.98 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   635.62 ns |  2.993 ns |  2.653 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   631.42 ns |  2.664 ns |  2.492 ns |  0.99 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   633.09 ns |  2.768 ns |  2.454 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   632.75 ns |  2.688 ns |  2.514 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|               StructLinq_List_Value |                List_Value |   100 |   223.37 ns |  0.798 ns |  0.667 ns |  0.35 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   221.36 ns |  1.066 ns |  0.945 ns |  0.35 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,083.59 ns |  7.037 ns |  6.582 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,076.52 ns |  6.203 ns |  5.499 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   415.01 ns |  1.190 ns |  0.929 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   416.91 ns |  2.587 ns |  2.161 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   442.20 ns |  1.988 ns |  1.762 ns |  1.07 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   417.05 ns |  1.782 ns |  1.580 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   415.66 ns |  2.014 ns |  1.785 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   418.07 ns |  1.576 ns |  1.397 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   415.76 ns |  2.019 ns |  1.888 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   415.10 ns |  1.925 ns |  1.801 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   219.73 ns |  0.709 ns |  0.592 ns |  0.53 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,944.05 ns |  5.323 ns |  4.719 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,946.32 ns | 15.754 ns | 13.966 ns |  1.00 | 0.0191 |     - |     - |      40 B |

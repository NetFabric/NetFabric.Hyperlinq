## SkipTakeBenchmarks

### Source
[SkipTakeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SkipTakeBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Skip | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |----- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |  100 |   100 |   917.40 ns |  6.022 ns |  5.029 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                    StructLinq_Array |                     Array |  100 |   100 |    50.18 ns |  0.154 ns |  0.136 ns |  0.05 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |  100 |   100 |   203.23 ns |  0.551 ns |  0.515 ns |  0.22 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |  100 |   100 |   179.89 ns |  0.532 ns |  0.444 ns |  0.20 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |  100 |   100 |    79.62 ns |  0.389 ns |  0.344 ns |  0.09 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |  100 |   100 |   169.75 ns |  0.372 ns |  0.330 ns |  0.19 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |  100 |   100 |   226.10 ns |  0.736 ns |  0.575 ns |  0.25 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |  100 |   100 |   179.65 ns |  1.394 ns |  1.304 ns |  0.20 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |  100 |   100 | 1,460.61 ns |  6.434 ns |  5.024 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   984.29 ns |  4.626 ns |  4.101 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   444.17 ns |  1.463 ns |  1.297 ns |  0.30 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |  100 |   100 | 1,458.69 ns |  5.730 ns |  5.079 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Collection_Value |          Collection_Value |  100 |   100 |   977.11 ns |  5.175 ns |  4.321 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |  100 |   100 |   582.24 ns |  1.985 ns |  1.857 ns |  0.40 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |  100 |   100 |   804.69 ns |  3.999 ns |  3.741 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               StructLinq_List_Value |                List_Value |  100 |   100 |   224.84 ns |  0.738 ns |  0.616 ns |  0.28 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |  100 |   100 |   657.43 ns |  4.149 ns |  3.678 ns |  0.82 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |  100 |   100 |   219.18 ns |  1.247 ns |  1.105 ns |  0.27 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 8,311.02 ns | 26.143 ns | 21.831 ns |  1.00 | 0.0763 |     - |     - |     176 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 4,337.00 ns | 15.564 ns | 13.797 ns |  0.52 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,459.67 ns |  3.143 ns |  2.454 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |   954.07 ns |  6.370 ns |  5.959 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,063.69 ns |  6.712 ns |  5.605 ns |  0.73 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,482.71 ns |  5.643 ns |  5.003 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Collection_Reference |      Collection_Reference |  100 |   100 |   978.50 ns |  9.557 ns |  8.472 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,311.83 ns |  5.852 ns |  4.886 ns |  0.88 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |  100 |   100 |   803.87 ns |  4.946 ns |  4.385 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|           StructLinq_List_Reference |            List_Reference |  100 |   100 |   977.06 ns |  5.623 ns |  4.984 ns |  1.22 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |  100 |   100 |   625.59 ns |  2.119 ns |  1.769 ns |  0.78 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |  100 |   100 |   244.13 ns |  2.158 ns |  1.913 ns |  0.30 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 8,244.44 ns | 37.434 ns | 35.016 ns |  1.00 | 0.0763 |     - |     - |     176 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 5,434.69 ns | 20.316 ns | 18.009 ns |  0.66 | 0.0153 |     - |     - |      32 B |

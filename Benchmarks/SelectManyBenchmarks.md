﻿## SelectManyBenchmarks

### Source
[SelectManyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectManyBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|                         Method |                Categories | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |  2.756 μs | 0.0184 μs | 0.0163 μs |  2.753 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq_Array |                     Array |   100 |  1.225 μs | 0.0035 μs | 0.0033 μs |  1.224 μs |  0.44 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |  1.381 μs | 0.0050 μs | 0.0042 μs |  1.380 μs |  0.50 |    0.00 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |  2.968 μs | 0.0281 μs | 0.0262 μs |  2.964 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  3.670 μs | 0.0176 μs | 0.0147 μs |  3.668 μs |  1.24 |    0.01 | 2.3575 |     - |     - |   4,936 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |  3.216 μs | 0.0163 μs | 0.0144 μs |  3.217 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |  3.312 μs | 0.0209 μs | 0.0185 μs |  3.308 μs |  1.03 |    0.01 | 2.3575 |     - |     - |   4,936 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |  2.993 μs | 0.0211 μs | 0.0187 μs |  2.989 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|           Hyperlinq_List_Value |                List_Value |   100 |  3.341 μs | 0.0109 μs | 0.0091 μs |  3.343 μs |  1.12 |    0.01 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 11.621 μs | 0.0627 μs | 0.0587 μs | 11.609 μs |  1.00 |    0.00 | 2.3346 |     - |     - |   4,904 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.008 μs | 0.0336 μs | 0.0298 μs |  2.996 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.409 μs | 0.0669 μs | 0.1322 μs |  3.331 μs |  1.19 |    0.04 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |  3.076 μs | 0.0604 μs | 0.1120 μs |  3.004 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  3.482 μs | 0.0154 μs | 0.0206 μs |  3.476 μs |  1.11 |    0.04 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |  3.222 μs | 0.0175 μs | 0.0163 μs |  3.216 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |  3.599 μs | 0.0149 μs | 0.0140 μs |  3.599 μs |  1.12 |    0.01 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 11.918 μs | 0.0477 μs | 0.0423 μs | 11.915 μs |  1.00 |    0.00 | 2.3346 |     - |     - |   4,904 B |

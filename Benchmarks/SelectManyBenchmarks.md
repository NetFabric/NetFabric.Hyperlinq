## SelectManyBenchmarks

### Source
[SelectManyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectManyBenchmarks.cs)

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
|                         Method |                Categories | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |  2.830 μs | 0.0174 μs | 0.0155 μs |  2.829 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq_Array |                     Array |   100 |  1.226 μs | 0.0027 μs | 0.0024 μs |  1.225 μs |  0.43 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |  1.377 μs | 0.0030 μs | 0.0028 μs |  1.377 μs |  0.49 |    0.00 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |  3.236 μs | 0.0128 μs | 0.0120 μs |  3.236 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  3.398 μs | 0.0678 μs | 0.1416 μs |  3.308 μs |  1.06 |    0.04 | 2.3575 |     - |     - |   4,936 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |  3.003 μs | 0.0124 μs | 0.0110 μs |  3.000 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |  3.304 μs | 0.0110 μs | 0.0103 μs |  3.305 μs |  1.10 |    0.01 | 2.3575 |     - |     - |   4,936 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |  3.117 μs | 0.0619 μs | 0.1292 μs |  3.049 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|           Hyperlinq_List_Value |                List_Value |   100 |  3.453 μs | 0.0682 μs | 0.1409 μs |  3.353 μs |  1.11 |    0.03 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 11.580 μs | 0.0486 μs | 0.0431 μs | 11.586 μs |  1.00 |    0.00 | 2.3346 |     - |     - |   4,904 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  2.973 μs | 0.0111 μs | 0.0098 μs |  2.973 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.334 μs | 0.0154 μs | 0.0129 μs |  3.332 μs |  1.12 |    0.00 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |  3.263 μs | 0.0191 μs | 0.0159 μs |  3.266 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  3.481 μs | 0.0174 μs | 0.0163 μs |  3.484 μs |  1.07 |    0.01 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |  3.024 μs | 0.0145 μs | 0.0128 μs |  3.026 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |  3.416 μs | 0.0151 μs | 0.0134 μs |  3.415 μs |  1.13 |    0.01 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 11.583 μs | 0.0268 μs | 0.0224 μs | 11.582 μs |  1.00 |    0.00 | 2.3346 |     - |     - |   4,904 B |

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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                         Method |                Categories | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |  2.815 μs | 0.0153 μs | 0.0128 μs |  2.812 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq_Array |                     Array |   100 |  1.221 μs | 0.0032 μs | 0.0028 μs |  1.221 μs |  0.43 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |  1.382 μs | 0.0040 μs | 0.0037 μs |  1.382 μs |  0.49 |    0.00 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |  2.976 μs | 0.0218 μs | 0.0182 μs |  2.970 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  3.251 μs | 0.0315 μs | 0.0263 μs |  3.239 μs |  1.09 |    0.01 | 2.3575 |     - |     - |   4,936 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |  3.073 μs | 0.0543 μs | 0.0965 μs |  3.030 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |  3.328 μs | 0.0194 μs | 0.0182 μs |  3.324 μs |  1.06 |    0.04 | 2.3575 |     - |     - |   4,936 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |  3.178 μs | 0.0422 μs | 0.0374 μs |  3.186 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|           Hyperlinq_List_Value |                List_Value |   100 |  3.391 μs | 0.0676 μs | 0.1318 μs |  3.306 μs |  1.13 |    0.01 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 11.623 μs | 0.0643 μs | 0.0601 μs | 11.616 μs |  1.00 |    0.00 | 2.3346 |     - |     - |   4,904 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  2.999 μs | 0.0136 μs | 0.0128 μs |  3.001 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.308 μs | 0.0185 μs | 0.0164 μs |  3.308 μs |  1.10 |    0.01 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |  3.249 μs | 0.0358 μs | 0.0317 μs |  3.249 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  3.677 μs | 0.0255 μs | 0.0238 μs |  3.670 μs |  1.13 |    0.01 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |  2.939 μs | 0.0252 μs | 0.0224 μs |  2.930 μs |  1.00 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |  3.302 μs | 0.0110 μs | 0.0092 μs |  3.301 μs |  1.12 |    0.01 | 2.3499 |     - |     - |   4,920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 11.592 μs | 0.0238 μs | 0.0199 μs | 11.595 μs |  1.00 |    0.00 | 2.3346 |     - |     - |   4,904 B |

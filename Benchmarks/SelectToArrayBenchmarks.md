## SelectToArrayBenchmarks

### Source
[SelectToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToArrayBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   240.54 ns |  1.365 ns |  1.210 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
|                    StructLinq_Array |                     Array |   100 |   273.57 ns |  1.555 ns |  1.454 ns |  1.14 |    0.01 | 0.2027 |     - |     - |     424 B |
|                LinqFasterSIMD_Array |                     Array |   100 |    64.64 ns |  1.071 ns |  1.002 ns |  0.27 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   251.62 ns |  0.888 ns |  0.831 ns |  1.05 |    0.01 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    85.58 ns |  1.113 ns |  1.041 ns |  0.36 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,071.24 ns |  5.051 ns |  4.725 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,052.71 ns |  5.609 ns |  4.972 ns |  0.98 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   610.37 ns |  7.465 ns |  6.233 ns |  0.57 |    0.01 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,152.86 ns |  6.149 ns |  5.752 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,057.94 ns |  3.803 ns |  3.175 ns |  0.92 |    0.00 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   366.46 ns |  2.656 ns |  2.355 ns |  0.32 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   481.36 ns |  2.718 ns |  2.270 ns |  1.00 |    0.00 | 0.2289 |     - |     - |     480 B |
|               StructLinq_List_Value |                List_Value |   100 |   420.23 ns |  8.393 ns | 12.037 ns |  0.86 |    0.03 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   860.09 ns |  3.344 ns |  2.792 ns |  1.79 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,727.46 ns | 38.027 ns | 31.754 ns |  1.00 |    0.00 | 0.7935 |     - |     - |   1,672 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,347.46 ns |  8.091 ns |  7.568 ns |  0.30 |    0.00 | 0.5646 |     - |     - |   1,184 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,181.79 ns |  7.270 ns |  6.801 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,059.90 ns |  3.879 ns |  3.439 ns |  0.90 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,137.82 ns |  7.782 ns |  6.898 ns |  0.96 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,091.31 ns |  6.064 ns |  5.375 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,064.82 ns |  5.197 ns |  4.607 ns |  0.98 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   778.34 ns |  3.808 ns |  3.376 ns |  0.71 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   446.99 ns |  1.802 ns |  1.407 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,092.56 ns |  6.810 ns |  6.037 ns |  2.44 |    0.02 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   841.76 ns |  3.431 ns |  3.042 ns |  1.88 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,716.34 ns | 35.734 ns | 29.840 ns |  1.00 |    0.00 | 0.7935 |     - |     - |   1,672 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,145.91 ns |  8.983 ns |  8.403 ns |  0.41 |    0.00 | 0.5798 |     - |     - |   1,216 B |

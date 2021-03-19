## ToArrayBenchmarks

### Source
[ToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    50.97 ns |  0.450 ns |  0.399 ns |    50.91 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    StructLinq_Array |                     Array |   100 |    82.41 ns |  0.398 ns |  0.372 ns |    82.48 ns |  1.62 |    0.01 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    38.24 ns |  0.447 ns |  0.396 ns |    38.21 ns |  0.75 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   924.44 ns | 16.211 ns | 26.178 ns |   911.77 ns |  1.00 |    0.00 | 0.5655 |     - |     - |   1,184 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   855.97 ns |  4.395 ns |  3.896 ns |   855.47 ns |  0.91 |    0.03 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   535.49 ns |  2.560 ns |  2.137 ns |   535.19 ns |  0.57 |    0.02 | 0.2213 |     - |     - |     464 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    45.29 ns |  0.259 ns |  0.230 ns |    45.28 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   880.78 ns |  3.505 ns |  2.926 ns |   880.52 ns | 19.45 |    0.09 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   137.30 ns |  0.759 ns |  0.673 ns |   137.27 ns |  3.03 |    0.02 | 0.2217 |     - |     - |     464 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    48.02 ns |  0.598 ns |  0.530 ns |    48.10 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|               StructLinq_List_Value |                List_Value |   100 |   275.88 ns |  1.662 ns |  1.555 ns |   275.99 ns |  5.75 |    0.08 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   552.05 ns |  3.294 ns |  2.920 ns |   551.52 ns | 11.50 |    0.17 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   913.85 ns |  7.358 ns |  6.144 ns |   911.78 ns |  1.00 |    0.00 | 0.5655 |     - |     - |   1,184 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   880.11 ns |  4.908 ns |  4.351 ns |   879.76 ns |  0.96 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,012.75 ns |  3.967 ns |  3.517 ns | 1,011.31 ns |  1.11 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    48.19 ns |  1.145 ns |  3.172 ns |    46.69 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   930.43 ns |  6.676 ns |  6.245 ns |   928.30 ns | 19.60 |    1.21 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   718.27 ns |  6.036 ns |  5.646 ns |   717.41 ns | 15.13 |    0.90 | 0.2289 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    49.20 ns |  1.051 ns |  2.330 ns |    48.29 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   882.71 ns |  6.091 ns |  5.399 ns |   880.09 ns | 17.43 |    1.03 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   549.66 ns |  2.190 ns |  1.829 ns |   549.87 ns | 10.82 |    0.64 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,335.34 ns |  3.342 ns |  2.791 ns | 1,335.74 ns |     ? |       ? | 0.5646 |     - |     - |   1,184 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,126.59 ns |  5.203 ns |  4.062 ns | 2,126.87 ns |     ? |       ? | 0.5798 |     - |     - |   1,216 B |

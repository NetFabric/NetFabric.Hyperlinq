## ToArrayBenchmarks

### Source
[ToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    55.19 ns |  0.358 ns |  0.334 ns |    55.11 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    StructLinq_Array |                     Array |   100 |    86.46 ns |  1.273 ns |  1.191 ns |    86.72 ns |  1.57 |    0.02 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    39.77 ns |  0.860 ns |  2.384 ns |    38.63 ns |  0.73 |    0.04 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   912.67 ns |  6.263 ns |  5.858 ns |   910.52 ns |  1.00 |    0.00 | 0.5655 |     - |     - |   1,184 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   914.68 ns | 17.210 ns | 17.673 ns |   922.76 ns |  1.00 |    0.02 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   533.93 ns |  3.817 ns |  3.187 ns |   533.41 ns |  0.58 |    0.01 | 0.2213 |     - |     - |     464 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    53.90 ns |  0.362 ns |  0.339 ns |    53.84 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   912.65 ns |  6.331 ns |  4.943 ns |   912.21 ns | 16.94 |    0.13 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   123.65 ns |  2.089 ns |  1.954 ns |   123.08 ns |  2.29 |    0.04 | 0.2217 |     - |     - |     464 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    51.02 ns |  0.731 ns |  0.683 ns |    51.12 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|               StructLinq_List_Value |                List_Value |   100 |   249.29 ns |  1.904 ns |  1.688 ns |   248.64 ns |  4.89 |    0.08 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    60.35 ns |  1.193 ns |  1.057 ns |    60.58 ns |  1.18 |    0.03 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,909.56 ns |  8.408 ns |  7.865 ns | 1,907.95 ns |  1.00 |    0.00 | 0.7668 |     - |     - |   1,608 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,230.32 ns | 24.459 ns | 27.186 ns | 1,239.69 ns |  0.64 |    0.02 | 0.5646 |     - |     - |   1,184 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   913.09 ns |  8.407 ns |  7.452 ns |   909.57 ns |  1.00 |    0.00 | 0.5655 |     - |     - |   1,184 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   926.00 ns | 18.334 ns | 21.825 ns |   917.15 ns |  1.00 |    0.02 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,003.28 ns | 19.344 ns | 18.999 ns |   994.88 ns |  1.10 |    0.03 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    50.36 ns |  0.737 ns |  0.959 ns |    50.52 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   877.92 ns |  4.470 ns |  3.962 ns |   877.55 ns | 17.38 |    0.31 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    57.69 ns |  0.846 ns |  0.750 ns |    57.82 ns |  1.14 |    0.03 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    55.39 ns |  0.772 ns |  0.684 ns |    55.34 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   917.81 ns |  2.756 ns |  2.152 ns |   918.00 ns | 16.58 |    0.22 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    61.65 ns |  1.291 ns |  1.326 ns |    62.07 ns |  1.11 |    0.02 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,915.98 ns |  5.794 ns |  5.420 ns | 1,913.48 ns |  1.00 |    0.00 | 0.7668 |     - |     - |   1,608 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,069.53 ns | 40.202 ns | 39.484 ns | 2,085.08 ns |  1.08 |    0.02 | 0.5798 |     - |     - |   1,216 B |

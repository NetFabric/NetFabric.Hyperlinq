## SelectToListBenchmarks

### Source
[SelectToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToListBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   253.61 ns |  1.216 ns |   1.078 ns |   253.58 ns |  1.00 |    0.00 | 0.2408 |     - |     - |     504 B |
|                    StructLinq_Array |                     Array |   100 |   240.35 ns |  0.978 ns |   0.867 ns |   240.29 ns |  0.95 |    0.00 | 0.2179 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |   233.42 ns |  0.858 ns |   0.803 ns |   233.15 ns |  0.92 |    0.00 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    92.40 ns |  0.458 ns |   0.406 ns |    92.34 ns |  0.36 |    0.00 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |            |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,041.43 ns |  3.515 ns |   3.116 ns | 1,040.74 ns |  1.00 |    0.00 | 0.6065 |     - |     - |    1272 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,063.21 ns |  4.399 ns |   3.899 ns | 1,063.23 ns |  1.02 |    0.00 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   608.65 ns |  5.087 ns |   4.248 ns |   608.84 ns |  0.58 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |            |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,080.18 ns |  5.664 ns |   5.021 ns | 1,079.65 ns |  1.00 |    0.00 | 0.6065 |     - |     - |    1272 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,014.86 ns |  3.208 ns |   2.679 ns | 1,015.04 ns |  0.94 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   254.47 ns |  0.771 ns |   0.684 ns |   254.55 ns |  0.24 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |             |           |            |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   476.58 ns |  8.462 ns |  12.403 ns |   471.41 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|               StructLinq_List_Value |                List_Value |   100 |   404.32 ns |  1.011 ns |   0.946 ns |   404.40 ns |  0.84 |    0.02 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   716.97 ns |  2.596 ns |   2.301 ns |   717.30 ns |  1.49 |    0.04 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |            |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   862.70 ns |  2.807 ns |   2.488 ns |   863.12 ns |  1.00 |    0.00 | 0.6075 |     - |     - |    1272 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   862.81 ns |  2.362 ns |   1.973 ns |   862.31 ns |  1.00 |    0.00 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   928.89 ns |  5.865 ns |   5.486 ns |   927.72 ns |  1.08 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |            |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   888.21 ns | 16.842 ns |  34.403 ns |   871.97 ns |  1.00 |    0.00 | 0.6075 |     - |     - |    1272 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   811.46 ns |  4.436 ns |   3.704 ns |   812.39 ns |  0.88 |    0.04 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   604.53 ns |  3.046 ns |   2.850 ns |   604.67 ns |  0.66 |    0.03 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |            |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   488.13 ns |  1.409 ns |   1.318 ns |   487.52 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   809.28 ns |  2.379 ns |   2.226 ns |   809.99 ns |  1.66 |    0.01 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   736.16 ns | 14.615 ns |  20.961 ns |   726.79 ns |  1.52 |    0.05 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |            |             |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 3,239.23 ns |  5.002 ns |   4.177 ns | 3,239.25 ns |     ? |       ? | 0.5798 |     - |     - |    1216 B |
|                                     |                           |       |             |           |            |             |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,100.41 ns | 80.671 ns | 104.895 ns | 4,072.31 ns |     ? |       ? | 0.5951 |     - |     - |    1256 B |

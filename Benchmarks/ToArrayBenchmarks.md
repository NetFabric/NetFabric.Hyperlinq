## ToArrayBenchmarks

### Source
[ToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    55.83 ns |  0.186 ns |  0.165 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    StructLinq_Array |                     Array |   100 |    83.72 ns |  0.691 ns |  0.647 ns |  1.50 |    0.01 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    39.88 ns |  0.243 ns |  0.216 ns |  0.71 |    0.00 | 0.2027 |     - |     - |     424 B |
|                      Hyperlinq_Span |                     Array |   100 |    36.23 ns |  0.451 ns |  0.400 ns |  0.65 |    0.01 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_Memory |                     Array |   100 |    40.80 ns |  0.556 ns |  0.520 ns |  0.73 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   999.51 ns |  5.466 ns |  4.846 ns |  1.00 |    0.00 | 0.5646 |     - |     - |    1184 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   995.73 ns |  4.381 ns |  3.884 ns |  1.00 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   538.26 ns |  2.597 ns |  2.302 ns |  0.54 |    0.00 | 0.2213 |     - |     - |     464 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    46.20 ns |  0.320 ns |  0.299 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   939.32 ns |  6.493 ns |  6.073 ns | 20.33 |    0.21 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   219.53 ns |  0.922 ns |  0.818 ns |  4.75 |    0.04 | 0.2217 |     - |     - |     464 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    48.23 ns |  0.321 ns |  0.284 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|               StructLinq_List_Value |                List_Value |   100 |   289.96 ns |  1.496 ns |  1.326 ns |  6.01 |    0.05 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   589.63 ns |  3.901 ns |  3.649 ns | 12.23 |    0.11 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   762.68 ns |  4.856 ns |  4.305 ns |  1.00 |    0.00 | 0.5655 |     - |     - |    1184 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   718.56 ns |  2.571 ns |  2.405 ns |  0.94 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   792.95 ns |  3.226 ns |  2.859 ns |  1.04 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    46.20 ns |  0.231 ns |  0.180 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   762.51 ns |  2.300 ns |  1.920 ns | 16.50 |    0.05 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   511.44 ns |  2.025 ns |  1.691 ns | 11.07 |    0.06 | 0.2289 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    48.24 ns |  0.183 ns |  0.153 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   726.04 ns |  6.340 ns |  5.621 ns | 15.05 |    0.11 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   582.49 ns |  3.625 ns |  3.027 ns | 12.07 |    0.06 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,723.87 ns |  3.110 ns |  2.909 ns |     ? |       ? | 0.5646 |     - |     - |    1184 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,424.35 ns | 15.406 ns | 13.657 ns |     ? |       ? | 0.5836 |     - |     - |    1224 B |

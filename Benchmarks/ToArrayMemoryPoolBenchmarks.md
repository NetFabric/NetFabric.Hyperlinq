## ToArrayMemoryPoolBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    51.92 ns |  0.418 ns |  0.391 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                         System_Span |                     Array |   100 |    29.33 ns |  0.421 ns |  0.394 ns |  0.56 |    0.01 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    62.02 ns |  0.327 ns |  0.306 ns |  1.19 |    0.01 | 0.0267 |     - |     - |      56 B |
|                    Hyperlinq_Memory |                     Array |   100 |    69.38 ns |  0.495 ns |  0.463 ns |  1.34 |    0.01 | 0.0267 |     - |     - |      56 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   909.90 ns |  6.226 ns |  5.823 ns |  1.00 |    0.00 | 0.5617 |     - |     - |    1176 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   503.64 ns |  3.444 ns |  3.221 ns |  0.55 |    0.00 | 0.0267 |     - |     - |      56 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    88.79 ns |  0.415 ns |  0.388 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   237.75 ns |  1.192 ns |  1.057 ns |  2.68 |    0.01 | 0.0267 |     - |     - |      56 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    92.82 ns |  0.486 ns |  0.455 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   280.16 ns |  1.988 ns |  1.860 ns |  3.02 |    0.02 | 0.0267 |     - |     - |      56 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,408.33 ns | 25.905 ns | 22.964 ns |  1.00 |    0.00 | 0.7668 |     - |     - |    1608 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,285.01 ns | 13.748 ns | 12.860 ns |  0.95 |    0.01 | 0.4044 |     - |     - |     848 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   797.17 ns |  3.314 ns |  3.100 ns |  1.00 |    0.00 | 0.5693 |     - |     - |    1192 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   868.41 ns |  6.983 ns |  6.191 ns |  1.09 |    0.01 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    89.07 ns |  0.550 ns |  0.488 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   459.30 ns |  2.038 ns |  1.807 ns |  5.16 |    0.04 | 0.0381 |     - |     - |      80 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    91.39 ns |  0.253 ns |  0.212 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   279.37 ns |  1.379 ns |  1.222 ns |  3.06 |    0.01 | 0.0267 |     - |     - |      56 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,540.57 ns | 24.887 ns | 22.062 ns |  1.00 |    0.00 | 0.7477 |     - |     - |    1576 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,651.47 ns | 37.877 ns | 35.430 ns |  1.03 |    0.01 | 0.3967 |     - |     - |     840 B |

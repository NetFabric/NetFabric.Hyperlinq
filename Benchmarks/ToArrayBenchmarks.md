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
|                              Method |                Categories | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    56.10 ns | 0.316 ns | 0.296 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    StructLinq_Array |                     Array |   100 |    79.76 ns | 1.069 ns | 1.000 ns |  1.42 |    0.02 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    37.06 ns | 0.660 ns | 0.585 ns |  0.66 |    0.01 | 0.2027 |     - |     - |     424 B |
|                      Hyperlinq_Span |                     Array |   100 |    35.63 ns | 0.469 ns | 0.438 ns |  0.64 |    0.01 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_Memory |                     Array |   100 |    39.60 ns | 0.331 ns | 0.293 ns |  0.71 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   954.93 ns | 5.152 ns | 4.819 ns |  1.00 |    0.00 | 0.5646 |     - |     - |    1184 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   951.33 ns | 7.532 ns | 7.046 ns |  1.00 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1,011.43 ns | 5.203 ns | 4.345 ns |  1.06 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    42.92 ns | 0.558 ns | 0.466 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   893.97 ns | 4.208 ns | 3.730 ns | 20.84 |    0.25 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   653.15 ns | 3.229 ns | 3.021 ns | 15.22 |    0.20 | 0.2289 |     - |     - |     480 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    45.88 ns | 0.829 ns | 0.775 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|               StructLinq_List_Value |                List_Value |   100 |   250.63 ns | 1.584 ns | 1.405 ns |  5.46 |    0.07 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   561.00 ns | 3.094 ns | 2.742 ns | 12.21 |    0.20 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   708.70 ns | 3.785 ns | 3.355 ns |  1.00 |    0.00 | 0.5655 |     - |     - |    1184 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   692.48 ns | 3.789 ns | 3.544 ns |  0.98 |    0.00 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   811.31 ns | 2.995 ns | 2.338 ns |  1.14 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    43.75 ns | 0.323 ns | 0.302 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   732.75 ns | 2.144 ns | 1.790 ns | 16.75 |    0.15 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   490.16 ns | 2.903 ns | 2.424 ns | 11.21 |    0.10 | 0.2289 |     - |     - |     480 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    44.85 ns | 0.460 ns | 0.408 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   692.55 ns | 2.714 ns | 2.406 ns | 15.44 |    0.13 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   563.61 ns | 2.557 ns | 2.266 ns | 12.57 |    0.13 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,475.13 ns | 7.507 ns | 6.654 ns |     ? |       ? | 0.5836 |     - |     - |    1224 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,336.66 ns | 6.610 ns | 5.860 ns |     ? |       ? | 0.5836 |     - |     - |    1224 B |

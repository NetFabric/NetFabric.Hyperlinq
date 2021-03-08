## SkipTakeBenchmarks

### Source
[SkipTakeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SkipTakeBenchmarks.cs)

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
|                              Method |                Categories | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |  100 |   100 |   849.41 ns |  3.438 ns |  2.870 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                    StructLinq_Array |                     Array |  100 |   100 |   116.34 ns |  2.178 ns |  3.927 ns |  0.14 |    0.01 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |  100 |   100 |   144.20 ns |  0.462 ns |  0.386 ns |  0.17 |    0.00 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |  100 |   100 |   179.67 ns |  0.847 ns |  0.708 ns |  0.21 |    0.00 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |  100 |   100 |    80.75 ns |  0.520 ns |  0.461 ns |  0.10 |    0.00 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |  100 |   100 |   172.12 ns |  0.463 ns |  0.361 ns |  0.20 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |  100 |   100 |   226.10 ns |  0.961 ns |  0.852 ns |  0.27 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |  100 |   100 |   176.70 ns |  0.371 ns |  0.329 ns |  0.21 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |  100 |   100 | 1,494.65 ns |  3.827 ns |  3.196 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |  100 |   100 | 1,022.35 ns | 20.233 ns | 33.244 ns |  0.70 |    0.03 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   447.26 ns |  1.050 ns |  0.931 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |  100 |   100 | 1,491.03 ns |  3.881 ns |  3.440 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Collection_Value |          Collection_Value |  100 |   100 |   997.75 ns |  3.011 ns |  2.350 ns |  0.67 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |  100 |   100 |   551.51 ns |  2.405 ns |  2.132 ns |  0.37 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |  100 |   100 |   795.02 ns |  5.166 ns |  4.314 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|               StructLinq_List_Value |                List_Value |  100 |   100 |   224.83 ns |  0.397 ns |  0.310 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |  100 |   100 |   245.96 ns |  0.985 ns |  0.921 ns |  0.31 |    0.00 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |  100 |   100 |   219.36 ns |  0.923 ns |  0.771 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 9,739.61 ns | 26.639 ns | 23.615 ns |  1.00 |    0.00 | 0.0763 |     - |     - |     184 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 5,344.59 ns | 13.071 ns | 11.587 ns |  0.55 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,180.94 ns |  5.532 ns |  4.619 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |   712.26 ns |  2.693 ns |  2.387 ns |  0.60 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |   835.20 ns |  2.755 ns |  2.442 ns |  0.71 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,179.76 ns |  4.184 ns |  3.709 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Collection_Reference |      Collection_Reference |  100 |   100 |   713.51 ns |  2.994 ns |  2.801 ns |  0.60 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |  100 |   100 |   889.84 ns |  5.805 ns |  5.146 ns |  0.75 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |  100 |   100 |   797.12 ns |  3.318 ns |  2.941 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|           StructLinq_List_Reference |            List_Reference |  100 |   100 |   710.34 ns |  2.152 ns |  1.908 ns |  0.89 |    0.00 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |  100 |   100 |   265.26 ns |  1.894 ns |  1.679 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |  100 |   100 |   220.22 ns |  1.062 ns |  0.887 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 9,553.58 ns | 31.181 ns | 27.641 ns |  1.00 |    0.00 | 0.0763 |     - |     - |     184 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 6,700.30 ns | 19.039 ns | 16.878 ns |  0.70 |    0.00 | 0.0153 |     - |     - |      40 B |

## SkipTakeBenchmarks

### Source
[SkipTakeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SkipTakeBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Skip | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |----- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |  100 |   100 |   828.46 ns |  1.483 ns |  1.238 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                    StructLinq_Array |                     Array |  100 |   100 |   110.94 ns |  0.191 ns |  0.160 ns |  0.13 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |  100 |   100 |    61.62 ns |  0.086 ns |  0.081 ns |  0.07 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |  100 |   100 |   297.77 ns |  0.490 ns |  0.458 ns |  0.36 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |  100 |   100 |    61.64 ns |  0.112 ns |  0.094 ns |  0.07 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |  100 |   100 |    49.31 ns |  0.293 ns |  0.259 ns |  0.06 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |  100 |   100 |    59.74 ns |  0.183 ns |  0.153 ns |  0.07 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |  100 |   100 |    60.51 ns |  0.166 ns |  0.156 ns |  0.07 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |  100 |   100 | 1,523.79 ns |  2.700 ns |  2.394 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   968.79 ns |  2.805 ns |  2.342 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   498.73 ns |  1.486 ns |  1.390 ns |  0.33 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |  100 |   100 | 1,532.42 ns |  5.043 ns |  4.717 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Collection_Value |          Collection_Value |  100 |   100 |   967.60 ns |  3.050 ns |  2.704 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |  100 |   100 |   610.03 ns |  2.245 ns |  1.990 ns |  0.40 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |  100 |   100 |   834.17 ns |  2.057 ns |  1.924 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               StructLinq_List_Value |                List_Value |  100 |   100 |   222.05 ns |  0.326 ns |  0.272 ns |  0.27 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |  100 |   100 |   401.71 ns |  0.787 ns |  0.697 ns |  0.48 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |  100 |   100 |   248.95 ns |  1.327 ns |  1.176 ns |  0.30 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 9,571.18 ns | 42.371 ns | 37.561 ns |  1.00 | 0.1221 |     - |     - |     256 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 5,312.43 ns | 16.175 ns | 14.338 ns |  0.56 | 0.0305 |     - |     - |      72 B |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,172.66 ns |  4.419 ns |  3.917 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |   706.05 ns |  1.648 ns |  1.542 ns |  0.60 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |   826.26 ns |  3.009 ns |  2.349 ns |  0.70 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,148.65 ns |  3.342 ns |  2.963 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Collection_Reference |      Collection_Reference |  100 |   100 |   677.29 ns |  1.542 ns |  1.367 ns |  0.59 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |  100 |   100 |   931.79 ns |  2.819 ns |  2.499 ns |  0.81 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |  100 |   100 |   835.78 ns |  2.241 ns |  1.986 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|           StructLinq_List_Reference |            List_Reference |  100 |   100 |   704.07 ns |  1.353 ns |  1.130 ns |  0.84 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |  100 |   100 |   377.01 ns |  0.775 ns |  0.687 ns |  0.45 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |  100 |   100 |   222.71 ns |  0.466 ns |  0.389 ns |  0.27 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 9,561.55 ns | 38.920 ns | 36.406 ns |  1.00 | 0.1221 |     - |     - |     256 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 6,122.13 ns | 14.826 ns | 13.869 ns |  0.64 | 0.0534 |     - |     - |     112 B |

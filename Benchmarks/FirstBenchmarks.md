## FirstBenchmarks

### Source
[FirstBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/FirstBenchmarks.cs)

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
  Job-KXCEYC : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  25.26 ns | 0.111 ns | 0.099 ns |  1.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  13.27 ns | 0.041 ns | 0.039 ns |  0.53 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |  25.15 ns | 0.090 ns | 0.070 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  15.62 ns | 0.043 ns | 0.036 ns |  0.62 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  25.78 ns | 0.090 ns | 0.080 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  19.20 ns | 0.078 ns | 0.073 ns |  0.75 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  13.27 ns | 0.045 ns | 0.035 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  14.94 ns | 0.056 ns | 0.049 ns |  1.13 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 107.07 ns | 0.239 ns | 0.187 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  64.04 ns | 0.376 ns | 0.314 ns |  0.60 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  25.56 ns | 0.119 ns | 0.100 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  40.37 ns | 0.294 ns | 0.261 ns |  1.58 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  25.78 ns | 0.260 ns | 0.203 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  19.42 ns | 0.058 ns | 0.051 ns |  0.75 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  13.51 ns | 0.225 ns | 0.188 ns |  1.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  14.68 ns | 0.035 ns | 0.031 ns |  1.09 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 105.10 ns | 0.225 ns | 0.210 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  71.06 ns | 0.539 ns | 0.504 ns |  0.68 | 0.0153 |     - |     - |      32 B |

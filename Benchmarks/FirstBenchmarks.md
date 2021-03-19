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
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  21.69 ns | 0.108 ns | 0.096 ns |  1.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  13.33 ns | 0.029 ns | 0.024 ns |  0.61 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |  25.27 ns | 0.083 ns | 0.073 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  15.62 ns | 0.036 ns | 0.032 ns |  0.62 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  26.29 ns | 0.138 ns | 0.116 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  19.12 ns | 0.054 ns | 0.051 ns |  0.73 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  13.38 ns | 0.072 ns | 0.067 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  14.99 ns | 0.089 ns | 0.083 ns |  1.12 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 104.97 ns | 0.191 ns | 0.169 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  63.66 ns | 0.292 ns | 0.273 ns |  0.61 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  25.65 ns | 0.151 ns | 0.141 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  17.22 ns | 0.066 ns | 0.062 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  25.67 ns | 0.173 ns | 0.153 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  18.86 ns | 0.073 ns | 0.061 ns |  0.73 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  13.32 ns | 0.071 ns | 0.059 ns |  1.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  14.66 ns | 0.058 ns | 0.048 ns |  1.10 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 107.94 ns | 0.590 ns | 0.552 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  71.80 ns | 0.260 ns | 0.230 ns |  0.66 | 0.0153 |     - |     - |      32 B |

## SelectBenchmarks

### Source
[SelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   649.3 ns |  3.81 ns |  3.38 ns |   649.3 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   213.9 ns |  0.40 ns |  0.35 ns |   213.8 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |   100 |   224.7 ns |  2.42 ns |  3.54 ns |   223.5 ns |  0.35 |    0.01 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |   100 |   252.0 ns |  7.48 ns | 22.05 ns |   245.4 ns |  0.41 |    0.03 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |   100 |   219.1 ns |  0.57 ns |  0.50 ns |   219.1 ns |  0.34 |    0.00 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |   100 |   207.1 ns |  0.69 ns |  0.61 ns |   207.2 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |   100 |   298.9 ns |  1.97 ns |  1.64 ns |   298.5 ns |  0.46 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |   100 |   236.4 ns |  0.81 ns |  0.68 ns |   236.3 ns |  0.36 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,244.7 ns |  6.85 ns |  5.72 ns | 1,243.7 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   795.1 ns |  2.18 ns |  1.93 ns |   795.4 ns |  0.64 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   238.8 ns |  0.86 ns |  0.67 ns |   238.9 ns |  0.19 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,247.5 ns |  4.97 ns |  4.41 ns | 1,246.0 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   791.6 ns |  1.71 ns |  1.42 ns |   790.9 ns |  0.63 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   208.1 ns |  0.58 ns |  0.48 ns |   208.2 ns |  0.17 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,191.8 ns |  5.52 ns |  4.89 ns | 1,189.7 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   369.3 ns |  1.11 ns |  0.98 ns |   369.3 ns |  0.31 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |   100 |   396.5 ns |  1.39 ns |  1.16 ns |   396.5 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |   100 |   413.4 ns |  1.93 ns |  1.71 ns |   413.1 ns |  0.35 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,335.0 ns | 33.17 ns | 31.03 ns | 8,338.7 ns |  1.00 |    0.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,470.6 ns | 17.71 ns | 14.79 ns | 6,471.6 ns |  0.78 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   975.0 ns |  3.38 ns |  3.16 ns |   974.2 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   517.4 ns |  2.24 ns |  1.99 ns |   517.5 ns |  0.53 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   529.0 ns |  4.08 ns |  3.61 ns |   528.2 ns |  0.54 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   975.0 ns |  4.34 ns |  3.85 ns |   975.4 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   566.8 ns |  2.68 ns |  2.24 ns |   565.9 ns |  0.58 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   592.6 ns |  1.66 ns |  1.47 ns |   592.2 ns |  0.61 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   958.7 ns |  6.11 ns |  5.10 ns |   957.0 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   567.4 ns |  2.49 ns |  2.08 ns |   566.6 ns |  0.59 |    0.00 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |   100 |   401.4 ns |  1.10 ns |  1.03 ns |   401.4 ns |  0.42 |    0.00 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |   100 |   434.3 ns |  0.92 ns |  0.77 ns |   434.2 ns |  0.45 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,852.8 ns | 27.00 ns | 22.54 ns | 7,850.5 ns |  1.00 |    0.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,290.5 ns |  9.09 ns |  8.06 ns | 6,292.2 ns |  0.80 |    0.00 | 0.0153 |     - |     - |      40 B |
